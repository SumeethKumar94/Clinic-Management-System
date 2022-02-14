using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class TestDetails
    {
        public int TestDetailId { get; set; }
        public int TestId { get; set; }
        public int TestReportId { get; set; }
        public int TestValue { get; set; }

        public virtual Test Test { get; set; }
        public virtual TestReport TestReport { get; set; }
    }
}
