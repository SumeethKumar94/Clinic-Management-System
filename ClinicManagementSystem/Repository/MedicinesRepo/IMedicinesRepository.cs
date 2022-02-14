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

        Task<List<Medicines>> GetAllMedicines();

        //Task<int> AddMedicines(Medicines medicine);
        //add medicines
        Task<int> AddMedicine(Medicines medicine);
        //Task<IActionResult> AddMedicine(Medicines medicine);



        //Task<Medicines> GetMedicineById(int id);
        Task<ActionResult<Medicines>> GetMedicineById(int? id);

        //delete medicine 
        Task<int> DeleteMedicine(int? id);

        //update medicine
        Task UpdateMedicine(Medicines medicine);





    }

}

