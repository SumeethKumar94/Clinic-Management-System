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

        #region get medicine by id
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

        #region delete Medicine
        public async Task<int> DeleteMedicine(int? id)
        {
            // declare result
            int result = 0;
            if (_context != null)
            {
                var medicine = await _context.Medicines.FirstOrDefaultAsync(u => u.MedicineId == id);
                if (medicine != null)
                {
                    // perform delete
                    _context.Medicines.Remove(medicine);
                    result = await _context.SaveChangesAsync(); // commit 
                    //return succcess;
                    result = 1;

                }
                return result;
            }
            return result;

            //throw new NotImplementedException();
        }
        #endregion

        #region update Medicine
        public async Task UpdateMedicine(Medicines medicine)
        {
            if (_context != null)
            {
                _context.Entry(medicine).State = EntityState.Modified;
                _context.Medicines.Update(medicine);
                await _context.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region GET Medicine Stock
        public async Task<MedicineStock> GetMedicineStockByName(string id)
        {
            if (_context != null)
            {
                return await (from a in _context.Medicines
                              where a.MedicineName == id
                              select new MedicineStock
                              {
                                  Stock = a.Stock
                              }

                ).FirstOrDefaultAsync();                            
            };
            return null;
        }



        #endregion

    }
}
