using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModels.Bills;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Bills
{
    public interface ITestsBill
    {
        public Task<List<LabBillView>> GetAllLabBills();
        public Task<LabBillView> GetLabBillById(int id);
        public Task<LabBillView> GetLabBillByPhone(Int64 phone);
        Task<int> AddLabBill(LabBill labBill);
        Task UpdateLabBill(TestDetails testDetails);
    }
}
