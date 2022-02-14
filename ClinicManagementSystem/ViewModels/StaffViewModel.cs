using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models
{
    public class StaffViewModel
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? QualificationsId { get; set; }

        public string Qualification { get; set; }
        public string Status { get; set; }
        public int? RoleId { get; set; }

        public string Role1 { get; set; }

        //public virtual ICollection<Appointment> AppointmentDoctor { get; set; }
        //public virtual ICollection<Appointment> AppointmentReceptionist { get; set; }
        //public virtual ICollection<Login> Login { get; set; }
        //public virtual ICollection<MedicineAdvice> MedicineAdviceDoctor { get; set; }
        //public virtual ICollection<MedicineAdvice> MedicineAdvicePharmacist { get; set; }
        //public virtual ICollection<TestReport> TestReportDoctor { get; set; }
        //public virtual ICollection<TestReport> TestReportLabTechnician { get; set; }
    }
}
