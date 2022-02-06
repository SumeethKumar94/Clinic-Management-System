using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IMedicineAdviceRepository
    {
        //get all medicine advices
        Task<List<MedicineAdviceView>> GetAllMedicineAdvicess();
    }
}
