using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models.LabTests
{
    public class TestReportView
    {
        public int TestReportId { get; set; }
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public Int64 Mobile { get; set; }
        public string Sex { get; set; }
        public string DoctorName { get; set; }
        public string ReceptionistName { get; set; }
        public DateTime AppointmentDate { get; set; }

        public List<TestValueView> TestDetails { get; set; }
    }
}
