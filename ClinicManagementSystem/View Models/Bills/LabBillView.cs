using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModels.Bills
{
    public class LabBillView
    {
        public int LabBillId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string ReceptionistName { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public long Phone { get; set; }
  
        public string BloodGroup { get; set; }
        public DateTime? DateOfReport { get; set; }
        public string LabTechnician{ get; set; }
        public List<TestsView> TestReport { get; set; }
        public int TotalAmount { get; set; }
    }
}
