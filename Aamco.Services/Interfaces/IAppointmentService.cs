using Aamco.Data.Entities;
using Aamco.Services.Models;

namespace Aamco.Services.Interfaces
{
    public interface IAppointmentService
    {
        Appointment Save(AppointmentModel model);
    }
}