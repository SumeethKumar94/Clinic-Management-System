using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.Patients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.Patients
{
    public class PatientsRepository : IPatientsRepository
    {

        private readonly ClinicManagementSystemDBContext _context;

        public PatientsRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }
        
        #region get all patients
        public async Task<List<Patient>> GetAllPatients()
        {
            if (_context != null)
            {
                //performing lampda expression  for many post scenario
                return await _context.Patient.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion
        
        /*
        #region get patient details
        public async Task<List<PatientViewModel>> GetTheAllPatients()
        {
            if (_context != null)
            {
                //performing lampda expression  for many post scenario
                return await _context.PatientViewModel.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }

        #endregion
        */

        #region add a patient
        public async Task<int> AddPatient(Patient patient)
        {
            if (_context != null)
            {
                await _context.Patient.AddAsync(patient);
                await _context.SaveChangesAsync();
                return patient.PatientId;
            }
            return 0;
            //throw new NotImplementedException();
        }   
        #endregion


        #region getting patient details using contact
        public async Task<IEnumerable<Patient>> GetPatientByContact(string phone)
        {
            IQueryable<Patient> query = _context.Patient;
            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(e => e.Phone.ToString().Contains(phone));
            }
            return await query.ToListAsync();
            //throw new NotImplementedException();
        }
        #endregion


        #region getting patient details using patientID
        public async Task<ActionResult<Patient>> GetPatientById(int? id)
        {
            if (_context != null)
            {
                var patientOne = await _context.Patient.FindAsync(id);    

                return patientOne;
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region getting patient details using patient name
        public async Task<IEnumerable<Patient>> GetPatientByPatientName(string name)
        {
            IQueryable<Patient> queryTwo = _context.Patient;
            if (!string.IsNullOrEmpty(name))
            {
                queryTwo = queryTwo.Where(e => e.PatientName.Contains(name));
            }
            return await queryTwo.ToListAsync();
            //throw new NotImplementedException();
        }
        #endregion

        #region update a patient
        public async Task UpdatePatient(Patient patient)
        {
            if (_context != null)
            {
                _context.Entry(patient).State = EntityState.Modified;
                _context.Patient.Update(patient);
                await _context.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion
    }
}
