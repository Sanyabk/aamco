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
        private readonly AamcoContextFactory _aamcoContextFactory;

        public AppointmentController(AamcoContextFactory aamcoContextFactory)
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
            //if (model == null) return BadRequest("Appointment can not be null");
            //if (!ModelState.IsValid)
            //{
            //    //there may be filling with errors
            //    return BadRequest();
            //}
            if (model == null) model = new AppointmentModel();

            using (var context = _aamcoContextFactory.Create())
            {
                var vehicleMark = context.VehicleMarks.FirstOrDefault(m => m.Id == model.VehicleMarkId);
                var vehicleServices = context.VehicleServices.Where(s => model.VehicleServicesIds.Contains(s.Id)).ToList();
                if (vehicleMark == null || !vehicleServices.Any())
                {
                    return BadRequest();
                }

                var appointment = new Appointment()
                {
                    StartsOn = model.StartsOn,
                    EndsOn = model.EndsOn,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = "john.doe@gmail.com",
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
                    return Ok(appointment.Id);
                }
                else
                {
                    return BadRequest("Appointment wasn't saved");
                }
            }

        }
    }
}
