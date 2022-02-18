using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.Bills;
using ClinicManagementSystem.ViewModels.Bills;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Bills
{
    public class BillClass:IBill
    {
        private readonly ClinicManagementSystemDBContext _contextone;
        public BillClass(ClinicManagementSystemDBContext contextone)
        {
            _contextone = contextone;
        }

        public async  Task<int> AddBill(Bill bill)
        {
            if (_contextone != null)
            {

                await _contextone.Bill.AddAsync(bill);
                await _contextone.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        #region Get All Bills
        public async Task<List<FinalBillView>> GetAllBills()
        {
            if (_contextone != null)
            {
                return await(from b in _contextone.Bill
                            join c in _contextone.ConsultationBill
                            on b.ConsultancyBillId equals c.ConsultationBillId
                            join a in _contextone.Appointment 
                            on c.AppointmentId equals a.AppointmentId
                            join  p in _contextone.Patient 
                            on a.PatientId equals p.PatientId
                            select new FinalBillView
                             {
                                 BillId = b.BillId,
                                 BillDate = b.BillDate,
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
                                 ConsultationFee = c.TotalAmount,
                                 MedicinesFee= (from m in _contextone.MedicineBill
                                               where m.MedicineBillId == b.MedicineBillId
                                                select m.TotalAmount).FirstOrDefault(),
                                 LabTestsFee = (from l in _contextone.LabBill
                                                where l.LabBillId == b.LabTestBillId
                                                select l.TotalAmount).FirstOrDefault(),
                                 TotalAmount= b.TotalAmount


                             }).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Get Bill by ID
        public async Task<FinalBillView> GetBillById(int id)
        {
            if (_contextone != null)
            {
                return await (from b in _contextone.Bill
                             join c in _contextone.ConsultationBill
                             on b.ConsultancyBillId equals c.ConsultationBillId
                             join a in _contextone.Appointment 
                             on c.AppointmentId equals a.AppointmentId
                             join p in _contextone.Patient
                             on a.PatientId equals p.PatientId
                             where b.BillId==id
                             select new FinalBillView
                             {
                                 BillId =b.BillId,
                                 BillDate =b.BillDate,
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
                                 ConsultationFee = c.TotalAmount,
                                 MedicinesFee = (from m in _contextone.MedicineBill
                                                where m.MedicineBillId == b.MedicineBillId
                                                 select m.TotalAmount).FirstOrDefault(),
                                 LabTestsFee = (from l in _contextone.LabBill
                                               where l.LabBillId == b.LabTestBillId
                                                select l.TotalAmount).FirstOrDefault(),
                                 TotalAmount = b.TotalAmount


                             }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        #region Get  Bills by Phone
        public async Task<FinalBillView> GetBillByPhone(Int64 phone)
        {
            if (_contextone != null)
            {
                return await (from b in _contextone.Bill
                              join c in _contextone.ConsultationBill
                              on b.ConsultancyBillId equals c.ConsultationBillId
                             join a in _contextone.Appointment 
                             on c.AppointmentId equals a.AppointmentId
                             join p in _contextone.Patient
                              on a.PatientId equals p.PatientId
                              where p.Phone==phone
                              select new FinalBillView
                              {
                                  BillId = b.BillId,
                                  BillDate = b.BillDate,
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
                                  ConsultationFee = c.TotalAmount,
                                  MedicinesFee = (from m in _contextone.MedicineBill
                                                  where m.MedicineBillId == b.MedicineBillId
                                                  select m.TotalAmount).FirstOrDefault(),
                                  LabTestsFee = (from l in _contextone.LabBill
                                                 where l.LabBillId == b.LabTestBillId
                                                 select l.TotalAmount).FirstOrDefault(),
                                  TotalAmount = b.TotalAmount
                              

                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion


        #region Get  Bills by ID
        public async Task<List<FinalBillView>> GetBillByAppointment()
        {
            if (_contextone != null)
            {
                return await (
                              from c in _contextone.ConsultationBill
                              join a in _contextone.Appointment
                              on c.AppointmentId equals a.AppointmentId
                              join p in _contextone.Patient
                               on a.PatientId equals p.PatientId
                              where a.Status==4
                              select new FinalBillView
                              {
                                  BillId = c.AppointmentId,
                                  BillDate = (DateTime)c.DateOfBill,
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
                                  ConsultationFee = c.TotalAmount,

                                  MedicinesFee = (from m in _contextone.MedicineBill
                                                  join medadv in _contextone.MedicineAdvice
                                                  on m.MedicineAdviceId equals medadv.MedicineAdviceId
                                                  where m.AppointmentId== a.AppointmentId
                                                  select m.TotalAmount).FirstOrDefault(),
                                  LabTestsFee = (from l in _contextone.LabBill
                                                 join b in _contextone.TestReport on
                                                 l.TestReportId equals b.TestReportId
                                                 where b.AppointmentId == a.AppointmentId
                                                 select l.TotalAmount).FirstOrDefault(),
                                  MedDone=(int)(from medadv in _contextone.MedicineAdvice
                                                 where medadv.AppointmentId == a.AppointmentId
                                                 select medadv.Status).FirstOrDefault(),
                                  LabDone=(int) (
                                               from  b in _contextone.TestReport 
                                               where b.AppointmentId == a.AppointmentId
                                                 select b.Status).FirstOrDefault(),
                                  TotalAmount =0


                              }).ToListAsync();
            }
            return null;
        }
        #endregion

        public async Task<BillIds> GetBillByAppointmentID(int id)
        {
            if (_contextone != null)
            {
                return await (
                              from c in _contextone.ConsultationBill
                              join a in _contextone.Appointment
                              on c.AppointmentId equals a.AppointmentId
                              join p in _contextone.Patient
                               on a.PatientId equals p.PatientId
                              where a.Status == 4 && a.AppointmentId==id
                              select new BillIds
                              {
                                  AppointmentId = c.AppointmentId,
                                  
                                  ConsultancyBillId= c.ConsultationBillId,

                                  MedicineBillId = (from m in _contextone.MedicineBill
                                                  join medadv in _contextone.MedicineAdvice
                                                  on m.MedicineAdviceId equals medadv.MedicineAdviceId
                                                  where m.AppointmentId == a.AppointmentId
                                                  select m.MedicineBillId).FirstOrDefault(),
                                  LabTestBillId = (from l in _contextone.LabBill
                                                 join b in _contextone.TestReport on
                                                 l.TestReportId equals b.TestReportId
                                                 where b.AppointmentId == a.AppointmentId
                                                 select l.LabBillId).FirstOrDefault(),
                                
                                  TotalAmount = (c.TotalAmount+(int)(from l in _contextone.LabBill
                                                                join b in _contextone.TestReport on
                                                                l.TestReportId equals b.TestReportId
                                                                where b.AppointmentId == a.AppointmentId
                                                                select l.TotalAmount).FirstOrDefault())+((int)(from m in _contextone.MedicineBill
                                                                                                        join medadv in _contextone.MedicineAdvice
                                                                                                        on m.MedicineAdviceId equals medadv.MedicineAdviceId
                                                                                                        where m.AppointmentId == a.AppointmentId
                                                                                                        select m.TotalAmount).FirstOrDefault())

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        }
}
