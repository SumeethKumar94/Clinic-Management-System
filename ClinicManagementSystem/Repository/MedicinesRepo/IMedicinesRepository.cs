using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IMedicinesRepository
    {
        //view all medicines
        Task<List<Medicines>> GetAllMedicines();
       
        //add medicines
        Task<int> AddMedicine(Medicines medicine);
        
        //view medicine by id
        Task<ActionResult<Medicines>> GetMedicineById(int? id);

        //delete medicine 
        Task<int> DeleteMedicine(int? id);

        //update medicine
        Task UpdateMedicine(Medicines medicine);
        Task<MedicineStock> GetMedicineStockByName(string id);

        //Task<MedicineStock> GetMedicineStockByName(string id);

    }

}

