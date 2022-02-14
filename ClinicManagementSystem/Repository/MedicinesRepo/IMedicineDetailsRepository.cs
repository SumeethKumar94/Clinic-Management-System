using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.MedicinesRepo
{
    public interface IMedicineDetailsRepository
    {
        //add medicine details
        Task<int> AddMedicineDetails(MedicineDetails medicineDetails);

        //update appointment
        Task UpdateMedicineDetails(MedicineDetails medicineDetails);

        //view all medicine details
        

    }
}
