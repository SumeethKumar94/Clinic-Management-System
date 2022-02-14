using ClinicManagementSystem.Models;
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
                             join
                             c in _contextone.ConsultationBill
                             on b.ConsultancyBillId equals c.ConsultationBillId
                             join
                             a in _contextone.Appointment on c.AppointmentId equals a.AppointmentId
                             join 
                             p in _contextone.Patient 
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
                return await(from b in _contextone.Bill
                             join
                             c in _contextone.ConsultationBill
                             on b.ConsultancyBillId equals c.ConsultationBillId
                             join
                             a in _contextone.Appointment on c.AppointmentId equals a.AppointmentId
                             join
                             p in _contextone.Patient
                             on a.PatientId equals p.PatientId
                             where b.BillId==id
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
        #region Get  Bills by Phone
        public async Task<FinalBillView> GetBillByPhone(Int64 phone)
        {
            if (_contextone != null)
            {
                return await (from b in _contextone.Bill
                              join
                              c in _contextone.ConsultationBill
                              on b.ConsultancyBillId equals c.ConsultationBillId
                              join
                              a in _contextone.Appointment on c.AppointmentId equals a.AppointmentId
                              join
                              p in _contextone.Patient
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
    }
}
