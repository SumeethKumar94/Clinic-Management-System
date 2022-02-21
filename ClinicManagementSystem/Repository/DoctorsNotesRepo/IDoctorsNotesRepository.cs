using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.DoctorsNotes
{
    public interface IDoctorsNotesRepository
    {
        //view all doctor notes
        Task<List<DoctorNotes>> GetAllNotes();

        //add doctor note
        Task<int> AddNotes(DoctorNotes note);

        //view doctor note by id
        Task<ActionResult<DoctorNotes>> GetNote(int? id);

        //update doctor note
        Task UpdateNote(DoctorNotes note);

        //delete doctor note
        Task<int> DeleteNote(int? id);
        Task<ActionResult<List<NotesView>>> GetNoteForPatient(int? id);

    }
}
