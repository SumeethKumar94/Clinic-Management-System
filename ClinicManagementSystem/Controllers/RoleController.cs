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
        private readonly ClinicManagementSystemDBContext _roleRepository;

        public RoleController(ClinicManagementSystemDBContext roleRepository)
        {
            _roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {
            //LINQ
            if (_roleRepository != null)
            {
                return await _roleRepository.Role.ToListAsync();
            }
            return null;
        }
    }
}
