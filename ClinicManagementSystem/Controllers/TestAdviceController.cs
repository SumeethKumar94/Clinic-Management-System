using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.LabTests;
using ClinicManagementSystem.View_Models.LabTests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public TestAdviceController(ITestAdviceRepository testAdviceRepository)
        {
            _testAdviceRepository = testAdviceRepository;
        }


        #region get all test advice
        [HttpGet]
        [Route("GetTestAdvice")]

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
        [Route("GetTestAdviceByPhone/{phone}")]
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


        #region add a test advice
        [HttpPost]
        public async Task<IActionResult> AddTestAdvice([FromBody] TestReport testReport)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var adviceID = await _testAdviceRepository.AddTestAdvice(testReport);
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


        #region update test advice
        [HttpPut]               
        public async Task<IActionResult> UpdateTestAdvice([FromBody] TestReport testReport)
        {
            //since it is frombody we need to check the validation of body , n lowda
            if (ModelState.IsValid)
            {
                try
                {
                    await _testAdviceRepository.UpdateTestAdvice(testReport);
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
