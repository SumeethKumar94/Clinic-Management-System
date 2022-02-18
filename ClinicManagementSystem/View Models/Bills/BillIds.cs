using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models.Bills
{
    public class BillIds
    {
        public int AppointmentId { get; set; }
        public int ConsultancyBillId { get; set; }
        public int MedicineBillId { get; set; }

        public int LabTestBillId { get; set; }

        public long TotalAmount { get; set; }
    }
}
