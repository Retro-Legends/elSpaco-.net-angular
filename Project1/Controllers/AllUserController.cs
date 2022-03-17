using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using elSpaco.Models;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace elSpaco.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllUserController : ControllerBase
    {
        private string baseUrl = "https://elspaco.a2hosted.com/";
        private string format = "/?format=json";
        //AllUserController (IConfiguration config) { baseUrl = config.GetConnectionString("baseurl"); }
        // GET
        [HttpGet]
        public async Task<IEnumerable<ComplexUser>> GetComplexUsersAsync()
        {

            var result = new List<ComplexUser>();
            using (HttpClient httpClient = new HttpClient())
            {
                var employeeslist = JsonConvert.DeserializeObject<List<EmployeeFromApi>>(
                        await httpClient.GetStringAsync(baseUrl + "api_employees" + format)
                    );
                
                //ca sa pot sa testez pana se fac modificarile necesare la api
                //StergeAici
                
                //pana aici

                var deskslist = JsonConvert.DeserializeObject<List<DeskFromApi>>(
                        await httpClient.GetStringAsync(baseUrl + "api_desks" + format)
                    );
                var officelist = JsonConvert.DeserializeObject<List<OfficeFromApi>>(
                        await httpClient.GetStringAsync(baseUrl + "api_offices" + format)
                    );
                var buildinglist = JsonConvert.DeserializeObject<List<CladiriFromApi>>(
                        await httpClient.GetStringAsync(baseUrl + "api_cladiri" + format)
                    );
                var complex = from employee in employeeslist
                               join desk in deskslist on employee.desk equals desk.idDesk into aux1
                               from desk in aux1
                               join office in officelist on desk.office equals office.idOffice into aux2
                               from office in aux2
                               join building in buildinglist on office.building equals building.codCladire
                               select new ComplexUser{ IdEmployee = employee.IdEmployee, Name = employee.firstName, Surname = employee.lastName,
                                   BuildingName = building.denCladire, Office = office.nameOffice, RemoteStatus = employee.RemoteStatus,
                                   Role = employee.Role, Gender = employee.Gender,Nationality = employee.Nationality,
                                   Adress = employee.Adress};
                foreach (var c in complex)
                    result.Add(c);
            }
            /* las aici pentru testare
            List<ComplexUser> result = new List<ComplexUser>();
            ComplexUser aux;
            for (int i = 0; i < 15; i++)
            {
                aux = new ComplexUser();
                aux.Name = "Abc" + i.ToString();
                aux.Surname = "Dr Nice";
                aux.BuildingName = "acasa";
                aux.Office = "dormitor";
                aux.RemoteStatus = "50";
                result.Add(aux);
            }
            */
            System.Diagnostics.Trace.TraceError(result.ToString());
            return Enumerable.ToArray(result);
        }

        [HttpGet("{id:int}")]
        public async Task<OfficeStatusModel> GetOfficeStatusAsync(int id)
            {
                var result = new OfficeStatusModel();
                using (HttpClient httpClient = new HttpClient())
                {
                //se sterge de aici
                var employee = JsonConvert.DeserializeObject<EmployeeFromApi>(
                        await httpClient.GetStringAsync(baseUrl + "api_employee/" + id)
                    );

                //get desk current user
                var curentUserDesk = JsonConvert.DeserializeObject<DeskFromApi>(
                        await httpClient.GetStringAsync(baseUrl + "api_desk/" + "1"
                                    /* se sterge + "1" si se lasa ce e mai jos
                                        (JsonConvert.DeserializeObject<EmployeeFromApi>(await httpClient 
                                        .GetStringAsync(baseUrl + "api_employee/" + id))).desk  */
                                    ));
                //get office curent user
                var office = JsonConvert.DeserializeObject<OfficeFromApi>(
                        await httpClient.GetStringAsync(baseUrl + "api_office/" + curentUserDesk.office));
                //get building current user
                var building = JsonConvert.DeserializeObject<CladiriFromApi>(
                        await httpClient.GetStringAsync(baseUrl + "api_cladire/" + office.building));
                //get all desks in the office where curent user is situated
                var desks = JsonConvert.DeserializeObject<List<DeskFromApi>>(
                        await httpClient.GetStringAsync(baseUrl + "api_desks/")).Where(x => x.office == curentUserDesk.office).ToList();
                //get all employees 
                var auxUsers = JsonConvert.DeserializeObject<List<EmployeeFromApi>>(
                    await httpClient.GetStringAsync(baseUrl + "api_employees/"));
                //join to get userlist in curent office 


                var userList = from user in auxUsers
                               join desk in desks on user.desk equals desk.idDesk
                               select new EmployeeFromApi { IdEmployee = user.IdEmployee, firstName =user.firstName, lastName = user.lastName,
                               RemoteStatus = user.RemoteStatus, Role = user.Role, Gender =user.Gender, Nationality = user.Nationality,
                               Adress = user.Adress,desk = user.desk};

                OfficeStatusModel off = new OfficeStatusModel();

                off.OfficeName = office.nameOffice;
                off.BuildingName = building.denCladire;
                off.Users = userList.ToArray();
                off.OcupiedDeskCount = office.usedDesks;
                off.UsableDeskCount = office.deskCount;
                off.FreeDeskCount = 0;
                off.OcupationPercentage = 0;
               

                result = new OfficeStatusModel() {
                    OfficeName = office.nameOffice,
                    BuildingName = building.denCladire,
                    Users = userList.ToArray(),
                    OcupiedDeskCount = office.usedDesks,
                    UsableDeskCount = office.deskCount,
                    FreeDeskCount = 0,
                    OcupationPercentage=0
                };
                Debug.Write("cv");
                }
                return result;
            }


            /* las pe mai indata
            [HttpGet("{id}")]
            public async Task<List<ComplexUser>> Search(string str,string type)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    if (type.ToLower() == "name" || type.ToLower() == "surname")
                    {
                        httpClient.DefaultRequestHeaders.Add(str, type.ToLower());
                    }
                    else
                    {
                        //throw new HttpResponseException(responseMessage);
                    }
                    string uri = host + path + "?mkt=" + market + "&q=" + System.Net.WebUtility.UrlEncode(query);

                    HttpResponseMessage response = await client.GetAsync(uri);

                    string contentString = await response.Content.ReadAsStringAsync();
                    dynamic parsedJson = JsonConvert.DeserializeObject(contentString);
                    Console.WriteLine(parsedJson);
                }
                return "value";
            }
            */

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
