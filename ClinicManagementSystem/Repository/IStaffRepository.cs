using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IStaffRepository
    {
        //get all staffs
        Task<List<StaffViewModel>> GetAllStaffs();


        //get staff by id

        Task<Staff> GetStaff(int? staffId);

        //add a staff
        //Task<IActionResult> AddStaff([FromBody] Staff staff);

        //update a post

        //Task UpdateStaff(Staff staff)

        //delete a post
        Task<int> DeleteStaffById(int? staffId);




    }
}
