using ClinicManagementSystem.Repository;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QualificationsController : ControllerBase
    {
        //data fields
        private readonly IQualificationsRepository _qualification;

        public QualificationsController(IQualificationsRepository qualification)
        {
            _qualification = qualification;
        }


        #region get qualifications
        [HttpGet]
        public async Task<List<Qualifications>> GetQualifications()
        {
            //LINQ
            if (_qualification != null)
            {
                return await _qualification.GetQualifications();
            }
            return null;
        }

        #endregion

        #region get qualification by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Qualifications>> GetQualification(int? id)
        {
            try
            {
                return await _qualification.GetQualification(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Add a qualification
        [HttpPost]
        public async Task<IActionResult> AddMedicines([FromBody] Qualifications qualification)
        {
            // check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var qualifications = await _qualification.AddQualification(qualification);
                    if (qualifications > 0)
                    {
                        return Ok(qualification);
                    }
                    else
                    {
                        return NotFound();
                    }
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
