using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elSpaco.Models
{
    public class OfficeFromApi
    {
        public int idOffice { get; set; }
        public string nameOffice { get; set; }
        public int floor { get; set; }
        public int deskCount { get; set; }
        public int usedDesks { get; set; }
        public string adminOffice { get; set; }
        public int lengthOffice { get; set; }
        public int widthOffice { get; set; }
        public int building { get; set; }
    }
}
