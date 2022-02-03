using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.DoctorsNotes
{
    public class DoctorsNotesRepository:IDoctorsNotesRepository
    {
        private readonly ClinicManagementSystemDBContext _context;
        public DoctorsNotesRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }
        #region GET ALL ROLES
        public async Task<List<DoctorNotes>> GetAllNotes()
        {
            if (_context != null)
            {
                //performing lambda expressions for many category scenario
                //return await _contextTwo.Role.Include(r => r.Role).ToListAsync();
                return await _context.DoctorNotes.ToListAsync();
            }
            return null;
        }

        #endregion

    }
}
