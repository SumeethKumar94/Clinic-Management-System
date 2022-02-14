using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModels.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Bills
{
    public interface IBill
    {
        public Task<List<FinalBillView>> GetAllBills();

        public Task<FinalBillView> GetBillById(int id);
        public Task<FinalBillView> GetBillByPhone(Int64 phone);
        Task<int> AddBill(Bill bill);
    }
}
