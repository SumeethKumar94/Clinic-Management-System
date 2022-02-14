using ClinicManagementSystem.Models;
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

        #endregion
    }
}
