using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModels.Bills;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClinicManagementSystem.Repository.Bills
{
    public class ConsultancyBillClass:IConsultancyBill
    {
        private readonly ClinicManagementSystemDBContext _contextone;
        public ConsultancyBillClass(ClinicManagementSystemDBContext contextone)
        {
            _contextone = contextone;
        }
        #region Add Consultation Bill
        public async Task<int> AddConsulationBill(ConsultationBill consultationBill)
        {
            if (_contextone != null)
            {

                await _contextone.ConsultationBill.AddAsync(consultationBill);
                await _contextone.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        #endregion
        #region Get Consultation Bills
        public async Task<List<SubBillView>> GetConsultancyAllBills()
        {
            if (_contextone != null)
            {
                return await(from c in _contextone.ConsultationBill
                             join
                             a in _contextone.Appointment
                             on c.AppointmentId equals a.AppointmentId
                             join
                             p in _contextone.Patient 
                             on a.PatientId equals p.PatientId
                             select new  SubBillView
                             {
                              ConsultationBillId=c.ConsultationBillId,
                              DateOfBill=c.DateOfBill,
                              AppointmentDate=a.AppointmentDate,
                              ReceptionistName= "" + (from dc in _contextone.Staff
                                                      where dc.StaffId == a.ReceptionistId
                                                      select dc.FirstName).FirstOrDefault(),
                              DoctorName= "" + (from dc in _contextone.Staff
                                                where dc.StaffId == a.DoctorId
                                                select dc.FirstName).FirstOrDefault(),
                              PatientName=p.PatientName,
                              Phone=p.Phone,
                              Address=p.Address,
                              DateOfBirth=p.DateOfBirth,
                              BloodGroup=p.BloodGroup,
                              ConsultationAmount=c.TotalAmount
                               }).ToListAsync();
            }
            return null;
        }
        #endregion
        #region Get Consultation By ID
        [HttpGet]
        public async Task<SubBillView> GetConsultantionBillById(int id)
        {
            if (_contextone != null)
            {
                return await (from c in _contextone.ConsultationBill
                              join
                              a in _contextone.Appointment
                              on c.AppointmentId equals a.AppointmentId
                              join
                              p in _contextone.Patient
                              on a.PatientId equals p.PatientId
                              where c.ConsultationBillId==id
                              select new SubBillView
                              {
                                  ConsultationBillId = c.ConsultationBillId,
                                  DateOfBill = c.DateOfBill,
                                  AppointmentDate = a.AppointmentDate,
                                  ReceptionistName = "" + (from dc in _contextone.Staff
                                                           where dc.StaffId == a.ReceptionistId
                                                           select dc.FirstName).FirstOrDefault(),
                                  DoctorName = "" + (from dc in _contextone.Staff
                                                     where dc.StaffId == a.DoctorId
                                                     select dc.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Phone = p.Phone,
                                  Address = p.Address,
                                  DateOfBirth = p.DateOfBirth,
                                  BloodGroup = p.BloodGroup,
                                  ConsultationAmount = c.TotalAmount
                              }).FirstOrDefaultAsync();
            }
            return null;

        }
        #endregion
        #region Get Consultation Bills By Phone
        [HttpGet]
        public async Task<SubBillView> GetConsultantionBillByPhone(Int64  phone)
        {
            if (_contextone != null)
            {
                return await (from c in _contextone.ConsultationBill
                              join
                              a in _contextone.Appointment
                              on c.AppointmentId equals a.AppointmentId
                              join
                              p in _contextone.Patient
                              on a.PatientId equals p.PatientId
                              where p.Phone == phone
                              select new SubBillView
                              {
                                  ConsultationBillId = c.ConsultationBillId,
                                  DateOfBill = c.DateOfBill,
                                  AppointmentDate = a.AppointmentDate,
                                  ReceptionistName = "" + (from dc in _contextone.Staff
                                                           where dc.StaffId == a.ReceptionistId
                                                           select dc.FirstName).FirstOrDefault(),
                                  DoctorName = "" + (from dc in _contextone.Staff
                                                     where dc.StaffId == a.DoctorId
                                                     select dc.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Phone = p.Phone,
                                  Address = p.Address,
                                  DateOfBirth = p.DateOfBirth,
                                  BloodGroup = p.BloodGroup,
                                  ConsultationAmount = c.TotalAmount
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
    }
}
