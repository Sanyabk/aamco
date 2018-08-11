using System.Linq;
using Aamco.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aamco.API.Controllers
{
    [Route("api/[controller]")]
    public class VehicleMarkController : Controller
    {
        private readonly AamcoContextFactory _aamcoContextFactory;

        public VehicleMarkController(AamcoContextFactory aamcoContextFactory)
        {
            _aamcoContextFactory = aamcoContextFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using (var context = _aamcoContextFactory.Create())
            {
                var vehicleMarks = context.VehicleMarks.ToList(); //query all marks from table
                return Ok(vehicleMarks);
            }
        }
    }
}
