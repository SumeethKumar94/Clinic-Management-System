using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class TestReport
    {
        public TestReport()
        {
            LabBill = new HashSet<LabBill>();
            TestDetails = new HashSet<TestDetails>();
        }

        public int TestReportId { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int LabTechnicianId { get; set; }
        public int TestAmount { get; set; }
        public int? Status { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Staff Doctor { get; set; }
        public virtual Staff LabTechnician { get; set; }
        public virtual ICollection<LabBill> LabBill { get; set; }
        public virtual ICollection<TestDetails> TestDetails { get; set; }
    }
}
