using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class LabBill
    {
        public LabBill()
        {
            Bill = new HashSet<Bill>();
        }

        public int LabBillId { get; set; }
        public int AppointmentId { get; set; }
        public int TestReportId { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual TestReport TestReport { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
