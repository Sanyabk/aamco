using Microsoft.AspNetCore.Mvc;
using Aamco.Services.Models;
using Aamco.API.ViewModels;
using Aamco.Services.Interfaces;

namespace Aamco.API.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]AppointmentModel model)
        {
            if (model == null)
                return BadRequest("Appointment can not be null");

            if (model.StartsOn > model.EndsOn)
                ModelState.AddModelError("startsOn", $"startsOn can not be greater than endsOn");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedAppointment = _appointmentService.Save(model);
            if (savedAppointment == null) return BadRequest("Appointment wasn't saved");

            //fill details to return
            var details = new AppointmentDetailsViewModel()
            {
                StartsOn = savedAppointment.StartsOn,
                EndsOn = savedAppointment.EndsOn.Value
            };
            return Ok(details);

        }
    }
}
