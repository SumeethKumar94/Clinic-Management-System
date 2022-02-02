using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    interface IMedicinesRepository
    {

        Task<List<Medicines>> GetAllMedicines();


        //public virtual ICollection<MedicineDetails> MedicineDetails { get; set; }
    }

}

