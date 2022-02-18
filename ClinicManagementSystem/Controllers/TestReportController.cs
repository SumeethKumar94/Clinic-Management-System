using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.LabTests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestReportController : ControllerBase
    {
        private readonly ClinicManagementSystemDBContext context;
        public TestReportController(ClinicManagementSystemDBContext cont)
        {
            context = cont;
        }

        #region View  All Test Report
        [HttpGet]
        public async Task<List<TestReportView>> GetTestReports()
        {
            if (context != null)
            {
                return await (from tr in context.TestReport
                              join
                              td in context.TestDetails
                              on tr.TestReportId equals td.TestReportId
                              join
                              a in context.Appointment
                              on tr.AppointmentId equals a.AppointmentId
                              join
                              s in context.Staff
                              on a.DoctorId equals s.StaffId
                              join p in context.Patient
                              on a.PatientId equals p.PatientId
                              where tr.Status==1
                              select new TestReportView
                              {
                                  TestReportId = tr.TestReportId,

                                  DoctorName = " " + (from st in context.Staff
                                                      where st.StaffId == a.DoctorId
                                                      select st.FirstName).FirstOrDefault(),
                                  ReceptionistName = " " + (from stone in context.Staff
                                                            where stone.StaffId == a.ReceptionistId
                                                            select stone.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Mobile = p.Phone,
                                  Sex = p.Sex,
                                  AppointmentDate = a.AppointmentDate,
                                  TestDetails = (
                                                 from labdetails in context.TestDetails
                                                 join tests in context.Test
                                                 on labdetails.TestId equals tests.TestId
                                                 where tr.TestReportId == labdetails.TestReportId  //|| labdetails.TestValue<=1
                                                 select new TestValueView
                                                 {
                                                     TestName = tests.TestName,
                                                     TestDescription = tests.TestDescription,
                                                     Unit = tests.Unit,
                                                     TestValue = labdetails.TestValue,
                                                     MinRange = tests.MinRange,
                                                     MaxRange = tests.MaxRange
                                                 }).ToList()
                              }).Distinct().ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
        #region View  All Test Report by Test Report ID
        [HttpGet("{id}")]
        public async Task<TestReportView> GetTestReportsById(int id)
        {
            if (context != null)
            {
                return await (from tr in context.TestReport
                              join
                              td in context.TestDetails
                              on tr.TestReportId equals td.TestReportId
                              join
                              a in context.Appointment
                              on tr.AppointmentId equals a.AppointmentId
                              join
                              s in context.Staff
                              on a.DoctorId equals s.StaffId
                              join p in context.Patient
                              on a.PatientId equals p.PatientId
                              where tr.TestReportId==id
                              select new TestReportView
                              {
                                  TestReportId = tr.TestReportId,
                                  AppointmentId=a.AppointmentId,

                                  DoctorName = " " + (from st in context.Staff
                                                      where st.StaffId == a.DoctorId
                                                      select st.FirstName).FirstOrDefault(),
                                  ReceptionistName = " " + (from stone in context.Staff
                                                            where stone.StaffId == a.ReceptionistId
                                                            select stone.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Mobile = p.Phone,
                                  Sex = p.Sex,

                                  AppointmentDate = a.AppointmentDate,
                                  TestDetails = (
                                                 from labdetails in context.TestDetails
                                                 join tests in context.Test
                                                 on labdetails.TestId equals tests.TestId
                                                 where tr.TestReportId == labdetails.TestReportId  //|| labdetails.TestValue<=1
                                                 select new TestValueView
                                                 {
                                                     TestId=labdetails.TestDetailId,
                                                     TestName = tests.TestName,
                                                     TestDescription = tests.TestDescription,
                                                     Unit = tests.Unit,
                                                     TestValue = labdetails.TestValue,
                                                     MinRange = tests.MinRange,
                                                     MaxRange = tests.MaxRange,
                                                     Price= tests.TotalAmount
                                                 }).ToList()
                              }).FirstOrDefaultAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
        #region View Test Report By name
        [HttpGet]
        [Route("Name/{name}")]
        public async Task<TestReportView> GetTestReportsByName(string name )
        {
            if (context != null)
            {
                return await (from tr in context.TestReport
                              join
                              td in context.TestDetails
                              on tr.TestReportId equals td.TestReportId
                              join
                              a in context.Appointment
                              on tr.AppointmentId equals a.AppointmentId

                              join
                              s in context.Staff
                              on a.DoctorId equals s.StaffId
                              join p in context.Patient
                              on a.PatientId equals p.PatientId
                              where p.PatientName == name
                              select new TestReportView
                              {
                                  TestReportId = tr.TestReportId,

                                  DoctorName = " " + (from st in context.Staff
                                                      where st.StaffId == a.DoctorId
                                                      select st.FirstName).FirstOrDefault(),
                                  ReceptionistName = " " + (from stone in context.Staff
                                                            where stone.StaffId == a.ReceptionistId
                                                            select stone.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Mobile = p.Phone,
                                  Sex = p.Sex,
                                  AppointmentDate = a.AppointmentDate,
                                  TestDetails = (from labadv in context.TestReport
                                                 join labdetails in context.TestDetails
                                                 on labadv.TestReportId equals labdetails.TestReportId
                                                 join tests in context.Test
                                                 on labdetails.TestId equals tests.TestId
                                                 where labadv.TestReportId == labdetails.TestReportId
                                                 select new TestValueView
                                                 {
                                                     TestName = tests.TestName,
                                                     TestDescription = tests.TestDescription,
                                                     Unit = tests.Unit,
                                                     TestValue = labdetails.TestValue,
                                                     MinRange = tests.MinRange,
                                                     MaxRange = tests.MaxRange
                                                 }).ToList()
                                                 } ).FirstOrDefaultAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
        #region View Test Report by Phone
        [Route("Phone/{phone}")]
        [HttpGet]
        public async Task<TestReportView> GetTestReportByPhone(long phone)
        {
            if (context != null)
            {
                return await (from tr in context.TestReport
                              join
                              td in context.TestDetails
                              on tr.TestReportId equals td.TestReportId
                              join
                              a in context.Appointment
                              on tr.AppointmentId equals a.AppointmentId
                              join
                              s in context.Staff
                              on a.DoctorId equals s.StaffId
                              join p in context.Patient
                              on a.PatientId equals p.PatientId
                              where p.Phone == phone
                              select new TestReportView
                              {
                                  TestReportId = tr.TestReportId,

                                  DoctorName = " " + (from st in context.Staff
                                                      where st.StaffId == a.DoctorId
                                                      select st.FirstName).FirstOrDefault(),
                                  ReceptionistName = " " + (from stone in context.Staff
                                                            where stone.StaffId == a.ReceptionistId
                                                            select stone.FirstName).FirstOrDefault(),
                                  PatientName = p.PatientName,
                                  Sex = p.Sex,
                                  Mobile = p.Phone,
                                  AppointmentDate = a.AppointmentDate,
                                  TestDetails = (from labadv in context.TestReport
                                                 join labdetails in context.TestDetails
                                                 on labadv.TestReportId equals labdetails.TestReportId
                                                 join tests in context.Test
                                                 on labdetails.TestId equals tests.TestId
                                                 where labadv.TestReportId == labdetails.TestReportId
                                                 select new TestValueView
                                                 {
                                                     TestName = tests.TestName,
                                                     TestDescription = tests.TestDescription,
                                                     Unit = tests.Unit,
                                                     TestValue = labdetails.TestValue,
                                                     MinRange = tests.MinRange,
                                                     MaxRange = tests.MaxRange
                                                 }).ToList()
                              }).FirstOrDefaultAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region add a test report
        [HttpPost]
        public async Task<IActionResult> AddTestReport([FromBody] TestReport testReport)
        {
            var adviceID = 0;
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    if (context != null)
                    {
                        await context.TestReport.AddAsync(testReport);
                        await context.SaveChangesAsync();
                         adviceID= testReport.TestReportId;
                    }

                    if (adviceID > 0)
                    {
                        return Ok(adviceID);
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update Test Report
        [HttpPut]
        public async Task<ActionResult>UpdateTestReport([FromBody] TestReport testReport)
            {
            if (ModelState.IsValid)
            {
                try
                {
                      if (context != null)
                    {
                        context.Entry(testReport).State = EntityState.Modified;
                        context.TestReport.Update(testReport);
                        await context.SaveChangesAsync();
                    }
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
        #endregion


        #region Patch Lab  Test Report
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchLabTest(int id, [FromBody] JsonPatchDocument<TestReport> patchEntity)
        {
            if (id > 0)
            {

                var testdetail = await context.TestReport.FirstOrDefaultAsync(u => u.TestReportId == id);
                if (testdetail == null)
                {
                    return BadRequest();
                }

                patchEntity.ApplyTo(testdetail, ModelState);

                context.TestReport.Update(testdetail);
                await context.SaveChangesAsync();
                return Ok(testdetail);
            }
            return BadRequest();
        }
        #endregion

    }
}
