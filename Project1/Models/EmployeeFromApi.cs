using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elSpaco.Models
{
    public class EmployeeFromApi
    {

        /* "[{\"idEmployee\":1,
* \"firstName\":\"Vasile\",
* \"lastName\":\"Popescu\",
* \"role\":\"admin\",
* \\"gender\":\"MALE\",
* \\"birthDate\":\"2000-01-01\",
* \\"nationality\":\"rom\",
* \"address\":\"SV\",
* \"isActive\":true},
* 
* {\"idEmployee\":2,\"firstName\":\"Maria\",\"lastName\":\"Popinciuc\",\"role\":\"admin\",\"gender\":\"FEMALE\",\"birthDate\":\"2000-01-01\",\"nationality\":\"romana\",\"address\":\"Iasi\",\"isActive\":true}]"
*/
        public int IdEmployee { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string RemoteStatus { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Adress { get; set; }
        public int desk { get; set; }


    }
}
