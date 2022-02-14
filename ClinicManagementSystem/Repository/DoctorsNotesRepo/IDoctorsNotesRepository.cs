using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.DoctorsNotes
{
    public interface IDoctorsNotesRepository
    {
        Task<List<DoctorNotes>> GetAllNotes();

        Task<int> AddNotes(DoctorNotes note);

        Task<ActionResult<DoctorNotes>> GetNote(int? id);

        Task UpdateNote(DoctorNotes note);

        Task<int> DeleteNote(int? id);

    }
}
