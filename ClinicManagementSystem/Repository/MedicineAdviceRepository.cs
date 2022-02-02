using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class MedicineAdviceRepository :IMedicineAdviceRepository
    {
        private readonly ClinicManagementSystemDBContext _context;

        //constructor based dependency injection
        public MedicineAdviceRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }
        #region Get all medicine advices
        public async Task<List<MedicineAdvice>> GetAllMedicineAdvicess()
        {
            if (_context != null)
            {
                return await _context.MedicineAdvice.ToListAsync();
            }
            return null;
        }
        #endregion

    }
}
