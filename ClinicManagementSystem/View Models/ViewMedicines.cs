using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models
{
    public class ViewMedicines
    {
        public ViewMedicines()
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
