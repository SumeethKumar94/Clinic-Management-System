using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int ConsultancyBillId { get; set; }
        public int? MedicineBillId { get; set; }
        public int? LabTestBillId { get; set; }
        public DateTime BillDate { get; set; }
        public int TotalAmount { get; set; }

        public virtual ConsultationBill ConsultancyBill { get; set; }
        public virtual LabBill LabTestBill { get; set; }
        public virtual MedicineBill MedicineBill { get; set; }
    }
}
