using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.Appointments;
using ClinicManagementSystem.View_Models.Appointments;
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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointment _appointment;

        //constructor injection
        public AppointmentsController(IAppointment appoint)
        {
            _appointment = appoint;
        }

        #region view appointments
        [HttpGet]
        // [Authorize]
        [Route("ViewAppointments")]
        //https://localhost:44381/api/Appointments/ViewAppointments
        public async Task<List<Appointmentview>> GetAppointments()
        {
            return await _appointment.GetAppointments();
        }
        #endregion

        #region view appointments by  id
        [HttpGet]
        // [Authorize]
        [Route("ViewAppointmentById/{id}")]
        public async Task<Appointmentview> GetAppointmentsById(int id)
        {
            return await _appointment.GetAppointmentsById(id);
        }
        #endregion

        #region view appointment by patient mobile
        [HttpGet]
        // [Authorize]
        [Route("ViewAppointmentByPhone/{phone}")]
        public async Task<Appointmentview> GetAppointmentsByPhone(Int64 phone)
        {
            return await _appointment.GetAppointmentsByPhone(phone);
        }
        #endregion

        #region add appointments
        [HttpPost]
        public async Task<int> AddAppointment(Appointment appointment)
        {
            return await _appointment.AddAppointment(appointment);
        }
        #endregion

        #region update appointment
        [HttpPut]
       public async Task<IActionResult> UpdateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _appointment.UpdateAppointment(appointment);
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

        #region view appointments by  id
        [HttpGet]
        // [Authorize]
        [Route("ViewAppointmentByDoctorId/{id}")]
        public async Task<List<Appointmentview>> GetAppointmentsByDoctorId(int id)
        {
            return await _appointment.GetAppointmentsByDoctorId(id);
        }
        #endregion
    }
}
