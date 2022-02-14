using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModels.Bills
{
    public class MedicineView
    {
        public string MedicineName { get; set; }
        public string MedicineDescription { get; set; }
        public int MedicinePrice { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public string Dose { get; set; }
    }
}
