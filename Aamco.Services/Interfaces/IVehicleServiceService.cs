using System.Collections.Generic;
using Aamco.Data.Entities;

namespace Aamco.Services.Interfaces
{
    public interface IVehicleServiceService
    {
        IEnumerable<VehicleService> GetAll();
    }
}