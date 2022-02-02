using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModels.Bills
{
    public class SubBillView
    {
        public int ConsultationBillId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string ReceptionistName { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public DateTime? DateOfBill { get; set; }
        public int ConsultationAmount { get; set; }
    }
}
