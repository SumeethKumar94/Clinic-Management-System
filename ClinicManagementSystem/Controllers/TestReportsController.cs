using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.Bills;
using ClinicManagementSystem.ViewModels.Bills;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestReportsController : ControllerBase
    {
        private readonly ITestsBill _testbill;
        //constructor injection
        public TestReportsController(ITestsBill testsBill)
        {
            _testbill = testsBill;
        }
        [HttpGet]
        public async Task<List<LabBillView>> GetAllLabBills()
        {
            return await _testbill.GetAllLabBills();
        }
        [HttpGet]
        [Route("ViewBillsByPhone")]
        //https://localhost:44381/api/TestReports/ViewBillsByPhone?phone=87590867453
        public async Task<LabBillView> GetLabBillByPhone(Int64 phone)
        {
            return await _testbill.GetLabBillByPhone(phone);
        }
        [HttpGet]
        [Route("ViewBillsById")]
        //https://localhost:44381/api/TestReports/ViewBillsById?id=4
        public async Task<LabBillView> GetLabBillById(int id)
        {
            return await _testbill.GetLabBillById(id);
        }
        [HttpPost]
        public async Task<int> AddLabBill(LabBill labBill)
        {
            return await _testbill.AddLabBill(labBill);
        }
        public async Task<IActionResult> UpdateLabBill(TestDetails testDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _testbill.UpdateLabBill(testDetails);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        }
}
