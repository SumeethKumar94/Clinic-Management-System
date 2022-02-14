using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModels.Bills
{
    public class FinalBillView
    {
        public int BillId { get; set; }

        public DateTime BillDate { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string ReceptionistName { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public int ConsultationFee { get; set; }
        public int LabTestsFee { get; set; }
        public int MedicinesFee { get; set; }
        public int TotalAmount { get; set; }
    }
}
