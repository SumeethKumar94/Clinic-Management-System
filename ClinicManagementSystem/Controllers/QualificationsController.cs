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
    public class QualificationsController : ControllerBase
    {
        //data fields
        private readonly ClinicManagementSystemDBContext _qualificationsRepository;

        public QualificationsController(ClinicManagementSystemDBContext qualificationsRepository)
        {
            _qualificationsRepository = qualificationsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qualifications>>> GetAllQualifications()
        {
            //LINQ
            if (_qualificationsRepository != null)
            {
                return await _qualificationsRepository.Qualifications.ToListAsync();
            }
            return null;
        }
    }
}
