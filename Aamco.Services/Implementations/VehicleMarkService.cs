using Aamco.Data;
using Aamco.Data.Entities;
using Aamco.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Aamco.Services.Implementations
{
    public class VehicleMarkService : IVehicleMarkService
    {
        private readonly AamcoDbContextFactory _aamcoContextFactory;

        public VehicleMarkService(AamcoDbContextFactory aamcoContextFactory)
        {
            _aamcoContextFactory = aamcoContextFactory;
        }

        public IEnumerable<VehicleMark> GetAll()
        {
            using (var context = _aamcoContextFactory.Create())
            {
                var vehicleMarks = context.VehicleMarks.ToList(); //query all marks from table
                return vehicleMarks;
            }
        }
    }
}
