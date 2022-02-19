using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.Appointments;
using ClinicManagementSystem.View_Models.Appointments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ClinicManagementSystemDBContext _context;

        //constructor injection
        public AppointmentsController(IAppointment appoint, ClinicManagementSystemDBContext cont)
        {
            _appointment = appoint;
            _context = cont;
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

        #region view appointments by  doctorsid
        [HttpGet]
        // [Authorize]
        [Route("ViewAppointmentByDoctorId/{id}")]
        public async Task<List<Appointmentview>> GetAppointmentsByDoctorId(int id)
        {
            return await _appointment.GetAppointmentsByDoctorId(id);
        }
        #endregion

        #region View Todays Appointment
        [HttpGet]
        [Route("Today")]
        public async Task<List<Appointmentview>> GetAppointmentsToday()
        {
            return await _appointment.GetAppointmentsToday();
        }
        #endregion

        #region View Appointment By Date
        [HttpGet]
        [Route("Date/{date}")]
        public async Task<List<Appointmentview>> GetAppointmentsByDate(DateTime date)
        {
            return await _appointment.GetAppointmentsByDate(date);
        }
        #endregion
        #region  Get Appointments By Status
        [HttpGet]
        [Route("Status/{status}")]
        public async Task<List<Appointmentview>> GetAppointmentsByStatus(int status)
        {
            return await _appointment.GetAppointmentsByStatus(status);
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
        //--------------------Dont Touch---------------------
        #region Patch  appointment
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAppointment(int id, [FromBody] JsonPatchDocument<Appointment> patchEntity)
        {
            if (id > 0)
            {

                var appointment = await _context.Appointment.FirstOrDefaultAsync(u => u.AppointmentId == id);
                if (appointment == null)
                {
                    return BadRequest();
                }

                patchEntity.ApplyTo(appointment, ModelState);

                _context.Appointment.Update(appointment);
                await _context.SaveChangesAsync();
                return Ok(appointment);
            }
            return BadRequest();
        }

        #endregion
        //------------------------------------------------------

        //[Route]
        #region Delete Appointment
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            int result = 0;
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                result = await _appointment.DeleteAppointment(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion


        #region view appointments by  doctorsid and date (today)
        [HttpGet]
        // [Authorize]
        [Route("ViewAppointmentsToday/{id}")]
        public async Task<List<Appointmentview>> GetAppointmentsByDoctorIdandDate(int id)
        {
            return await _appointment.GetAppointmentsByDoctorIdandDate(id);
        }
        #endregion

        #region view appointments by  doctorsid and date 
        [HttpGet]
        // [Authorize]
        [Route("ViewAppointmentsondate/{id}/{date}")]
        public async Task<List<Appointmentview>> getAppointmentsOnDate(int id, DateTime date)
        {
            return await _appointment.getAppointmentsOnDate(id, date);
        }
        #endregion


        [HttpGet]
        [Route("CountAppointments")]
        public async Task<int> GetAppointmentCount()
        {
            return await _appointment.GetAppointmentCount();
        }
    }
}
