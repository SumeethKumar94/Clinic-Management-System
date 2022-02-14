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
        //view all lab bills
        public Task<List<LabBillView>> GetAllLabBills();

        //view lab bill by id
        public Task<LabBillView> GetLabBillById(int id);

        //view lab bill using patient mobile
        public Task<LabBillView> GetLabBillByPhone(Int64 phone);

        //add lab bill
        Task<int> AddLabBill(LabBill labBill);

        //update lab bill
        Task UpdateLabBill(TestDetails testDetails);
    }
}
