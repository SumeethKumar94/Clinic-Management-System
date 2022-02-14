using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class MedicineDetails
    {
        public int MedicineDetailsId { get; set; }
        public int MedicineId { get; set; }
        public int MedicineAdviceId { get; set; }
        public int Quantity { get; set; }

        public virtual Medicines Medicine { get; set; }
        public virtual MedicineAdvice MedicineAdvice { get; set; }
    }
}
