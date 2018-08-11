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
        private readonly AamcoContextFactory _aamcoContextFactory;

        public VehicleServiceController(AamcoContextFactory aamcoContextFactory)
        {
            _aamcoContextFactory = aamcoContextFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //using (var context = _aamcoContextFactory.Create())
            //{
            //    var services = context.VehicleServices.ToList(); //query all services from table
            //    return Ok(services);
            //}
            var services = new List<VehicleService>()
            {
                new VehicleService { Id = 1, Name ="Transmission" },
                new VehicleService { Id = 2, Name ="Vehicle Maintenance" },
                new VehicleService { Id = 3, Name ="Vehicle Repair" },
                new VehicleService { Id = 4, Name ="Other" },
            };
            return Ok(services);
        }
    }
}
