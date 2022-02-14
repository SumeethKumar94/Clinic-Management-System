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

namespace ClinicManagementSystem.Repository.StaffRepo

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
        public async Task<ActionResult<StaffViewModel>> GetStaff(int? staffId)
        {
            return await (
                              from s in _contextOne.Staff
                              join
                               r in _contextOne.Role
                              on s.RoleId equals r.RoleId
                              join
                              q in _contextOne.Qualifications
                              on s.QualificationsId equals q.QualificationsId
                              where s.StaffId == staffId
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
                ).FirstOrDefaultAsync();

        }


        #endregion

        #region add staff
        public async Task<ActionResult<Staff>> AddStaff(Staff staff)
        {
            if (_contextOne != null)
            {
                await _contextOne.Staff.AddAsync(staff);
                await _contextOne.SaveChangesAsync();
                return staff;
                
            }
            return null;
        }

        #endregion
        
        #region delete staff using id
        public async Task<int> DeleteStaffById(int? staffId)
        {
            // declare result
            int result = 0;
            if (_contextOne != null)
            {
                var item = await _contextOne.Staff.FirstOrDefaultAsync(u => u.StaffId == staffId);
                if (item != null)
                {
                    // perform delete
                    _contextOne.Staff.Remove(item);
                    result = await _contextOne.SaveChangesAsync(); // commit 
                    //return succcess;
                    result = 1;

                }
                return result;
            }
            return result;

            //throw new NotImplementedException();
        }
        #endregion
        
        #region update Staff
        public async Task UpdateStaff(Staff staff)
        {
            if (_contextOne != null)
            {
                _contextOne.Entry(staff).State = EntityState.Modified;
                _contextOne.Staff.Update(staff);
                await _contextOne.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion

    }
}
