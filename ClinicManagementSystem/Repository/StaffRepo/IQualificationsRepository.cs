using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public interface IQualificationsRepository
    {
        //view all qualifications
        Task<List<Qualifications>> GetQualifications();

        //add qualifications
        Task<int> AddQualification(Qualifications qualification);

        //view qualification by id
        Task<ActionResult<Qualifications>> GetQualification(int? id);
    }
}
