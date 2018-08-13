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
            modelBuilder.Entity<Appointment>().ToTable("ak_Appointment");
            modelBuilder.Entity<VehicleMark>().ToTable("ak_VehicleMarks");
            modelBuilder.Entity<VehicleService>().ToTable("ak_VehicleServices");

            //configure many-to-many relationship
            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.VehicleServices)
                .WithMany()
                .Map(avs => avs.ToTable("ak_Appointment_to_ak_VehicleServices"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
