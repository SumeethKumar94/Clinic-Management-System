using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    interface IMedicineAdviceRepository
    {
        //get all medicine advices
        Task<List<MedicineAdvice>> GetAllMedicineAdvicess();
    }
}
