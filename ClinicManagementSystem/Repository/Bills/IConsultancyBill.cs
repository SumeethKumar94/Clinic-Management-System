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
        //view consultation bills
        public Task<List<SubBillView>> GetConsultancyAllBills();

        //view consultation bill by id
        public Task<SubBillView> GetConsultantionBillById(int id);

        //view consultation bill using patient mobile
        public Task<SubBillView> GetConsultantionBillByPhone(Int64 phone);

        //add consultation bill
        Task<int> AddConsulationBill(ConsultationBill consultationBill);

    }
}
