using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.View_Models
{
    public class MedicineListView
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string DoctorsName { get; set; }
        public DateTime DateOfPrescription { get; set; }
        public int? DoctorsId { get; set; }

        public List<MedicinesView> Medicines { get; set; }

    }
}
