using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class MedicineBill
    {
        public MedicineBill()
        {
            Bill = new HashSet<Bill>();
        }

        public int MedicineBillId { get; set; }
        public int AppointmentId { get; set; }
        public int MedicineAdviceId { get; set; }
        public DateTime MedicineBillDate { get; set; }
        public int TotalAmount { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual MedicineAdvice MedicineAdvice { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
