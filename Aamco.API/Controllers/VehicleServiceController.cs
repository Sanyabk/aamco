using System.Linq;
using Aamco.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aamco.API.Controllers
{
    [Route("api/[controller]")]
    public class VehicleServiceController : Controller
    {
        private readonly AamcoContextFactory _aamcoContextFactory;

        public VehicleServiceController(AamcoContextFactory aamcoContextFactory)
        {
            _aamcoContextFactory = aamcoContextFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using (var context = _aamcoContextFactory.Create())
            {
                var services = context.VehicleServices.ToList(); //query all services from table
                return Ok(services);
            }
        }
    }
}
