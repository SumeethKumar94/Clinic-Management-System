using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IRoleRepository
    {
        //view roles
        Task<List<Role>> GetRoles();
        Task<List<RoleView>> GetRolesStaff(int id);

        //view role by id
        Task<ActionResult<Role>> GetROle(int? id);
    }
}
