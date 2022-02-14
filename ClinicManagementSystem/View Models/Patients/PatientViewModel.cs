using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models.Patients
{
    public class PatientViewModel
    {

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodGroup { get; set; }

        


    }
}
