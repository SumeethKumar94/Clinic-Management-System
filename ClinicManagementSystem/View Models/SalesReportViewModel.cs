using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models
{
    public class SalesReportViewModel
    {
        public int BillId { get; set; }

        public DateTime BillDate { get; set; }
        public int TotalAmount { get; set; }
        public int MonthOfSale { get; set;  }
        public int SumAmount { get; set; }
    }
}
