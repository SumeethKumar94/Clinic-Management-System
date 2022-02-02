using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.Appointments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Appointments
{
    public class AppointmentClass : IAppointment  
    {
        private readonly ClinicManagementSystemDBContext _contextone;
        public AppointmentClass(ClinicManagementSystemDBContext contextone)
        {
        _contextone = contextone;
        }

        public async Task<int> AddAppointment(Appointment appointment)
        {
            if (_contextone!= null)
            {

                await _contextone.Appointment.AddAsync(appointment);
                await _contextone.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<List<Appointmentview>> GetAppointments()
        {
            if (_contextone != null)
            {
                return await (
                              from a in _contextone.Appointment
                              join
                              p in _contextone.Patient
                              on a.PatientId equals p.PatientId
                              join
                              s in _contextone.Staff
                              on a.DoctorId equals s.StaffId
                              select new Appointmentview
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = a.TokenNo,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  DoctorName = ""+(from dc in _contextone.Staff
                                                where dc.StaffId == a.DoctorId
                                                select dc.FirstName).FirstOrDefault(),
                                  Receptionistname= ""+(from rc in _contextone.Staff
                                                     where rc.StaffId == a.ReceptionistId
                                                     select rc.FirstName).FirstOrDefault(),
                                  AppointmentDate=a.AppointmentDate
                              }).ToListAsync();  //FirstorDefaultAsync();
            }
            return null;
        }

       

        public async Task UpdateAppointment(Appointment appointment)
        {
            if (_contextone != null)
            {
                _contextone.Entry(appointment).State = EntityState.Modified;
                _contextone.Appointment.Update(appointment);
                await _contextone.SaveChangesAsync();
            }
        }
    }
}
