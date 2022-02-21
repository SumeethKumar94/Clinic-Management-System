using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.Bills;
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
        //Task<FinalBillView> GetBillByAppointment(int id);
        Task<List<FinalBillView>> GetBillByAppointment();
        Task<BillIds> GetBillByAppointmentID(int id);
    }
}
