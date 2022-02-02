using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class QualificationsRepository:IQualificationsRepository
    {
        private readonly ClinicManagementSystemDBContext _contextThree;

        public QualificationsRepository(ClinicManagementSystemDBContext contextThree)
        {
            _contextThree = contextThree;
        }
        #region GET ALL ROLES
        public async Task<List<Qualifications>> GetAllQualifications()
        {
            if (_contextThree != null)
            {
                //performing lambda expressions for many category scenario
                //return await _contextThree.Qualifications.Include(r => r.Qualifications).ToListAsync();
                return await _contextThree.Qualifications.ToListAsync();
            }
            return null;
        }

        #endregion

        #region ADD A ROLE
        public async Task<int> AddQualifications(Qualifications qualification)
        {
            if (_contextThree != null)
            {
                await _contextThree.Qualifications.AddAsync(qualification);
                await _contextThree.SaveChangesAsync();
                return qualification.QualificationsId;
            }
            return 0;
        }
        #endregion

        #region UPDATE A ROLE
        public async Task UpdateQualifications(Qualifications qualification)
        {
            if (_contextThree != null)
            {
                _contextThree.Entry(qualification).State = EntityState.Modified;
                _contextThree.Qualifications.Update(qualification);
                await _contextThree.SaveChangesAsync();
            }
        }
        #endregion
    }
}
