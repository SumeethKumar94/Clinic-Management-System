using ClinicManagementSystem.Repository;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        //data fields
        private readonly IRoleRepository _roleRepo;

        public RoleController(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        #region get roles
        [HttpGet]
        public async Task<List<Role>> GetRoles()
        {
            //LINQ
            if (_roleRepo != null)
            {
                return await _roleRepo.GetRoles();
            }
            return null;
        }

        #endregion

        #region get role by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetROle(int? id)
        {
            try
            {
                return await _roleRepo.GetROle(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

    }
}
