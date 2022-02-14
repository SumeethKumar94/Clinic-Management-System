using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.StaffRepo;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.StaffRepo
{
    public interface IStaffRepository
    {
        //get all staffs
        Task<List<StaffViewModel>> GetAllStaffs();

        //get staff by id
        Task<ActionResult<StaffViewModel>> GetStaff(int? staffId);

        //add a staff
        Task<ActionResult<Staff>> AddStaff(Staff staff);

        //update a post
        Task UpdateStaff(Staff staff);

        //delete a post
        Task<int> DeleteStaffById(int? staffId);


      




    }
}
