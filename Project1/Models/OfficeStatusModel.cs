using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elSpaco.Models
{
    public class OfficeStatusModel
    {
        public string OfficeName { get; set; }
        public string BuildingName { get; set; }
        public List<EmployeeFromApi> Users { get; set; }
        public int OcupiedDeskCount { get; set; }
        public int UsableDeskCount { get; set; }
        public int FreeDeskCount
        {
            get { return (this.UsableDeskCount - this.OcupiedDeskCount); }
            set { value = (this.UsableDeskCount - this.OcupiedDeskCount); }
        }
        public int OcupationPercentage 
        {
            get { return ((this.UsableDeskCount * 100) / this.OcupiedDeskCount);  }
            set { value = (this.UsableDeskCount*100) / this.OcupiedDeskCount; }
        }
        //schimba aici free desk si OcupationPercentage
    }
}
