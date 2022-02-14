using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models.LabTests
{
    public class TestValueView
    {
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public string Unit { get; set; }
        public int TestValue { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
    }
}
