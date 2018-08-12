using Aamco.Data;
using Aamco.Data.Entities;
using Aamco.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Aamco.Services.Implementations
{
    public class VehicleServiceService : IVehicleServiceService
    {
        private readonly AamcoDbContextFactory _aamcoContextFactory;

        public VehicleServiceService(AamcoDbContextFactory aamcoContextFactory)
        {
            _aamcoContextFactory = aamcoContextFactory;
        }

        public IEnumerable<VehicleService> GetAll()
        {
            using (var context = _aamcoContextFactory.Create())
            {
                var services = context.VehicleServices.ToList(); //query all services from table
                return services;
            }
        }
    }
}
