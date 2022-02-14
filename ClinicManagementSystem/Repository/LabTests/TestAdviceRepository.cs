using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.LabTests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.LabTests
{
    public class TestAdviceRepository : ITestAdviceRepository
    {
        private readonly ClinicManagementSystemDBContext _contextThree;

        public TestAdviceRepository(ClinicManagementSystemDBContext contextThree)
        {
            _contextThree = contextThree;
        }

       

        #region get test advice
        public async Task<List<TestAdviceViewModel>> GetTestAdvice()
        {
            if (_contextThree != null)
            {
                return await (from tr in _contextThree.TestReport
                              join
                              td in _contextThree.TestDetails
                              on tr.TestReportId equals td.TestReportId
                              join
                              a in _contextThree.Appointment
                              on tr.AppointmentId equals a.AppointmentId

                              join
                              s in _contextThree.Staff
                              on a.DoctorId equals s.StaffId
                              join p in _contextThree.Patient
                              on a.PatientId equals p.PatientId 
                              select  new TestAdviceViewModel
                              {
                                  TestAdviceId = tr.TestReportId,

                                  DoctorName = " " + (from st in _contextThree.Staff
                                                      where st.StaffId == a.DoctorId
                                                      select st.FirstName).FirstOrDefault(),
                                  ReceptionistName = " " + (from stone in _contextThree.Staff
                                                            where stone.StaffId == a.ReceptionistId
                                                            select stone.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Mobile = p.Phone,
                                  AppointmentDate = a.AppointmentDate,
                                  TestName = (from trone in _contextThree.TestReport
                                              join tdone in _contextThree.TestDetails
                                              on trone.TestReportId equals tdone.TestReportId
                                              join tone in _contextThree.Test
                                              on tdone.TestId equals tone.TestId
                                              where trone.TestReportId == tr.TestReportId
                                              select tone.TestName).ToList()


                              }
                              ).Distinct().ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region getting test advice by id
        public async Task<TestAdviceViewModel> GetTestAdviceById(int id)
        {
            if (_contextThree != null)
            {
                return await(from tr in _contextThree.TestReport
                             join
                             td in _contextThree.TestDetails
                             on tr.TestReportId equals td.TestReportId
                             join
                             a in _contextThree.Appointment
                             on tr.AppointmentId equals a.AppointmentId

                             join
                             s in _contextThree.Staff
                             on a.DoctorId equals s.StaffId
                             join p in _contextThree.Patient
                             on a.PatientId equals p.PatientId
                             where tr.TestReportId == id
                             select new TestAdviceViewModel
                             {
                                 TestAdviceId = tr.TestReportId,

                                 DoctorName = " " + (from st in _contextThree.Staff
                                                     where st.StaffId == a.DoctorId
                                                     select st.FirstName).FirstOrDefault(),
                                 ReceptionistName = " " + (from stone in _contextThree.Staff
                                                           where stone.StaffId == a.ReceptionistId
                                                           select stone.FirstName).FirstOrDefault(),
                                 PatientName = p.PatientName,
                                 Mobile = p.Phone,
                                 AppointmentDate = a.AppointmentDate,
                                 TestName = (from trone in _contextThree.TestReport
                                             join tdone in _contextThree.TestDetails
                                             on trone.TestReportId equals tdone.TestReportId
                                             join tone in _contextThree.Test
                                             on tdone.TestId equals tone.TestId
                                             where trone.TestReportId == tr.TestReportId
                                             select tone.TestName).ToList()


                             }
                              ).FirstOrDefaultAsync(); 
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region get test advice by phone
        public async Task<TestAdviceViewModel> GetTestAdviceByPhone(long phone)
        {
            if (_contextThree != null)
            {
                return await (from tr in _contextThree.TestReport
                              join
                              td in _contextThree.TestDetails
                              on tr.TestReportId equals td.TestReportId
                              join
                              a in _contextThree.Appointment
                              on tr.AppointmentId equals a.AppointmentId

                              join
                              s in _contextThree.Staff
                              on a.DoctorId equals s.StaffId
                              join p in _contextThree.Patient
                              on a.PatientId equals p.PatientId
                              where p.Phone == phone
                              select new TestAdviceViewModel
                              {
                                  TestAdviceId = tr.TestReportId,

                                  DoctorName = " " + (from st in _contextThree.Staff
                                                      where st.StaffId == a.DoctorId
                                                      select st.FirstName).FirstOrDefault(),
                                  ReceptionistName = " " + (from stone in _contextThree.Staff
                                                            where stone.StaffId == a.ReceptionistId
                                                            select stone.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Mobile = p.Phone,
                                  AppointmentDate = a.AppointmentDate,
                                  TestName = (from trone in _contextThree.TestReport
                                              join tdone in _contextThree.TestDetails
                                              on trone.TestReportId equals tdone.TestReportId
                                              join tone in _contextThree.Test
                                              on tdone.TestId equals tone.TestId
                                              where trone.TestReportId == tr.TestReportId
                                              select tone.TestName).ToList()


                              }
                              ).FirstOrDefaultAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion


        #region add a test advice
        public async Task<int> AddTestAdvice(TestReport testReport)
        {
            if (_contextThree != null)
            {
                await _contextThree.TestReport.AddAsync(testReport);
                await _contextThree.SaveChangesAsync();
                return testReport.TestReportId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion

        #region update the test advice
        public async Task UpdateTestAdvice(TestReport testReport)
        {
            if (_contextThree != null)
            {
                _contextThree.Entry(testReport).State = EntityState.Modified;
                _contextThree.TestReport.Update(testReport);
                await _contextThree.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion

      
    }
}
