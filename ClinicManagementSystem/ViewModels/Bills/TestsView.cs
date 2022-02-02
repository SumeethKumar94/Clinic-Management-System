using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.ViewModels.Bills
{
    public class TestsView
    {
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public string Unit { get; set; }
        public int TestValue { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public int TotalAmount { get; set; }
    }
}
