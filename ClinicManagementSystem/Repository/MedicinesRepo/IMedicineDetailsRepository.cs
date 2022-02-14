using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
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

        Task<List<MedicineListView>> GetMedicineDetails();

        Task<MedicineListView> GetMedicineDetailsById(int id);

        Task<MedicineListView> GetMedicineDetailsByname(string name);

        Task<MedicineListView> GetMedicineDetailsByPhone(Int64 phone);


    }
}
