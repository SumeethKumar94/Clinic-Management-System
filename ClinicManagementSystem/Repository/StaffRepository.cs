using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

namespace ClinicManagementSystem.Repository
{
    public class StaffRepository :IStaffRepository
    {
        //data fields

        private readonly ClinicManagementSystemDBContext _contextOne;

        //constructor based dependency injection
        public StaffRepository(ClinicManagementSystemDBContext contextOne)
        {
            _contextOne = contextOne;
        }

        #region Get all staffs
        [HttpGet]
        public async Task<List<StaffViewModel>> GetAllStaffs()
        {
            //LINQ
            if(_contextOne != null)
            {
                //return await _contextOne.Staff.ToListAsync();

                //return await _contextOne.StaffViewModel.ToListAsync();
                return await (
                              from s in _contextOne.Staff
                              join
                               r in _contextOne.Role
                              on s.RoleId equals r.RoleId
                              join
                              q in _contextOne.Qualifications
                              on s.QualificationsId equals q.QualificationsId

                              select new StaffViewModel
                              {
                                  StaffId = s.StaffId,
                                  FirstName = s.FirstName,
                                  LastName = s.LastName,
                                  Phone = s.Phone,
                                  Address = s.Address,
                                  DateOfBirth = s.DateOfBirth,
                                  QualificationsId = s.QualificationsId,
                                  Qualification = q.Qualification,
                                  RoleId = r.RoleId,
                                  Role1 = r.Role1
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion

        #region get staff by id
        public async Task<Staff> GetStaff(int? staffId)
        {
            return await (
                from s in _contextOne.Staff
                where s.StaffId == staffId
                select new Staff
                {
                    StaffId = s.StaffId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Phone = s.Phone,
                    Address = s.Address,
                    DateOfBirth = s.DateOfBirth,
                    QualificationsId = s.QualificationsId,
                    RoleId = s.RoleId
                }
                ).FirstOrDefaultAsync();

            //return await (
            //              from s in _contextOne.Staff
            //              join
            //               r in _contextOne.Role
            //              on s.RoleId equals r.RoleId
            //              join 
            //               q in _contextOne.Qualifications
            //              on s.QualificationsId equals q.QualificationsId
            //              where s.StaffId == staffId
            //              select new StaffViewModel
            //              {
            //                  StaffId = s.StaffId,
            //                  FirstName = s.FirstName,
            //                  LastName = s.LastName,
            //                  Phone = s.Phone,
            //                  Address = s.Address,
            //                  DateOfBirth = s.DateOfBirth,
            //                  QualificationsId = s.QualificationsId,
            //                  Qualification = q.Qualification ,
            //                  RoleId = r.RoleId,
            //                  Role1 = r.Role1
            //              }
            //              ).FirstOrDefault();
        }


        #endregion

        #region add staff
        //public async Task<IActionResult> AddStaff([FromBody] Staff staff)
        //{
        //    if(_contextOne != null)
        //    {
        //        await _contextOne.Staff.AddAsync(staff);
        //        await _contextOne.SaveChangesAsync();
        //        return staff.StaffId;
        //    }
        //    return 0;
        //}

        #endregion

        #region update a post
        //public async Task UpdateStaff(Staff staff)
        //{
        //    _contextOne.Entry(staff).State = EntityState.Modified;
        //    _contextOne.Staff.Update(staff);
        //    await _contextOne.SaveChangesAsync();
        //}
        #endregion

        #region delete a post
        public async Task<int> DeleteStaffById(int? staffId)
        {
            //declare result 
            int result = 0;
            if (_contextOne != null)
            {
                var staff = await _contextOne.Staff.FirstOrDefaultAsync(st => st.StaffId == staffId);
                if (staff != null)
                {
                    //perform delete
                    _contextOne.Staff.Remove(staff);
                    result = await _contextOne.SaveChangesAsync(); //commit
                }
                return result;
            }
            return result;
        }
        #endregion
    }
}
