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
        Task<List<Qualifications>> GetQualifications();

        Task<int> AddQualification(Qualifications qualification);

        Task<ActionResult<Qualifications>> GetQualification(int? id);
    }
}
