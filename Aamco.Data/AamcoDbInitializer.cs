using Aamco.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamco.Data
{
    public class AamcoDbInitializer : CreateDatabaseIfNotExists<AamcoDbContext>
    {
        protected override void Seed(AamcoDbContext context)
        {
            //prepare seed data
            var marks = new List<VehicleMark>()
            {
                new VehicleMark { Name ="Hyundai" },
                new VehicleMark { Name ="Kia" },
                new VehicleMark { Name ="Toyota" },
                new VehicleMark { Name ="Skoda" },
                new VehicleMark { Name ="Mitsubishi" },
                new VehicleMark { Name ="Mazda" },
            };
            var services = new List<VehicleService>()
            {
                new VehicleService { Name ="Transmission" },
                new VehicleService { Name ="Vehicle Maintenance" },
                new VehicleService { Name ="Vehicle Repair" },
                new VehicleService { Name ="Other" },
            };

            //add seed data to db
            context.VehicleMarks.AddRange(marks);
            context.VehicleServices.AddRange(services);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
