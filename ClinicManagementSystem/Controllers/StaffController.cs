using ClinicManagementSystem.Repository;
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

        //get post

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

        //get staff by id 

        [HttpGet("{staffId}")]
        //[Route("GetStaff")]
        public async Task<ActionResult<Staff>> GetStaff(int? staffId)
        {
            if (staffId == null)
            {
                return BadRequest();
            }
            try
            {
                var staffOne = await _staffRepository.GetStaff(staffId);
                if (staffOne == null)
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

        //add a staff
        //[HttpPost]
        //public async Task<IActionResult> AddStaff([FromBody] Staff staff)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var staffId = await _staffRepository, AddStaff(staff);
        //            if (staffId > 0)
        //            {
        //                return Ok(staffId);
        //            }
        //            return NotFound();
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    return BadRequest();
        //}

        //delete a staff




        [HttpDelete("{staffId}")]
        public async Task<IActionResult> DeleteStaffById(int? staffId)
        {
            int result = 0;
            if(staffId == null)
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
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




    }

   


}
