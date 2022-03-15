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
        string baseurl;
        AllUserController(IConfiguration config) {baseurl = config.GetConnectionString("base"); }
        // GET
        [HttpGet]
        public async Task<IEnumerable<ComplexUser>> GetComplexUsersAsync()
        {

            var result = new List<ComplexUser>();
            using (HttpClient httpClient = new HttpClient())
            {
                var employeeslist = JsonConvert.DeserializeObject<List<EmployeeFromApi>>(
                        await httpClient.GetStringAsync(baseurl + "api_employees")
                    );
                
                //ca sa pot sa testez pana se fac modificarile necesare la api
                //StergeAici
                foreach(var emp in employeeslist)
                    { emp.IdDesk = 1; }
                //pana aici

                var deskslist = JsonConvert.DeserializeObject<List<DeskFromApi>>(
                        await httpClient.GetStringAsync(baseurl + "api_desks")
                    );
                var officelist = JsonConvert.DeserializeObject<List<OfficeFromApi>>(
                        await httpClient.GetStringAsync(baseurl + "api_offices")
                    );
                var buildinglist = JsonConvert.DeserializeObject<List<CladiriFromApi>>(
                        await httpClient.GetStringAsync(baseurl + "api_cladiri")
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
                        await httpClient.GetStringAsync(baseurl + "api_employee/" + id)
                    );

                //ca sa pot sa testez pana se fac modificarile necesare la api
                //StergeAici
                employee.IdDesk = 1;
                //pana aici

                //get desk current user
                var curentUserDesk = JsonConvert.DeserializeObject<DeskFromApi>(
                        await httpClient.GetStringAsync(baseurl + "api_desk/" + "1"
                                    /* se sterge + "1" si se lasa ce e mai jos
                                        (JsonConvert.DeserializeObject<EmployeeFromApi>(await httpClient 
                                        .GetStringAsync(baseurl + "api_employee/" + id))).IdDesk  */
                                    ));
                //get office curent user
                var office = JsonConvert.DeserializeObject<OfficeFromApi>(
                        await httpClient.GetStringAsync(baseurl + "api_office/" + curentUserDesk.office));
                //get building current user
                var building = JsonConvert.DeserializeObject<CladiriFromApi>(
                        await httpClient.GetStringAsync(baseurl + "api_cladire/" + office.building));
                //get all desks in the office where curent user is situated
                var desks = JsonConvert.DeserializeObject<List<DeskFromApi>>(
                        await httpClient.GetStringAsync(baseurl + "api_desks/")).Where(x => x.office == curentUserDesk.office).ToList();
                //get all employees 
                var auxUsers = JsonConvert.DeserializeObject<List<EmployeeFromApi>>(
                    await httpClient.GetStringAsync(baseurl + "api_employees/"));
                //join to get userlist in curent office 

                foreach (var emp in auxUsers)
                { emp.IdDesk = 1; }

                var userList = from user in auxUsers
                               join desk in desks on user.IdDesk equals desk.idDesk
                               select new EmployeeFromApi { IdEmployee = user.IdEmployee, firstName = user.firstName, lastName = user.lastName,
                                   RemoteStatus = user.RemoteStatus, Role = user.Role, Gender = user.Gender, Nationality = user.Nationality,
                                   Adress = user.Adress, IdDesk = user.IdDesk };

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
                    OcupationPercentage = 0 };
            }
            return result;
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
