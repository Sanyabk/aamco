using Aamco.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.Data
{
    public class AamcoDbContext : DbContext
    {
        public AamcoDbContext(string connString) : base(connString)
        {
            Database.SetInitializer(new AamcoDbInitializer());
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<VehicleMark> VehicleMarks { get; set; }
        public DbSet<VehicleService> VehicleServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
