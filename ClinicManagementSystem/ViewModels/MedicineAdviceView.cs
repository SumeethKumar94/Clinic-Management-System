using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models
{
    public class MedicineAdviceView
    {

        public int MedicineAdviceId { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }

        public string Patient { get; set; }
        //public string Doctor { get; set; }
        //public string Pharmcist { get; set; }


        public List<MedicineView> medicineList { get; set; }

    }
}
