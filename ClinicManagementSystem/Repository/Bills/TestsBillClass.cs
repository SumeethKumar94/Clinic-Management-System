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
    public class TestsBillClass:ITestsBill
    {
        private readonly ClinicManagementSystemDBContext _contextone;
        public TestsBillClass(ClinicManagementSystemDBContext contextone)
        {
            _contextone = contextone;
        }
        #region Add Lab Bill
        public async Task<int> AddLabBill(LabBill labBill)
        {
            if (_contextone != null)
            {

                await _contextone.LabBill.AddAsync(labBill);
                await _contextone.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        #endregion
        #region Get all Lab Bill
        public async Task<List<LabBillView>> GetAllLabBills()
        {
            if (_contextone != null)
            {
                return await(from l in _contextone.LabBill
                             join advice in _contextone.TestReport
                             on l.TestReportId equals advice.TestReportId
                             join
                             a in _contextone.Appointment
                             on l.AppointmentId equals a.AppointmentId
                             join
                             p in _contextone.Patient
                             on a.PatientId equals p.PatientId
                             select new LabBillView
                             {
                                 LabBillId = l.LabBillId,
                                 DateOfReport =l.Date,
                                 AppointmentDate = a.AppointmentDate,
                                 ReceptionistName = "" + (from dc in _contextone.Staff
                                                          where dc.StaffId == a.ReceptionistId
                                                          select dc.FirstName).FirstOrDefault(),
                                 DoctorName = "" + (from dc in _contextone.Staff
                                                    where dc.StaffId == a.DoctorId
                                                    select dc.FirstName).FirstOrDefault(),
                                 PatientName = p.PatientName,
                                 Phone = p.Phone,
                                 BloodGroup = p.BloodGroup,
                                 LabTechnician = "" + (from dc in _contextone.Staff
                                                        where dc.StaffId == advice.LabTechnicianId
                                                        select dc.FirstName).FirstOrDefault(),
                                 TestReport = (from labadv in _contextone.TestReport
                                                  join labdetails in _contextone.TestDetails
                                                  on labadv.TestReportId equals labdetails.TestReportId
                                                  join tests in _contextone.Test
                                                  on labdetails.TestId equals tests.TestId
                                                  where labadv.TestReportId==l.TestReportId
                                                  select new TestsView
                                                  {
                                                      TestName=tests.TestName,
                                                      TestDescription=tests.TestDescription,
                                                      Unit=tests.Unit,
                                                      TestValue=labdetails.TestValue,
                                                      MinRange=tests.MinRange,
                                                      MaxRange=tests.MaxRange,
                                                      TotalAmount=tests.TotalAmount,
                                                     
                                                  }).ToList(),
                                 TotalAmount = l.TotalAmount
                             }).ToListAsync();
            }
            return null;
        }
        #endregion
        #region  Get  Lab Bill by Id
        public async Task<LabBillView> GetLabBillById(int id)
        {
            if (_contextone != null)
            {
                return await (from l in _contextone.LabBill
                              join advice in _contextone.TestReport
                              on l.TestReportId equals advice.TestReportId
                              join
                              a in _contextone.Appointment
                              on l.AppointmentId equals a.AppointmentId
                              join
                              p in _contextone.Patient
                              on a.PatientId equals p.PatientId
                              where l.LabBillId==id
                              select new LabBillView
                              {
                                  LabBillId = l.LabBillId,
                                  DateOfReport = l.Date,
                                  AppointmentDate = a.AppointmentDate,
                                  ReceptionistName = "" + (from dc in _contextone.Staff
                                                           where dc.StaffId == a.ReceptionistId
                                                           select dc.FirstName).FirstOrDefault(),
                                  DoctorName = "" + (from dc in _contextone.Staff
                                                     where dc.StaffId == a.DoctorId
                                                     select dc.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Phone = p.Phone,
                                  BloodGroup = p.BloodGroup,
                                  LabTechnician = "" + (from dc in _contextone.Staff
                                                        where dc.StaffId == advice.LabTechnicianId
                                                        select dc.FirstName).FirstOrDefault(),
                                  TestReport = (from labadv in _contextone.TestReport
                                                join labdetails in _contextone.TestDetails
                                                on labadv.TestReportId equals labdetails.TestReportId
                                                join tests in _contextone.Test
                                                on labdetails.TestId equals tests.TestId
                                                where labadv.TestReportId == l.TestReportId
                                                select new TestsView
                                                {
                                                    TestName = tests.TestName,
                                                    TestDescription = tests.TestDescription,
                                                    Unit = tests.Unit,
                                                    TestValue = labdetails.TestValue,
                                                    MinRange = tests.MinRange,
                                                    MaxRange = tests.MaxRange,
                                                    TotalAmount = tests.TotalAmount,

                                                }).ToList(),
                                  TotalAmount = l.TotalAmount
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
        #region Get  Lab Bill by Phone
        public async Task<LabBillView> GetLabBillByPhone(Int64 phone)
        {
            if (_contextone != null)
            {
                return await(from l in _contextone.LabBill
                             join advice in _contextone.TestReport
                             on l.TestReportId equals advice.TestReportId
                             join
                             a in _contextone.Appointment
                             on l.AppointmentId equals a.AppointmentId
                             join
                             p in _contextone.Patient
                             on a.PatientId equals p.PatientId
                             where p.Phone==phone
                             select new LabBillView
                             {
                                 LabBillId = l.LabBillId,
                                 DateOfReport = l.Date,
                                 AppointmentDate = a.AppointmentDate,
                                 ReceptionistName = "" + (from dc in _contextone.Staff
                                                          where dc.StaffId == a.ReceptionistId
                                                          select dc.FirstName).FirstOrDefault(),
                                 DoctorName = "" + (from dc in _contextone.Staff
                                                    where dc.StaffId == a.DoctorId
                                                    select dc.FirstName).FirstOrDefault(),
                                 PatientName = p.PatientName,
                                 Phone = p.Phone,
                                 BloodGroup = p.BloodGroup,
                                 LabTechnician = "" + (from dc in _contextone.Staff
                                                       where dc.StaffId == advice.LabTechnicianId
                                                       select dc.FirstName).FirstOrDefault(),
                                 TestReport = (from labadv in _contextone.TestReport
                                               join labdetails in _contextone.TestDetails
                                               on labadv.TestReportId equals labdetails.TestReportId
                                               join tests in _contextone.Test
                                               on labdetails.TestId equals tests.TestId
                                               where labadv.TestReportId == l.TestReportId
                                               select new TestsView
                                               {
                                                   TestName = tests.TestName,
                                                   TestDescription = tests.TestDescription,
                                                   Unit = tests.Unit,
                                                   TestValue = labdetails.TestValue,
                                                   MinRange = tests.MinRange,
                                                   MaxRange = tests.MaxRange,
                                                   TotalAmount = tests.TotalAmount,

                                               }).ToList(),
                                 TotalAmount = l.TotalAmount
                             }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
        #region Update Lab Bill
        public async Task UpdateLabBill(TestDetails testDetails)
        {
            if (_contextone != null)
            {
                _contextone.Entry(testDetails).State = EntityState.Modified;
                _contextone.TestDetails.Update(testDetails);
                await _contextone.SaveChangesAsync();
            }
        }
        #endregion
    }
}
