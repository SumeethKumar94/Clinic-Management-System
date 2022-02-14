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
        #region Add Appointment
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
        #endregion

        #region Get Appointments
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
                                  TokenNo = (int)a.TokenNo,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  PhoneNumber = p.Phone,
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
        #endregion

        #region Get Appointment by ID
        public async Task<Appointmentview> GetAppointmentsById(int id)
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
                              where a.AppointmentId==id
                              select new Appointmentview
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = (int)a.TokenNo,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  PhoneNumber = p.Phone,
                                  DoctorName = "" + (from dc in _contextone.Staff
                                                     where dc.StaffId == a.DoctorId
                                                     select dc.FirstName).FirstOrDefault(),
                                  Receptionistname = "" + (from rc in _contextone.Staff
                                                           where rc.StaffId == a.ReceptionistId
                                                           select rc.FirstName).FirstOrDefault(),
                                  AppointmentDate = a.AppointmentDate
                              }).FirstOrDefaultAsync();  //FirstorDefaultAsync();
            }
            return null;
        }
        #endregion

        #region Get Appointment by Phone
        public async Task<Appointmentview> GetAppointmentsByPhone(Int64 phone)
        {
            if (_contextone != null)
            {
                return await(
                              from a in _contextone.Appointment
                              join
                              p in _contextone.Patient
                              on a.PatientId equals p.PatientId
                              join
                              s in _contextone.Staff
                              on a.DoctorId equals s.StaffId
                              where p.Phone == phone
                              select new Appointmentview
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = (int)a.TokenNo,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  PhoneNumber=p.Phone,
                                  DoctorName = "" + (from dc in _contextone.Staff
                                                     where dc.StaffId == a.DoctorId
                                                     select dc.FirstName).FirstOrDefault(),
                                  Receptionistname = "" + (from rc in _contextone.Staff
                                                           where rc.StaffId == a.ReceptionistId
                                                           select rc.FirstName).FirstOrDefault(),
                                  AppointmentDate = a.AppointmentDate
                              }).FirstOrDefaultAsync();  //FirstorDefaultAsync();
            }
            return null;
        }
        #endregion

        #region Update Appointment
        public async Task UpdateAppointment(Appointment appointment)
        {
            if (_contextone != null)
            {
                _contextone.Entry(appointment).State = EntityState.Modified;
                _contextone.Appointment.Update(appointment);
                await _contextone.SaveChangesAsync();
            }
        }
        #endregion
    }
}
