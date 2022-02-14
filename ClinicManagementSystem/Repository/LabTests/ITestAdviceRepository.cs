using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models.LabTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.LabTests
{
    public interface ITestAdviceRepository
    {
        //get test advice
        Task<List<TestAdviceViewModel>> GetTestAdvice();

        //get test advice by id
        Task<TestAdviceViewModel> GetTestAdviceById(int id);

        //get test advice by mobile
        Task<TestAdviceViewModel> GetTestAdviceByPhone(Int64 phone);

        //add a test advice
        Task<int> AddTestAdvice(TestReport testReport);

        //update a test advice
        Task UpdateTestAdvice(TestReport testReport);

      




    }
}
