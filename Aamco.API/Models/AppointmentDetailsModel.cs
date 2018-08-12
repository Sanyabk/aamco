using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.API.Models
{
    public class AppointmentDetailsModel
    {
        public DateTime StartsOn { get; set; }
        public DateTime? EndsOn { get; set; }
    }
}
