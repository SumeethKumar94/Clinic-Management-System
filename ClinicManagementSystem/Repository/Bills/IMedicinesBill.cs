using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModels.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Bills
{
    public interface IMedicinesBill
    {
        public Task<List<MedicineBillView>> GetAllMedicineBills();

        public Task<MedicineBillView> GetMedicineBillById(int id);
        public Task<MedicineBillView> GetMedicineBillByPhone(Int64 phone);
        Task<int> AddMedicineBill(MedicineBill consultationBill);
    }
}
