using System.Linq;
using Aamco.API.ViewModels;
using Aamco.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aamco.API.Controllers
{
    [Route("api/[controller]")]
    public class VehicleMarkController : Controller
    {
        private readonly IVehicleMarkService _vehicleMarkService;

        public VehicleMarkController(IVehicleMarkService vehicleMarkService)
        {
            _vehicleMarkService = vehicleMarkService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var marks = _vehicleMarkService.GetAll()
                .Select(m => new VehicleMarkViewModel()
                {
                    Id = m.Id,
                    Name = m.Name
                });

            return Ok(marks);
        }
    }
}
