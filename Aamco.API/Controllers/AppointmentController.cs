using System;
using System.Linq;
using Aamco.API.Models;
using Aamco.Data;
using Aamco.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Aamco.API.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly AamcoDbContextFactory _aamcoContextFactory;

        public AppointmentController(AamcoDbContextFactory aamcoContextFactory)
        {
            _aamcoContextFactory = aamcoContextFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "AppointmentController works!" });
        }

        [HttpPost]
        public IActionResult Post([FromBody]AppointmentModel model)
        {
            if (model == null) return BadRequest("Appointment can not be null");
            if (model.StartsOn > model.EndsOn)
                ModelState.AddModelError("startsOn", $"startsOn can not be greater than endsOn");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var context = _aamcoContextFactory.Create())
            {
                //may not check for correctness due to optionality of VehicleServicesIds and VehicleMarkId values
                var vehicleServices = context.VehicleServices.Where(s => model.VehicleServicesIds.Contains(s.Id)).ToList();
                var vehicleMark = context.VehicleMarks.FirstOrDefault(m => m.Id == model.VehicleMarkId);

                var appointment = new Appointment()
                {
                    StartsOn = model.StartsOn,
                    EndsOn = model.EndsOn,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    Email = model.Email,
                    Phone = model.Phone,
                    VehicleMark = vehicleMark,
                    VehicleServices = vehicleServices,
                    VehicleYear = model.VehicleYear,
                    Created = DateTime.Now,
                };
                context.Appointments.Add(appointment);

                //if did write rows to database
                if (context.SaveChanges() > 0)
                {
                    var details = new AppointmentDetailsModel()
                    {
                        StartsOn = appointment.StartsOn,
                        EndsOn = appointment.EndsOn.Value
                    };
                    return Ok(details);
                }
                else
                {
                    return BadRequest("Appointment wasn't saved");
                }
            }

        }
    }
}
