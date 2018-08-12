using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.API.ViewModels
{
    public class AppointmentDetailsViewModel
    {
        public DateTime StartsOn { get; set; }
        public DateTime? EndsOn { get; set; }
    }
}
