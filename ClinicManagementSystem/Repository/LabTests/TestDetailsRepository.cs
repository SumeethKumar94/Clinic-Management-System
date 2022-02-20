using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.LabTests
{
    public class TestDetailsRepository: ITestDetailsRepository
    {
        private readonly ClinicManagementSystemDBContext _contextFive;

        public TestDetailsRepository(ClinicManagementSystemDBContext contextFive)
        {
            _contextFive = contextFive;
        }

        #region add test report details
        public async Task<int> AddTestReportDetails(TestDetails testDetails)
        {
            if (_contextFive != null)
            {
                await _contextFive.TestDetails.AddAsync(testDetails);
                await _contextFive.SaveChangesAsync();
                return testDetails.TestDetailId;
            }
            return 0;
        }
        #endregion

        #region update test report details
        public async Task UpdateTestReportDetails(TestDetails testDetails)
        {
            if (_contextFive != null)
            {
                _contextFive.Entry(testDetails).State = EntityState.Modified;
                _contextFive.TestDetails.Update(testDetails);
                await _contextFive.SaveChangesAsync();
            }
        }
        #endregion
        /*
        #region view all test report details
        public async Task<List<TestReportViewModel>> GetMedicineDetails()
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
        */

    }
}
