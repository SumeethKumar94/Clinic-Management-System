using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models
{
    public class StockReportViewModel
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int? Stock { get; set; }
    }
}
