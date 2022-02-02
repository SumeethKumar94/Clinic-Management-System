using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Login
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int? StaffId { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
