using ClinicManagementSystem.Repository;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicManagementSystem.Repository.DoctorsNotes;
using ClinicManagementSystem.View_Models;

namespace ClinicManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsNotesController : Controller
    {
        //data fields
        private readonly IDoctorsNotesRepository _notes;

        public DoctorsNotesController(IDoctorsNotesRepository notes)
        {
            _notes = notes;
        }

        #region get doctor notes
        [HttpGet]
        public async Task<List<DoctorNotes>> GetAllNotes()
        {
            //LINQ
            if (_notes != null)
            {
                return await _notes.GetAllNotes();
            }
            return null;
        }

        #endregion

        #region get doctor note by id
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorNotes>> GetNote(int? id)
        {
            try
            {
                return await _notes.GetNote(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region get doctor note by id
        [HttpGet("patient/{id}")]
        public async Task<ActionResult<List<NotesView>>> GetNoteForPatient(int? id)
        {
            try
            {
                return await _notes.GetNoteForPatient(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Add a  note
        [HttpPost]
        public async Task<IActionResult> AddMedicines([FromBody] DoctorNotes note)
        {
            // check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var notes = await _notes.AddNotes(note);
                    if (notes > 0)
                    {
                        return Ok(note);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        
        #endregion
        
        #region delete note by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _notes.DeleteNote(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok("delete successfull");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region update a medicine
        [HttpPut]
        public async Task<IActionResult> UpdateNote([FromBody] DoctorNotes note)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _notes.UpdateNote(note);
                    return Ok(note);
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
