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
        Task<Appointmentview> GetAppointmentsById(int id);
        Task<Appointmentview> GetAppointmentsByPhone(Int64 id);
        Task<int> AddAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
       
      
        


    }
}
