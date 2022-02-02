using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ClinicManagementSystemDBContext _contextTwo;

          public RoleRepository(ClinicManagementSystemDBContext contextTwo)
        {
            _contextTwo = contextTwo;
        }
        #region GET ALL ROLES
        public async Task<List<Role>> GetAllRoles()
        {
            if (_contextTwo != null)
            {
                //performing lambda expressions for many category scenario
                //return await _contextTwo.Role.Include(r => r.Role).ToListAsync();
                return await _contextTwo.Role.ToListAsync();
            }
            return null;
        }

        #endregion

        #region ADD A ROLE
        public async Task<int> AddRole(Role role)
        {
            if(_contextTwo != null)
            {
                await _contextTwo.Role.AddAsync(role);
                await _contextTwo.SaveChangesAsync();
                return role.RoleId;
            }
            return 0;
        }
        #endregion

        #region UPDATE A ROLE
        public async Task UpdateRole(Role role)
        {
            if (_contextTwo != null)
            {
                _contextTwo.Entry(role).State = EntityState.Modified;
                _contextTwo.Role.Update(role);
                await _contextTwo.SaveChangesAsync();
            }
        }
        #endregion
    }
}
