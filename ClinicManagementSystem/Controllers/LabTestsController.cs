using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.LabTests;
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
    public class LabTestsController : ControllerBase
    {
        private readonly ILabTestsRepository _labTestsRepository;

        public LabTestsController(ILabTestsRepository labTestsRepository)
        {
            _labTestsRepository = labTestsRepository;
        }

        #region get all tests
        [HttpGet]
        [Route("GetAllTests")]
        
        public async Task<ActionResult<IEnumerable<Test>>> GetAllTests()
        {
            return await _labTestsRepository.GetAllTests();
        }
        #endregion

        #region get test details by id
        [HttpGet("{id}")]

        public async Task<ActionResult<Test>> GetTestById(int? id)
        {
            try
            {
                var userThree = await _labTestsRepository.GetTestById(id);
                if (userThree == null)
                {
                    return NotFound();
                }
                return userThree;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        #region get test details by name
        [HttpGet]
        [Route("GetLabTestByName/{name}")]

        public async Task<ActionResult<IEnumerable<Patient>>> GetLabTestByName(string name)
        {
            try
            {
                var resultTwo = await _labTestsRepository.GetLabTestByTestName(name);
                if (resultTwo == null)
                {
                    return NotFound();
                }
                return Ok(resultTwo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        #region Add a Test
        [HttpPost]
        public async Task<IActionResult> AddTest([FromBody] Test test)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var testID = await _labTestsRepository.AddTest(test);
                    if (testID > 0)
                    {
                        return Ok(testID);
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


        #region update a test
        [HttpPut]
        public async Task<IActionResult> UpdateTest([FromBody] Test test)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _labTestsRepository.UpdateTest(test);
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


        #region delete a test
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _labTestsRepository.DeleteTest(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
