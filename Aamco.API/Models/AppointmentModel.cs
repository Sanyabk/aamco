using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.API.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }

        //time info
        [Required]
        public DateTime StartsOn { get; set; }
        public DateTime? EndsOn { get; set; }

        //personal info
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }

        //vehicle info
        public string VehicleModel { get; set; }
        public int VehicleYear { get; set; }
    
    }
}
