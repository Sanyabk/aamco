using Aamco.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.Data
{
    public class AamcoContext : DbContext
    {
        public AamcoContext(string connString) : base(connString)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<VehicleMark> VehicleMarks { get; set; }
        public DbSet<VehicleService> VehicleServices { get; set; }
    }
}
