using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Medicines
    {
        public Medicines()
        {
            MedicineDetails = new HashSet<MedicineDetails>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineDescription { get; set; }
        public int MedicinePrice { get; set; }
        public string Dose { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<MedicineDetails> MedicineDetails { get; set; }
    }
}
