using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Staff
    {
        public Staff()
        {
            AppointmentDoctor = new HashSet<Appointment>();
            AppointmentReceptionist = new HashSet<Appointment>();
            Login = new HashSet<Login>();
            MedicineAdviceDoctor = new HashSet<MedicineAdvice>();
            MedicineAdvicePharmacist = new HashSet<MedicineAdvice>();
            TestReportDoctor = new HashSet<TestReport>();
            TestReportLabTechnician = new HashSet<TestReport>();
        }

        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? QualificationsId { get; set; }
        public string Status { get; set; }
        public int? RoleId { get; set; }
        public string Email { get; set; }

        public virtual Qualifications Qualifications { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Appointment> AppointmentDoctor { get; set; }
        public virtual ICollection<Appointment> AppointmentReceptionist { get; set; }
        public virtual ICollection<Login> Login { get; set; }
        public virtual ICollection<MedicineAdvice> MedicineAdviceDoctor { get; set; }
        public virtual ICollection<MedicineAdvice> MedicineAdvicePharmacist { get; set; }
        public virtual ICollection<TestReport> TestReportDoctor { get; set; }
        public virtual ICollection<TestReport> TestReportLabTechnician { get; set; }
    }
}
