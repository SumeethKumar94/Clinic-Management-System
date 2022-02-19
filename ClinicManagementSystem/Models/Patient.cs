using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
