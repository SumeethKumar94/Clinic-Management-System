using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            ConsultationBill = new HashSet<ConsultationBill>();
            LabBill = new HashSet<LabBill>();
            MedicineAdvice = new HashSet<MedicineAdvice>();
            MedicineBill = new HashSet<MedicineBill>();
            TestReport = new HashSet<TestReport>();
        }

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ReceptionistId { get; set; }
        public int TokenNo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public byte Status { get; set; }

        public virtual Staff Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Staff Receptionist { get; set; }
        public virtual ICollection<ConsultationBill> ConsultationBill { get; set; }
        public virtual ICollection<LabBill> LabBill { get; set; }
        public virtual ICollection<MedicineAdvice> MedicineAdvice { get; set; }
        public virtual ICollection<MedicineBill> MedicineBill { get; set; }
        public virtual ICollection<TestReport> TestReport { get; set; }
    }
}
