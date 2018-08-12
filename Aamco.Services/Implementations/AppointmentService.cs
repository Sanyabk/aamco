using Aamco.Data;
using Aamco.Data.Entities;
using Aamco.Services.Interfaces;
using Aamco.Services.Models;
using System;
using System.Linq;

namespace Aamco.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AamcoDbContextFactory _aamcoContextFactory;

        public AppointmentService(AamcoDbContextFactory aamcoContextFactory)
        {
            _aamcoContextFactory = aamcoContextFactory;
        }

        public Appointment Save(AppointmentModel model)
        {
            using (var context = _aamcoContextFactory.Create())
            {
                //may not check for correctness due to optionality of VehicleServicesIds and VehicleMarkId values
                var vehicleServices = context.VehicleServices.Where(s => model.VehicleServicesIds.Contains(s.Id)).ToList();
                var vehicleMark = context.VehicleMarks.FirstOrDefault(m => m.Id == model.VehicleMarkId);

                var appointment = new Appointment()
                {
                    StartsOn = model.StartsOn,
                    EndsOn = model.EndsOn,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    Email = model.Email,
                    Phone = model.Phone,
                    VehicleMark = vehicleMark,
                    VehicleServices = vehicleServices,
                    VehicleYear = model.VehicleYear,
                    Created = DateTime.Now,
                };
                
                context.Appointments.Add(appointment);
                context.SaveChanges();

                return appointment;
            }
        }
    }
}
