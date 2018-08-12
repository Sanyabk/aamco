using System.Linq;
using Aamco.API.ViewModels;
using Aamco.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aamco.API.Controllers
{
    [Route("api/[controller]")]
    public class VehicleServiceController : Controller
    {
        private readonly IVehicleServiceService _vehicleServiceService;

        public VehicleServiceController(IVehicleServiceService vehicleServiceService)
        {
            _vehicleServiceService = vehicleServiceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var services = _vehicleServiceService.GetAll()
                .Select(s => new VehicleServiceViewModel()
                {
                    Id = s.Id,
                    Name = s.Name
                });
            return Ok(services);
        }
    }
}
