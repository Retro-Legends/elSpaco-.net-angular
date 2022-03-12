using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elSpaco.Models;
using static elSpaco.Constants;
using Flurl;
using Flurl.Http;
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace elSpaco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllUserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<ComplexUser>> Get()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = JsonConvert.DeserializeObject<List<User>>(
                                await httpClient.GetStringAsync("https://localhost:8081/api/user")
                            );
                var roles = JsonConvert.DeserializeObject<List<Role>>(
                        await httpClient.GetStringAsync("https://localhost:8081/api/role")
                    );
                var employees = JsonConvert.DeserializeObject<List<Employee>>(
                        await httpClient.GetStringAsync("https://localhost:8081/api/employee")
                    );

                var result = from user in users
                             join employee in employees on user.Employee equals employee.Id into partial
                             select new { Id = user.Id, email = user.Email };
                //de modificat 
                //test partial
                return (List<ComplexUser>)result;
            }
        }

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
