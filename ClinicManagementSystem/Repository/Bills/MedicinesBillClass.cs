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
    public class MedicinesBillClass:IMedicinesBill
    {
        private readonly ClinicManagementSystemDBContext _contextone;
        public MedicinesBillClass(ClinicManagementSystemDBContext contextone)
        {
            _contextone = contextone;
        }
        #region Add Medicine Bill
        public async Task<int> AddMedicineBill(MedicineBill medicineBill)
        {
            if (_contextone != null)
            {

                await _contextone.MedicineBill.AddAsync(medicineBill);
                await _contextone.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        #endregion

        #region Get all Medicine Bill
        public async  Task<List<MedicineBillView>> GetAllMedicineBills()
        {
            if (_contextone != null)
            {
                return await(from m in _contextone.MedicineBill
                             join advice in _contextone.MedicineAdvice
                             on m.MedicineAdviceId equals advice.MedicineAdviceId
                             join
                             a in _contextone.Appointment
                             on m.AppointmentId equals a.AppointmentId
                             join
                             p in _contextone.Patient
                             on a.PatientId equals p.PatientId
                             select new MedicineBillView
                             {
                                 MedicineBillId = m.MedicineBillId,
                                 DateOfBill = m.MedicineBillDate,
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
                                 PharmacistName = "" + (from dc in _contextone.Staff
                                                        where dc.StaffId == advice.PharmacistId
                                                        select dc.FirstName).FirstOrDefault(),
                                 MedicinesList = (from medadv in _contextone.MedicineAdvice
                                                  join medicinedetails in _contextone.MedicineDetails
                                                  on medadv.MedicineAdviceId equals medicinedetails.MedicineAdviceId
                                                  join medicine in _contextone.Medicines
                                                  on medicinedetails.MedicineId equals medicine.MedicineId
                                                  where medicinedetails.MedicineAdviceId==m.MedicineAdviceId
                                                  select new MedicineView
                                                  {
                                                      MedicineName = medicine.MedicineName,
                                                      MedicineDescription = medicine.MedicineDescription,
                                                      MedicinePrice = medicine.MedicinePrice,
                                                      Quantity=medicinedetails.Quantity,
                                                      Rate = medicine.MedicinePrice * medicinedetails.Quantity,
                                                      Dose = medicine.Dose
                                                  }).ToList(),
                                 TotalAmount = m.TotalAmount
                             }).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Medicine Bill by Id
        [HttpGet]
        public async Task<MedicineBillView> GetMedicineBillById(int id)
        {
            if (_contextone != null)
            {
                return await (from m in _contextone.MedicineBill
                              join advice in _contextone.MedicineAdvice
                              on m.MedicineAdviceId equals advice.MedicineAdviceId
                              join
                              a in _contextone.Appointment
                              on m.AppointmentId equals a.AppointmentId
                              join
                              p in _contextone.Patient
                              on a.PatientId equals p.PatientId
                              where m.MedicineBillId==id
                              select new MedicineBillView
                              {
                                  MedicineBillId = m.MedicineBillId,
                                  DateOfBill = m.MedicineBillDate,
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
                                  PharmacistName = "" + (from dc in _contextone.Staff
                                                         where dc.StaffId == advice.PharmacistId
                                                         select dc.FirstName).FirstOrDefault(),
                                  MedicinesList = (from medadv in _contextone.MedicineAdvice
                                                   join medicinedetails in _contextone.MedicineDetails
                                                   on medadv.MedicineAdviceId equals medicinedetails.MedicineAdviceId
                                                   join medicine in _contextone.Medicines
                                                   on medicinedetails.MedicineId equals medicine.MedicineId
                                                   where medicinedetails.MedicineAdviceId == m.MedicineAdviceId
                                                   select new MedicineView
                                                   {
                                                       MedicineName = medicine.MedicineName,
                                                       MedicineDescription = medicine.MedicineDescription,
                                                       MedicinePrice = medicine.MedicinePrice,
                                                       Quantity = medicinedetails.Quantity,
                                                       Rate= medicine.MedicinePrice* medicinedetails.Quantity,
                                                       Dose = medicine.Dose
                                                   }).ToList(),
                                  TotalAmount = m.TotalAmount
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        #region Medicine Bill by Phone
        [HttpGet]
        public async Task<MedicineBillView> GetMedicineBillByPhone(long phone)
        {
            if (_contextone != null)
            {
                return await(from m in _contextone.MedicineBill
                             join advice in _contextone.MedicineAdvice
                             on m.MedicineAdviceId equals advice.MedicineAdviceId
                             join
                             a in _contextone.Appointment
                             on m.AppointmentId equals a.AppointmentId
                             join
                             p in _contextone.Patient
                             on a.PatientId equals p.PatientId
                             where p.Phone==phone
                             select new MedicineBillView
                             {
                                 MedicineBillId = m.MedicineBillId,
                                 DateOfBill = m.MedicineBillDate,
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
                                 PharmacistName = "" + (from dc in _contextone.Staff
                                                        where dc.StaffId == advice.PharmacistId
                                                        select dc.FirstName).FirstOrDefault(),
                                 MedicinesList = (from medadv in _contextone.MedicineAdvice
                                                  join medicinedetails in _contextone.MedicineDetails
                                                  on medadv.MedicineAdviceId equals medicinedetails.MedicineAdviceId
                                                  join medicine in _contextone.Medicines
                                                  on medicinedetails.MedicineId equals medicine.MedicineId
                                                  where medicinedetails.MedicineAdviceId == m.MedicineAdviceId
                                                  select new MedicineView
                                                  {
                                                      MedicineName = medicine.MedicineName,
                                                      MedicineDescription = medicine.MedicineDescription,
                                                      MedicinePrice = medicine.MedicinePrice,
                                                      Quantity = medicinedetails.Quantity,
                                                      Rate = medicine.MedicinePrice * medicinedetails.Quantity,
                                                      Dose = medicine.Dose
                                                  }).ToList(),
                                 TotalAmount = m.TotalAmount
                             }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
    }
}
