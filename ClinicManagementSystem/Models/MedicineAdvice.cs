using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class MedicineAdvice
    {
        public MedicineAdvice()
        {
            MedicineBill = new HashSet<MedicineBill>();
        }

        public int MedicineAdviceId { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int? PharmacistId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Staff Doctor { get; set; }
        public virtual Staff Pharmacist { get; set; }
        public virtual ICollection<MedicineBill> MedicineBill { get; set; }
    }
}
