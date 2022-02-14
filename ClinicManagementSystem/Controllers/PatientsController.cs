using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _patientsRepository;

        public PatientsController(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }


        #region get all Patients
        [HttpGet]
        [Route("GetAllPatients")]
        //[Authorize]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[Route("GetAllPatients")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            return await _patientsRepository.GetAllPatients();
        }
        #endregion
        /*
        #region get patients using view model
        [HttpGet]
        
        [Route("GetTheAllPatients")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetTheAllPatients()
        {
            return await _patientsRepository.GetTheAllPatients();
        }
        #endregion
        */


        #region get patient details by contact
        [HttpGet("{search}/{contact}")]
        //[Route("GetPatientByContact")]
        
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientByContact(string contact)
        {
            try
            {
                var result = await _patientsRepository.GetPatientByContact(contact);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region get patient details by id
        [HttpGet("{id}")]



        public async Task<ActionResult<Patient>> GetPatientById(int? id)
        {
            try
            {
                var userTwo = await _patientsRepository.GetPatientById(id);
                if (userTwo == null)
                {
                    return NotFound();
                }
                return userTwo;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region get patient details by name
        [HttpGet]
        [Route("GetPatientByName/{name}")]
        
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientByName(string name)
        {
            try
            {
                var resultTwo = await _patientsRepository.GetPatientByPatientName(name);
                if (resultTwo == null)
                {
                    return NotFound();
                }
                return Ok(resultTwo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Add a Patient
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var patientID = await _patientsRepository.AddPatient(patient);
                    if (patientID > 0)
                    {
                        return Ok(patientID);
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region update a patient
        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] Patient patient)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _patientsRepository.UpdatePatient(patient);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion




    }
}
