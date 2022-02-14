using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.LabTests
{
    public interface ILabTestsRepository
    {
        //get all Tests
        Task<List<Test>> GetAllTests();
       
        //add a test
        Task<int> AddTest(Test test);

        //update test
        Task UpdateTest(Test test);

        //getting test details by id
        Task<ActionResult<Test>> GetTestById(int? id);

        //getting lab test details by test name
        Task<IEnumerable<Test>> GetLabTestByTestName(string name);

        //delete post
        Task<int> DeleteTest(int? id);

    }
}
