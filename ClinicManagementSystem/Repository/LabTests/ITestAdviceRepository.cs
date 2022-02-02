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
        Task<List<TestAdviceViewModel>> GetTestAdvice();

        Task<TestAdviceViewModel> GetTestAdviceById(int id);

        Task<TestAdviceViewModel> GetTestAdviceByPhone(Int64 phone);

        Task<int> AddTestAdvice(TestReport testReport);

        


    }
}
