using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class QualificationsRepository:IQualificationsRepository
    {
        private readonly ClinicManagementSystemDBContext _context;

        public QualificationsRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }

        #region GET ALL Qualifications
        public async Task<List<Qualifications>> GetQualifications()
        {
            if (_context != null)
            {
                return await _context.Qualifications.ToListAsync();
            }
            return null;
        }

        #endregion

        #region Add Qualifications
        public async Task<int> AddQualification(Qualifications qualification)
        {
            if (_context != null)
            {
                await _context.Qualifications.AddAsync(qualification);
                await _context.SaveChangesAsync(); // commit transaction
                return 1;
            }
            return 0;
            // throw new NotImplementedException();
        }
        #endregion

        #region get qualification by id
        public async Task<ActionResult<Qualifications>> GetQualification(int? id)
        {
            if (_context != null)
            {
                var qualification = await _context.Qualifications.FindAsync(id);
                return qualification;
            }
            return null;
            //throw new NotImplementedException();
        }

        #endregion

        
    }
}
