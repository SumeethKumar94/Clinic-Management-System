using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.Patients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Patients
{
    public interface IPatientsRepository
    {
        //get all Patients
        Task<List<Patient>> GetAllPatients();

        //Task<List<PatientViewModel>> GetTheAllPatients();

        //add a patient
        Task<int> AddPatient(Patient patient);

        //update patient
        Task UpdatePatient(Patient patient);

        //getting patient details by id
        Task<ActionResult<Patient>> GetPatientById(int? id);

        
        //using contact getting patient details
        Task<IEnumerable<Patient>> GetPatientByContact(string contact);

        //using  name getting patient details
        Task<IEnumerable<Patient>> GetPatientByPatientName(string name);
    }
}
