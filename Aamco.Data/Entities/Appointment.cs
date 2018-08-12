using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        
        //time info
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime StartsOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndsOn { get; set; }

        //personal info
        [Required]
        public string FirstName { get; set; }

        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //vehicle info
        public VehicleMark VehicleMark { get; set; }
        public int VehicleYear { get; set; }

        public IEnumerable<VehicleService> VehicleServices { get; set; } = new List<VehicleService>();

        //internal info
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
    }
}
