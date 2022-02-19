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

        Task<MedicineAdviceView> GetMedicineAdvicebyId(int id);
        Task<MedicineAdviceView> GetMedicineAdvicebyPhone(Int64 phone);
        Task<MedicineAdviceView> GetMedicineAdvicebyName(string named);

        Task<int> AddMedicineAdvice(MedicineAdvice medicineAdvice);
        Task UpdateMedicineAdvice(MedicineAdvice medicineAdvice);
        Task<MedicineAdviceView> GetMedicineAdvicebyPatientId(int id);
    }
}
