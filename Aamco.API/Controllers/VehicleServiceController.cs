using System.Collections.Generic;
using System.Linq;
using Aamco.Data;
using Aamco.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Aamco.API.Controllers
{
    [Route("api/[controller]")]
    public class VehicleServiceController : Controller
    {
        private readonly AamcoDbContextFactory _aamcoContextFactory;

        public VehicleServiceController(AamcoDbContextFactory aamcoContextFactory)
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
