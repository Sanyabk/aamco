using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aamco.API.Models;
using Aamco.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aamco.API.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]AppointmentModel model)
        {
            //if (model == null) return BadRequest("Appointment can not be null");
            //if (!ModelState.IsValid)
            //{
            //    //there may be filling with errors
            //    return BadRequest();
            //}

            using (var context = new AamcoContext())
            {
                context.Appointments.Add(new Appointment() { FirstName = "John", Email = "john.doe@gmail.com", StartsOn = DateTime.Now });
                context.SaveChanges();
            }

            return Ok();
        }
    }
}
