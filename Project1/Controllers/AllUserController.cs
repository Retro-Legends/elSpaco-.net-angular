using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using elSpaco.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace elSpaco.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllUserController : ControllerBase
    {
        // GET
        [HttpGet]
        public async Task<IEnumerable<ComplexUser>> GetAsync()
        {

            var result = new List<ComplexUser>();
            using (HttpClient httpClient = new HttpClient())
            {
                var employeeslist = JsonConvert.DeserializeObject<List<EmployeeFromApi>>(
                        await httpClient.GetStringAsync("http://127.0.0.1:8000/api_employees")
                    );
                
                //ca sa pot sa testez pana se fac modificarile necesare la api
                //StergeAici
                foreach(var emp in employeeslist)
                    { emp.IdDesk = 1; }
                //pana aici

                var deskslist = JsonConvert.DeserializeObject<List<DeskFromApi>>(
                        await httpClient.GetStringAsync("http://127.0.0.1:8000/api_desks")
                    );
                var officelist = JsonConvert.DeserializeObject<List<OfficeFromApi>>(
                        await httpClient.GetStringAsync("http://127.0.0.1:8000/api_offices")
                    );
                var buildinglist = JsonConvert.DeserializeObject<List<CladiriFromApi>>(
                        await httpClient.GetStringAsync("http://127.0.0.1:8000/api_cladiri")
                    );
                var complex = from employee in employeeslist
                               join desk in deskslist on employee.IdDesk equals desk.idDesk into aux1
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
            return Enumerable.ToArray(result);
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


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

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
