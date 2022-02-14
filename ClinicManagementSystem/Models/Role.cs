using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Role
    {
        public Role()
        {
            Qualifications = new HashSet<Qualifications>();
            Staff = new HashSet<Staff>();
        }

        public int RoleId { get; set; }
        public string Role1 { get; set; }

        public virtual ICollection<Qualifications> Qualifications { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
