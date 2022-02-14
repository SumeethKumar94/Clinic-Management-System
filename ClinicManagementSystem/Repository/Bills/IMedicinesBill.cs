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
        //view all medicines bills
        public Task<List<MedicineBillView>> GetAllMedicineBills();
         
        //view medicine bill by id
        public Task<MedicineBillView> GetMedicineBillById(int id);

        //view medicine bill using patient mobile
        public Task<MedicineBillView> GetMedicineBillByPhone(Int64 phone);

        //add medicine bill
        Task<int> AddMedicineBill(MedicineBill consultationBill);
    }
}
