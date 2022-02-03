using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.LabTests
{
    public class LabTestsRepository : ILabTestsRepository
    {

        private readonly ClinicManagementSystemDBContext _contextTwo;

        public LabTestsRepository(ClinicManagementSystemDBContext contextTwo)
        {
            _contextTwo = contextTwo;
        }


        #region add a test
        public async Task<int> AddTest(Test test)
        {
            if (_contextTwo != null)
            {
                await _contextTwo.Test.AddAsync(test);
                await _contextTwo.SaveChangesAsync();
                return test.TestId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion


        #region getting all test details
        public async Task<List<Test>> GetAllTests()
        {
            if (_contextTwo != null)
            {
                //performing lampda expression  for many post scenario
                return await _contextTwo.Test.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion


        #region update a test
        public async Task UpdateTest(Test test)
        {
            if (_contextTwo != null)
            {
                _contextTwo.Entry(test).State = EntityState.Modified;
                _contextTwo.Test.Update(test);
                await _contextTwo.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region getting test detail by id
        public async Task<ActionResult<Test>> GetTestById(int? id)
        {
            if (_contextTwo != null)
            {
                var testOne = await _contextTwo.Test.FindAsync(id);

                return testOne;
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion


        #region getting labtestt details using test name
        public async Task<IEnumerable<Test>> GetLabTestByTestName(string name)
        {
            IQueryable<Test> queryTwo = _contextTwo.Test;
            if (!string.IsNullOrEmpty(name))
            {
                queryTwo = queryTwo.Where(e => e.TestName.Contains(name));
            }
            return await queryTwo.ToListAsync();
            //throw new NotImplementedException();
        }
        #endregion


        #region delete a test
        public async Task<int> DeleteTest(int? id)
        {
            int result = 0;
            if (_contextTwo != null)
            {                                                                   
                var testDel = await _contextTwo.Test.FirstOrDefaultAsync(p => p.TestId == id);
                //check condition
                if (testDel != null)
                {
                    //deleting the test
                    _contextTwo.Test.Remove(testDel);

                    //commit the changes after deletion
                    result = await _contextTwo.SaveChangesAsync();
                }
                return result;
            }
            return result;
            //throw new NotImplementedException();
        }
        #endregion
    }
}
