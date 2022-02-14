using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.MedicinesRepo
{
    public class MedicineDetailsRepository : IMedicineDetailsRepository
    {
        private readonly ClinicManagementSystemDBContext _contextThree;

        public MedicineDetailsRepository(ClinicManagementSystemDBContext contextThree)
        {
            _contextThree = contextThree;
        }

        #region add medicine details
        public async Task<int> AddMedicineDetails(MedicineDetails medicineDetails)
        {
            if (_contextThree != null)
            {
                await _contextThree.MedicineDetails.AddAsync(medicineDetails);
                await _contextThree.SaveChangesAsync();
                return medicineDetails.MedicineDetailsId;
            }
            return 0;          
        }
        #endregion

        #region update medicine details
        public async Task UpdateMedicineDetails(MedicineDetails medicineDetails)
        {
            if (_contextThree != null)
            {
                _contextThree.Entry(medicineDetails).State = EntityState.Modified;
                _contextThree.MedicineDetails.Update(medicineDetails);
                await _contextThree.SaveChangesAsync();
            }
        }
        #endregion

        #region view all medicine details
        #endregion

        /*
        #region view medicine details by id
        public async Task<ActionResult<MedicineDetails>> GetMedicineDetailsById(int? id)
        {
            if (_contextThree != null)
            {
                var testOne = await _contextThree.MedicineDetails.FindAsync(id);

                return testOne;
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
        */
    }
}
