using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    interface IRoleRepository
    {
        //public int RoleId { get; set; }
        //public string Role1 { get; set; }

        //get all roles
        Task<List<Role>> GetAllRoles();

        //add a role
        Task<int> AddRole(Role role);

        //update a role
        Task UpdateRole(Role role);
    }
}
