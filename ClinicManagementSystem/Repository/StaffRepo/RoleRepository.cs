using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ClinicManagementSystemDBContext _context;

          public RoleRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }

        #region GET ALL ROLES
        public async Task<List<Role>> GetRoles()
        {
            if (_context != null)
            {
                //performing lambda expressions for many category scenario
                //return await _contextTwo.Role.Include(r => r.Role).ToListAsync();
                return await _context.Role.ToListAsync();
            }
            return null;
        }

        #endregion

        #region get Roles by id
        public async Task<ActionResult<Role>> GetROle(int? id)
        {
            if (_context != null)
            {
                var role = await _context.Role.FindAsync(id);
                return role;
            }
            return null;
            //throw new NotImplementedException();
        }

        public async Task<List<RoleView>> GetRolesStaff(int id)
        {
            if (_context != null)
            {
                var role = await (from r in _context.Role
                                  join s in _context.Staff
                                 on r.RoleId equals s.RoleId
                                  where r.RoleId == id
                                  select new RoleView
                                  {
                                      StaffId = s.StaffId,
                                      Name = s.FirstName + " " + s.LastName

                                  }).ToListAsync();
                return role;
            }
            return null;
        }

        #endregion
    }
}
