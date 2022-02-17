using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class MedicineAdviceRepository :IMedicineAdviceRepository
    {
        private readonly ClinicManagementSystemDBContext _context;

        //constructor based dependency injection
        public MedicineAdviceRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }
        #region Add Medicine Advices
        public async Task<int> AddMedicineAdvice(MedicineAdvice medicineAdvice)
        {
            if (_context != null)
            {
                await _context.MedicineAdvice.AddAsync(medicineAdvice);
                await _context.SaveChangesAsync();
                return medicineAdvice.MedicineAdviceId;
            }
            return 0;
        }
        #endregion

        #region Get all medicine advices
        public async Task<List<MedicineAdviceView>> GetAllMedicineAdvicess()
        {
            if (_context != null)
            {
                return await (from s in _context.Staff
                              join p in _context.Appointment on s.StaffId equals p.DoctorId
                              join a in _context.Patient on p.PatientId equals a.PatientId
                              join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                              join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                              join md in _context.Medicines on ml.MedicineId equals md.MedicineId
                              select new MedicineAdviceView
                              {
                                  AppointmentId = p.AppointmentId,
                                  PatientId = p.PatientId,
                                  Patient = a.PatientName,
                                  medicineList = (from s in _context.Staff
                                                  join p in _context.Appointment on s.StaffId equals p.DoctorId
                                                  join a in _context.Patient on p.PatientId equals a.PatientId
                                                  join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                                                  join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                                                  join mde in _context.Medicines on ml.MedicineId equals mde.MedicineId
                                                  where p.AppointmentId == m.AppointmentId
                                                  select new MedicinesView
                                                  {
                                                      Medicine = mde.MedicineName,
                                                      MedicineDescription = mde.MedicineDescription,
                                                      MedicinePrice = mde.MedicinePrice,
                                                      Dose=mde.Dose,
                                                      Quantity=ml.Quantity,


                                                  }
                                  ).ToList()
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Get Medicine Advice by ID
        public async Task<MedicineAdviceView> GetMedicineAdvicebyId(int id)
        {
            if (_context != null)
            {
                return await(from s in _context.Staff
                             join p in _context.Appointment on s.StaffId equals p.DoctorId
                             join a in _context.Patient on p.PatientId equals a.PatientId
                             join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                             join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                             join md in _context.Medicines on ml.MedicineId equals md.MedicineId
                             where m.MedicineAdviceId==id
                             select new MedicineAdviceView
                             {
                                 AppointmentId = p.AppointmentId,
                                 PatientId = p.PatientId,
                                 Patient = a.PatientName,
                                 medicineList = (from s in _context.Staff
                                                 join p in _context.Appointment on s.StaffId equals p.DoctorId
                                                 join a in _context.Patient on p.PatientId equals a.PatientId
                                                 join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                                                 join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                                                 join mde in _context.Medicines on ml.MedicineId equals mde.MedicineId
                                                 where p.AppointmentId == m.AppointmentId
                                                 select new MedicinesView
                                                 {
                                                     Medicine = mde.MedicineName,
                                                     MedicineDescription = mde.MedicineDescription,
                                                     MedicinePrice = mde.MedicinePrice,
                                                     Dose = mde.Dose,
                                                     Quantity = ml.Quantity,


                                                 }
                                 ).ToList()
                             }
                              ).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        #region Get Medicine Advice  by Name
        public async Task<MedicineAdviceView> GetMedicineAdvicebyName(string name)
        {
            if (_context != null)
            {
                return await(from s in _context.Staff
                             join p in _context.Appointment on s.StaffId equals p.DoctorId
                             join a in _context.Patient on p.PatientId equals a.PatientId
                             join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                             join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                             join md in _context.Medicines on ml.MedicineId equals md.MedicineId
                             where a.PatientName == name
                             select new MedicineAdviceView
                             {
                                 AppointmentId = p.AppointmentId,
                                 PatientId = p.PatientId,
                                 Patient = a.PatientName,
                                 medicineList = (from s in _context.Staff
                                                 join p in _context.Appointment on s.StaffId equals p.DoctorId
                                                 join a in _context.Patient on p.PatientId equals a.PatientId
                                                 join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                                                 join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                                                 join mde in _context.Medicines on ml.MedicineId equals mde.MedicineId
                                                 where p.AppointmentId == m.AppointmentId
                                                 select new MedicinesView
                                                 {
                                                     Medicine = mde.MedicineName,
                                                     MedicineDescription = mde.MedicineDescription,
                                                     MedicinePrice = mde.MedicinePrice,
                                                     Dose = mde.Dose,
                                                     Quantity = ml.Quantity,


                                                 }
                                 ).ToList()
                             }
                              ).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        # region Get Medicine Advice by Phone
        public async Task<MedicineAdviceView> GetMedicineAdvicebyPhone(Int64 phone)
        {
            if (_context != null)
            {
                return await(from s in _context.Staff
                             join p in _context.Appointment on s.StaffId equals p.DoctorId
                             join a in _context.Patient on p.PatientId equals a.PatientId
                             join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                             join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                             join md in _context.Medicines on ml.MedicineId equals md.MedicineId
                             where a.Phone == phone
                             select new MedicineAdviceView
                             {
                                 AppointmentId = p.AppointmentId,
                                 PatientId = p.PatientId,
                                 Patient = a.PatientName,
                                 medicineList = (from s in _context.Staff
                                                 join p in _context.Appointment on s.StaffId equals p.DoctorId
                                                 join a in _context.Patient on p.PatientId equals a.PatientId
                                                 join m in _context.MedicineAdvice on p.AppointmentId equals m.AppointmentId
                                                 join ml in _context.MedicineDetails on m.MedicineAdviceId equals ml.MedicineAdviceId
                                                 join mde in _context.Medicines on ml.MedicineId equals mde.MedicineId
                                                 where p.AppointmentId == m.AppointmentId
                                                 select new MedicinesView
                                                 {
                                                     Medicine = mde.MedicineName,
                                                     MedicineDescription = mde.MedicineDescription,
                                                     MedicinePrice = mde.MedicinePrice,
                                                     Dose = mde.Dose,
                                                     Quantity = ml.Quantity,


                                                 }
                                 ).ToList()
                             }
                              ).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        #region Update Medicine Advice
        public async Task UpdateMedicineAdvice(MedicineAdvice medicineAdvice)
        {
            if (_context != null)
            {
                _context.Entry(medicineAdvice).State = EntityState.Modified;
                _context.MedicineAdvice.Update(medicineAdvice);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
