using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elSpaco.Models
{
    public class DeskFromApi
    {
        public int idDesk { get; set; }
        public int deskCount { get; set; }
        public int usedDesks { get; set; }
        public string adminOffice { get; set; }
        public int lengthDesk { get; set; }
        public int widthDesk { get; set; }
        public bool isOccupied { get; set; }
        public int office { get; set; }
    }
}
