using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace elSpaco.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllUserController : ControllerBase
    {
        // GET
        [HttpGet]
        public IEnumerable<ComplexUser> Get()
        {
            /* using (HttpClient httpClient = new HttpClient())
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
                 */


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
            //de modificat 
            //test partial
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
