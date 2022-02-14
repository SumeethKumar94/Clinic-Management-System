using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class Token
    {
        public Token()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int TokenNo { get; set; }
        public DateTime Time { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
