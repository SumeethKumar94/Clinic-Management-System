using ClinicManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository.LabTests
{
    interface ITestDetailsRepository
    {
        //add test report details
        Task<int> AddTestReportDetails(TestDetails testDetails);
        
        //update test report details
        Task UpdateTestReportDetails(TestDetails testDetails);
    }
}
