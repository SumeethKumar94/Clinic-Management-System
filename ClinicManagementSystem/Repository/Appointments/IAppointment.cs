using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.Appointments;

namespace ClinicManagementSystem.Repository.Appointments
{
    public interface IAppointment
    {
        Task<List<Appointmentview>> GetAppointments();
        Task<int> AddAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
      
        


    }
}
