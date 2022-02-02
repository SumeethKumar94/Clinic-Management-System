using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModels.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Bills
{
    public interface IConsultancyBill
    {
        public Task<List<SubBillView>> GetConsultancyAllBills();

        public Task<SubBillView> GetConsultantionBillById(int id);
        public Task<SubBillView> GetConsultantionBillByPhone(Int64 phone);
        Task<int> AddConsulationBill(ConsultationBill consultationBill);
 

    }
}
