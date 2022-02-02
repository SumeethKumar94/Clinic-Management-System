using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    interface IQualificationsRepository
    {
        //get all roles
        Task<List<Qualifications>> GetAllQualifications();

        //add a role
        Task<int> AddQualifications(Qualifications qualification);

        //update a role
        Task UpdateQualifications(Qualifications qualification);
    }
}
