using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        
        //time info
        public DateTime StartsOn { get; set; }
        public DateTime? EndsOn { get; set; }

        //personal info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //vehicle info
        public string VehicleModel { get; set; }
        public int VehicleYear { get; set; }
    }
}
