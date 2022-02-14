using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class ConsultationBill
    {
        public int ConsultationBillId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime? DateOfBill { get; set; }
        public int TotalAmount { get; set; }

        public virtual Appointment Appointment { get; set; }
<<<<<<< HEAD
=======
        public virtual ICollection<Bill> Bill { get; set; }
>>>>>>> main
    }
}
