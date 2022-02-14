using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Qualifications
    {
        public Qualifications()
        {
            Staff = new HashSet<Staff>();
        }

        public int QualificationsId { get; set; }
        public string Qualification { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
