using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.LabTests;
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

        private readonly ITestAdviceRepository _testPrescriptionRepository;
        private readonly ClinicManagementSystemDBContext _context;

        public TestReportController(ITestAdviceRepository testPrescriptionRepository, ClinicManagementSystemDBContext cont)
        {
            _testPrescriptionRepository = testPrescriptionRepository;
            _context = cont;
        }

        
       

       


        #region get all test advices (prescriptions)
        [HttpGet]
       // [Route("GetTestDetails")]

        public async Task<IActionResult> GetTestAdvice()
        {
            
            try
            {
                var advice = await _testPrescriptionRepository.GetTestAdvice();
                if (advice == null)
                {
                    return NotFound();
                }
                return Ok(advice);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region  get test advice (prescription) by id
        [HttpGet("{id}")]
        public async Task<ActionResult<TestAdviceViewModel>> GetTestAdviceById(int id)
        {
            try
            {
                var adviceTwo = await _testPrescriptionRepository.GetTestAdviceById(id);
                if (adviceTwo == null)
                {
                    return NotFound();
                }
                return adviceTwo;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region  get test advice (prescription) by phone
        [HttpGet]
        [Route("GetTestDetailsByPhone/{phone}")]
        public async Task<ActionResult<TestAdviceViewModel>> GetTestAdviceByPhone(Int64 phone)
        {
            try
            {
                var prescription = await _testPrescriptionRepository.GetTestAdviceByPhone(phone);
                if (prescription == null)
                {
                    return NotFound();
                }
                return prescription;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        #region add a test advice (prescription)
        [HttpPost]
        public async Task<IActionResult> AddTestAdvice([FromBody] TestReport testReport)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var prescriptionID = await _testPrescriptionRepository.AddTestAdvice(testReport);
                    if (prescriptionID > 0)
                    {
                        return Ok(prescriptionID);
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

        #region update test advice(prescription)

        [HttpPut]               
        public async Task<IActionResult> UpdateTestAdvice([FromBody] TestReport testReport)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    await _testPrescriptionRepository.UpdateTestAdvice(testReport);
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

        #region Patch Lab  Test Details
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchLabTest(int id, [FromBody] JsonPatchDocument<TestDetails> patchEntity)
        {
            if (id > 0)
            {

                var testdetail = await _context.TestDetails.FirstOrDefaultAsync(u => u.TestDetailId == id);
                if (testdetail == null)
                {
                    return BadRequest();
                }

                patchEntity.ApplyTo(testdetail, ModelState);

                _context.TestDetails.Update(testdetail);
                await _context.SaveChangesAsync();
                return Ok(testdetail);
            }
            return BadRequest();
        }

        #endregion
    }
}
