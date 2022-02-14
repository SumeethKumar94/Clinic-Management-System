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
        Task<List<Role>> GetRoles();

        Task<ActionResult<Role>> GetROle(int? id);
    }
}
