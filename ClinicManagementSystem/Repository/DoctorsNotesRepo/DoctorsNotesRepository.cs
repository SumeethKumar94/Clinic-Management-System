using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.DoctorsNotes
{
    public class DoctorsNotesRepository:IDoctorsNotesRepository
    {
        private readonly ClinicManagementSystemDBContext _context;
        public DoctorsNotesRepository(ClinicManagementSystemDBContext context)
        {
            _context = context;
        }

        #region GET ALL ROLES
        public async Task<List<DoctorNotes>> GetAllNotes()
        {
            if (_context != null)
            {
                //performing lambda expressions for many category scenario
                //return await _contextTwo.Role.Include(r => r.Role).ToListAsync();
                return await _context.DoctorNotes.ToListAsync();
            }
            return null;
        }

        #endregion

        #region Add DoctorsNotes
        public async Task<int> AddNotes(DoctorNotes note)
        {
            if (_context != null)
            {
                await _context.DoctorNotes.AddAsync(note);
                await _context.SaveChangesAsync(); // commit transaction
                return 1;
            }
            return 0;
            // throw new NotImplementedException();
        }
        #endregion

        #region get Notes by id
        public async Task<ActionResult<DoctorNotes>> GetNote(int? id)
        {
            if (_context != null)
            {
                var note = await _context.DoctorNotes.FindAsync(id);
                return note;
            }
            return null;
            //throw new NotImplementedException();
        }

        #endregion

        #region get Notes by appointment id
        public async Task<ActionResult<List<NotesView>>> GetNoteForPatient(int? id)
        {
            return await (from c in _context.DoctorNotes
                          join a in _context.Appointment on c.AppointmentId equals a.AppointmentId
                          where c.PatientId == id
                          select new NotesView
                          {
                              NoteId = c.NoteId,
                              Note = c.Note,
                              PatientId = c.PatientId,
                              DoctorId = c.DoctorId,
                              AppointmentId = c.AppointmentId,
                              Date = a.AppointmentDate

                          }
                            ).ToListAsync();

        }
            return null;
            //throw new NotImplementedException();
        }

        #endregion

        #region delete doctors note
        public async Task<int> DeleteNote(int? id)
        {
            // declare result
            int result = 0;
            if (_context != null)
            {
                var note = await _context.DoctorNotes.FirstOrDefaultAsync(u => u.NoteId == id);
                if (note != null)
                {
                    // perform delete
                    _context.DoctorNotes.Remove(note);
                    result = await _context.SaveChangesAsync(); // commit 
                    //return succcess;
                    result = 1;

                }
                return result;
            }
            return result;

            //throw new NotImplementedException();
        }
        #endregion
        
        #region update doctors note
        public async Task UpdateNote(DoctorNotes note)
        {
            if (_context != null)
            {
                _context.Entry(note).State = EntityState.Modified;
                _context.DoctorNotes.Update(note);
                await _context.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion
    }
}
