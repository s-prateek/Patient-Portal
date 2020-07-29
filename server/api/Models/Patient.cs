using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public int CityId { get; set; }
    }
}
