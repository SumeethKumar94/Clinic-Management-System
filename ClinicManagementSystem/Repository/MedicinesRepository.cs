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
        //#region add medicine
        //public async Task<IActionResult> AddMedicines([FromBody] Medicines medicine)

        //{
        //    if (_context != null)
        //    {

        //        await _context.Medicines.AddAsync(medicine);
        //        await _context.SaveChangesAsync();
        //        return Ok(medicine);
        //    }
        //    return ;

        //}


        //#endregion

        #region Add Medicine
        public async Task<int> AddMedicine(Medicines medicine)
        {
            if (_context != null)
            {
                await _context.Medicines.AddAsync(medicine);
                await _context.SaveChangesAsync(); // commit transaction
                return 1;
            }
            return 0;
            // throw new NotImplementedException();
        }
        #endregion


        #region get employee by id
        public async Task<ActionResult<Medicines>> GetMedicineById(int? id)
        {
            if (_context != null)
            {
                var employee = await _context.Medicines.FindAsync(id);
                return employee;
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion


        #region Medicine by Id
        //[HttpGet]
        //public async Task<Medicines> GetMedicineById(int id)
        //{
        //    if (_context != null)
        //    {
        //        return await (from m in _context.Medicines
        //                      where m.MedicineId==id
        //                      select new Medicines()
        //                      ).FirstOrDefaultAsync();
        //    }
        //    return null;
        //}
        #endregion

        


    }

}
