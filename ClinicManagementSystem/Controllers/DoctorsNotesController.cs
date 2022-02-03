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
    public class DoctorsNotesController : Controller
    {
        //data fields
        private readonly ClinicManagementSystemDBContext _context;

        public DoctorsNotesController(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }

        //httpget
        [HttpGet]
        public async Task<List<DoctorNotes>> GetDoctorsNotes()
        {
            //LINQ
            if (_context != null)
            {
                return await _context.DoctorNotes.ToListAsync();
            }
            return null;


        }




    }
}
