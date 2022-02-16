using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.Appointments;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                                  Sex = p.Sex,
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
        #region Get Appointment by Date
        public async Task<List<Appointmentview>> GetAppointmentsByDate(DateTime date)
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
                              where a.AppointmentDate.Day == date.Day && a.AppointmentDate.Month==date.Month && a.AppointmentDate.Year ==date.Day
                              select new Appointmentview
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = (int)a.TokenNo,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  PhoneNumber = p.Phone,
                                  Sex = p.Sex,
                                  DoctorName = "" + (from dc in _contextone.Staff
                                                     where dc.StaffId == a.DoctorId
                                                     select dc.FirstName).FirstOrDefault(),
                                  Receptionistname = "" + (from rc in _contextone.Staff
                                                           where rc.StaffId == a.ReceptionistId
                                                           select rc.FirstName).FirstOrDefault(),
                                  AppointmentDate = a.AppointmentDate
                              }).Distinct().ToListAsync();  //FirstorDefaultAsync();
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
                                  Sex = p.Sex,
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
        #region Get Appointment By Status
        public async Task<List<Appointmentview>> GetAppointmentsByStatus(int status)
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
                              where a.Status == status
                              orderby a.AppointmentDate ascending
                              select new Appointmentview
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = (int)a.TokenNo,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  PhoneNumber = p.Phone,
                                  Sex = p.Sex,
                                  DoctorName = "" + (from dc in _contextone.Staff
                                                     where dc.StaffId == a.DoctorId
                                                     select dc.FirstName).FirstOrDefault(),
                                  Receptionistname = "" + (from rc in _contextone.Staff
                                                           where rc.StaffId == a.ReceptionistId
                                                           select rc.FirstName).FirstOrDefault(),
                                  AppointmentDate = a.AppointmentDate
                              }).ToListAsync();  //FirstorDefaultAsync();
            }
            return null;
        }
        #endregion
        #region Get Today Appointment
        public async Task<List<Appointmentview>> GetAppointmentsToday()
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
                              where a.AppointmentDate.Day == DateTime.Today.Day && a.AppointmentDate.Month== DateTime.Today.Month && a.AppointmentDate.Year== DateTime.Today.Year && a.Status==1
                              select new Appointmentview
                              {
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = (int)a.TokenNo,
                                  PatientId = a.PatientId,
                                  PatientName = p.PatientName,
                                  PhoneNumber = p.Phone,
                                  Sex=p.Sex,
                                  DoctorName = "" + (from dc in _contextone.Staff
                                                     where dc.StaffId == a.DoctorId
                                                     select dc.FirstName).FirstOrDefault(),
                                  Receptionistname = "" + (from rc in _contextone.Staff
                                                           where rc.StaffId == a.ReceptionistId
                                                           select rc.FirstName).FirstOrDefault(),
                                  AppointmentDate = a.AppointmentDate
                              }).ToListAsync();  //FirstorDefaultAsync();
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

        #region Patch Appointment
       /* public async Task<int> PatchAppointment(int id, [FromBody]JsonPatchDocument<Appointment> patchEntity)
        {
           if (_contextone != null)
            {
           
                    var appointment=await _contextone.Appointment.FirstOrDefaultAsync(u => u.AppointmentId == id);
                if (appointment == null)
                {
                    return 0;
                }

                patchEntity.ApplyTo(appointment,ModelState); // Must have Microsoft.AspNetCore.Mvc.NewtonsoftJson installed
                   
                   _contextone.Appointment.Update(appointment);
                    await _contextone.SaveChangesAsync();
                    return status;
                }}*/
               
            
        
        
        #endregion

        #region Get Appointment by Doctor ID
        public async Task<List<Appointmentview>> GetAppointmentsByDoctorId(int id)
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
<<<<<<< HEAD
                              where a.DoctorId == id //&& a.Status==2
=======
                              where a.DoctorId == id 
>>>>>>> f382953f16efaa483bcce55d8881794d1af3f794
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
                              }).ToListAsync();  //FirstorDefaultAsync();
            }
            return null;
        }
        #endregion

<<<<<<< HEAD

        #region Delete Appointment
        public async Task<int> DeleteAppointment(int id)
        {
            // declare result
            int result = 0;
            if (_contextone != null)
            {
                var note = await _contextone.Appointment.FirstOrDefaultAsync(u => u.AppointmentId == id);
                if (note != null)
                {
                    // perform delete
                    _contextone.Appointment.Remove(note);
                    result = await _contextone.SaveChangesAsync(); // commit 
                    //return succcess;
                    result = 1;
                }
                return result;
            }
            return result;
        }
        #endregion
=======
        #region Get Appointment by Doctor ID and todays date
        public async Task<List<Appointmentview>> GetAppointmentsByDoctorIdandDate(int id)
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
                              where a.DoctorId == id && a.AppointmentDate == DateTime.Today
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
                              }).ToListAsync();  //FirstorDefaultAsync();
            }
            return null;
        }
        #endregion

        #region Get Appointment by Doctor for a date
        public async Task<List<Appointmentview>> getAppointmentsOnDate(int id, DateTime date)
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
                              where a.DoctorId == id && a.AppointmentDate == date
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
                              }).ToListAsync();  //FirstorDefaultAsync();
            }
            return null;
        }
        #endregion


>>>>>>> f382953f16efaa483bcce55d8881794d1af3f794
    }
}
