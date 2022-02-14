using ClinicManagementSystem.Repository.StaffRepo;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementSystem.View_Models;

namespace ClinicManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        //data fields
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        #region view all staffs
        [HttpGet]
        public async Task<List<StaffViewModel>> GetAllStaffs()
        {
            //LINQ
            if (_staffRepository != null)
            {
                return await _staffRepository.GetAllStaffs();
            }
            return null;
        }
        #endregion

        #region view staff by id
        [HttpGet("{staffId}")]
        //[Route("GetStaff")]
        public async Task<ActionResult<StaffViewModel>> GetStaff(int? staffId)
        {
            return await _staffRepository.GetStaff(staffId);
        }
        #endregion

        #region add a staff
        [HttpPost]
        public async  Task<IActionResult> AddStaff([FromBody] Staff staff)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _staffRepository.UpdateStaff(staff);
                    return Ok(staff);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region delete staff by id
        [HttpDelete("{staffId}")]
        public async Task<IActionResult> DeleteStaffById(int? staffId)
        {
            int result = 0;
            if (staffId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _staffRepository.DeleteStaffById(staffId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok("delete successfull");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region update a staff
        [HttpPut]
        public async Task<IActionResult> UpdateStaff([FromBody] Staff staff)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _staffRepository.UpdateStaff(staff);
                    return Ok(staff);
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
