using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class MedicinesRepository : IMedicinesRepository
    {
        private readonly ClinicManagementSystemDBContext _context;

        public MedicinesRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }
        #region GET ALL Medicine
        public async Task<List<Medicines>> GetAllMedicines()
        {
            if(_context != null)
            {
                return await _context.Medicines.ToListAsync();
            }
            return null;
        }
        


        #endregion



    }
    
}
