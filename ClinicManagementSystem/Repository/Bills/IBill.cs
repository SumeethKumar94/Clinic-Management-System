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
        //view all bills
        public Task<List<FinalBillView>> GetAllBills();

        //view bill by id
        public Task<FinalBillView> GetBillById(int id);

        //view bill using patient mobile
        public Task<FinalBillView> GetBillByPhone(Int64 phone);

        //add bill
        Task<int> AddBill(Bill bill);
    }
}
