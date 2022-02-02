using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class DoctorNotes
    {
        public int NoteId { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Note { get; set; }
    }
}
