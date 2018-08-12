using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.Services.Models
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
        public string SecondName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        //vehicle info
        public int VehicleMarkId { get; set; }

        [Range(1900, 2018)] //can not pass DateTime.Now.Year
        public int VehicleYear { get; set; }

        public IEnumerable<int> VehicleServicesIds { get; set; }
    }
}
