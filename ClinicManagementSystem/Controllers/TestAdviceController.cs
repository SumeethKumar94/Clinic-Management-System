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
    public class TestAdviceController : ControllerBase
    {
        private readonly ITestAdviceRepository _testAdviceRepository;
        private readonly ClinicManagementSystemDBContext _context;

        public TestAdviceController(ITestAdviceRepository testAdviceRepository,ClinicManagementSystemDBContext cont)
        {
            _testAdviceRepository = testAdviceRepository;
            _context = cont;
        }


        #region get all test advice
        [HttpGet]
        [Route("GetTestDetails")]

        public async Task<IActionResult> GetTestAdvice()
        {
            
            try
            {
                var advice = await _testAdviceRepository.GetTestAdvice();
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

        #region  get test advice by id
        [HttpGet("{id}")]
        public async Task<ActionResult<TestAdviceViewModel>> GetTestAdviceById(int id)
        {
            try
            {
                var adviceTwo = await _testAdviceRepository.GetTestAdviceById(id);
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

        #region  get test advice by phone
        [HttpGet]
        [Route("GetTestDetailsByPhone/{phone}")]
        public async Task<ActionResult<TestAdviceViewModel>> GetTestAdviceByPhone(Int64 phone)
        {
            try
            {
                var adviceThree = await _testAdviceRepository.GetTestAdviceByPhone(phone);
                if (adviceThree == null)
                {
                    return NotFound();
                }
                return adviceThree;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region add a test Details
        [HttpPost]
        public async Task<IActionResult> AddTestAdvice([FromBody] TestDetails testDetails)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var adviceID = await _testAdviceRepository.AddTestAdvice(testDetails);
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

        #region update test Details
        [HttpPut]               
        public async Task<IActionResult> UpdateTestAdvice([FromBody] TestDetails testDetails)
        {
            //since it is frombody we need to check the validation of body , n lowda
            if (ModelState.IsValid)
            {
                try
                {
                    await _testAdviceRepository.UpdateTestAdvice(testDetails);
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
    }
}
