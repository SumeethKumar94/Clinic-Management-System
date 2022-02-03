using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models.Appointments
{
    public class Appointmentview
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public Int64 PhoneNumber { get; set; }
        public string DoctorName { get; set; }
        public string Receptionistname { get; set; }
        public int TokenNo { get; set; }
        public DateTime AppointmentDate {get;set;}
        
    }
}
