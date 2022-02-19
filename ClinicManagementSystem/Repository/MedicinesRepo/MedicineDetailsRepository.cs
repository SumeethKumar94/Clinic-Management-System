using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.MedicinesRepo
{
    public class MedicineDetailsRepository : IMedicineDetailsRepository
    {
        private readonly ClinicManagementSystemDBContext _contextThree;

        public MedicineDetailsRepository(ClinicManagementSystemDBContext contextThree)
        {
            _contextThree = contextThree;
        }

        #region add medicine details
        public async Task<int> AddMedicineDetails(MedicineDetails medicineDetails)
        {
            if (_contextThree != null)
            {
                await _contextThree.MedicineDetails.AddAsync(medicineDetails);
                await _contextThree.SaveChangesAsync();
                return medicineDetails.MedicineDetailsId;
            }
            return 0;          
        }
        #endregion

        #region update medicine details
        public async Task UpdateMedicineDetails(MedicineDetails medicineDetails)
        {
            if (_contextThree != null)
            {
                _contextThree.Entry(medicineDetails).State = EntityState.Modified;
                _contextThree.MedicineDetails.Update(medicineDetails);
                await _contextThree.SaveChangesAsync();
            }
        }
        #endregion

        #region view all medicine details
        public async Task<List<MedicineListView>> GetMedicineDetails()
        {
            if (_contextThree != null)
            {
                return await (from med in _contextThree.MedicineDetails
                              join
                              madv in _contextThree.MedicineAdvice
                              on med.MedicineAdviceId equals madv.MedicineAdviceId
                              join
                              a in _contextThree.Appointment
                              on madv.AppointmentId equals a.AppointmentId
                              join
                              s in _contextThree.Staff
                              on a.DoctorId equals s.StaffId
                              join p in _contextThree.Patient
                              on a.PatientId equals p.PatientId
                              select new MedicineListView
                              {
                                  PatientId = p.PatientId,
                                  PatientName = p.PatientName,
                                  DateOfPrescription = a.AppointmentDate,
                                  DoctorsId = s.StaffId,
                                  DoctorsName = " "+(from stf in _contextThree.Staff where stf.StaffId == a.DoctorId select stf.FirstName).FirstOrDefault(),
                                  Medicines = (from med in _contextThree.Medicines
                                               join
                                                medadv in _contextThree.MedicineDetails on med.MedicineId equals medadv.MedicineId
                                               select new MedicinesView
                                               {
                                                   Medicine = med.MedicineName,
                                                   MedicineDescription = med.MedicineDescription,
                                                   MedicinePrice = med.MedicinePrice,
                                                   Quantity = medadv.Quantity,
                                                   Dose = med.Dose
                                               }).ToList()
                              }).Distinct().ToListAsync();

            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion


        #region view medicine details by id

        public async Task<MedicineListView> GetMedicineDetailsById(int id)
        {
              if (_contextThree != null)
                {
                return await (from med in _contextThree.MedicineDetails
                              join
                              madv in _contextThree.MedicineAdvice
                              on med.MedicineAdviceId equals madv.MedicineAdviceId
                              join
                              a in _contextThree.Appointment
                              on madv.AppointmentId equals a.AppointmentId
                              join
                              s in _contextThree.Staff
                              on a.DoctorId equals s.StaffId
                              join p in _contextThree.Patient
                              on a.PatientId equals p.PatientId
                              where med.MedicineId==id
                              select new MedicineListView
                              {
                                  PatientId = p.PatientId,
                                  PatientName = p.PatientName,
                                  DateOfPrescription = a.AppointmentDate,
                                  DoctorsId = s.StaffId,
                                  DoctorsName = (from stf in _contextThree.Staff where stf.StaffId == a.DoctorId select stf.FirstName).ToString(),
                                  Medicines = (from med in _contextThree.Medicines
                                               join
           medadv in _contextThree.MedicineDetails on med.MedicineId equals medadv.MedicineId
                                               select new MedicinesView
                                               {
                                                   Medicine = med.MedicineName,
                                                   MedicineDescription = med.MedicineDescription,
                                                   MedicinePrice = med.MedicinePrice,
                                                   Quantity = medadv.Quantity,
                                                   Dose = med.Dose
                                               }).ToList()
                              }).FirstOrDefaultAsync();
          
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
      
       

        #region Get Medicine Details by Customer Name
        public async Task<MedicineListView> GetMedicineDetailsByname(string name)
        {
            if (_contextThree != null)
            {
                return await(from med in _contextThree.MedicineDetails
                             join
                             madv in _contextThree.MedicineAdvice
                             on med.MedicineAdviceId equals madv.MedicineAdviceId
                             join
                             a in _contextThree.Appointment
                             on madv.AppointmentId equals a.AppointmentId
                             join
                             s in _contextThree.Staff
                             on a.DoctorId equals s.StaffId
                             join p in _contextThree.Patient
                             on a.PatientId equals p.PatientId
                             where p.PatientName==name
                             select new MedicineListView
                             {
                                 PatientId = p.PatientId,
                                 PatientName = p.PatientName,
                                 DateOfPrescription = a.AppointmentDate,
                                 DoctorsId = s.StaffId,
                                 DoctorsName = (from stf in _contextThree.Staff where stf.StaffId == a.DoctorId select stf.FirstName).ToString(),
                                 Medicines = (from med in _contextThree.Medicines
                                              join
          medadv in _contextThree.MedicineDetails on med.MedicineId equals medadv.MedicineId
                                              select new MedicinesView
                                              {
                                                  Medicine = med.MedicineName,
                                                  MedicineDescription = med.MedicineDescription,
                                                  MedicinePrice = med.MedicinePrice,
                                                  Quantity = medadv.Quantity,
                                                  Dose = med.Dose
                                              }).ToList()
                             }).FirstOrDefaultAsync();

            }
            return null;
        }
        #endregion
        #region Medicine Details by Phone
        public async Task<MedicineListView> GetMedicineDetailsByPhone(Int64 phone)
        {
            if (_contextThree != null)
            {
                return await(from med in _contextThree.MedicineDetails
                             join
                             madv in _contextThree.MedicineAdvice
                             on med.MedicineAdviceId equals madv.MedicineAdviceId
                             join
                             a in _contextThree.Appointment
                             on madv.AppointmentId equals a.AppointmentId
                             join
                             s in _contextThree.Staff
                             on a.DoctorId equals s.StaffId
                             join p in _contextThree.Patient
                             on a.PatientId equals p.PatientId
                             where p.Phone==phone
                             select new MedicineListView
                             {
                                 PatientId = p.PatientId,
                                 PatientName = p.PatientName,
                                 DateOfPrescription = a.AppointmentDate,
                                 DoctorsId = s.StaffId,
                                 DoctorsName = (from stf in _contextThree.Staff where stf.StaffId == a.DoctorId select stf.FirstName).ToString(),
                                 Medicines = (from med in _contextThree.Medicines
                                              join
          medadv in _contextThree.MedicineDetails on med.MedicineId equals medadv.MedicineId
                                              select new MedicinesView
                                              {
                                                  Medicine = med.MedicineName,
                                                  MedicineDescription = med.MedicineDescription,
                                                  MedicinePrice = med.MedicinePrice,
                                                  Quantity = medadv.Quantity,
                                                  Dose = med.Dose
                                              }).ToList()
                             }).FirstOrDefaultAsync();

            }
            return null;
        }
        #endregion

    }
}
