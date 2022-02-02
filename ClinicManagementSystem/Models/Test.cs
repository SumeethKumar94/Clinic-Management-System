using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Test
    {
        public Test()
        {
            TestDetails = new HashSet<TestDetails>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public int TotalAmount { get; set; }
        public string Unit { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public virtual ICollection<TestDetails> TestDetails { get; set; }
    }
}
