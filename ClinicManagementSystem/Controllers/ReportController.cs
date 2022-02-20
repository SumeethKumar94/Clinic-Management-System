using ClinicManagementSystem.Models;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ClinicManagementSystemDBContext context;
        public ReportController(ClinicManagementSystemDBContext cont)
        {
            context = cont;
        }

        #region get all medicine stock
        [HttpGet]
        [Route("GetStockReport")]
        public async Task<List<StockReportViewModel>> GetMedicineStock()
        {
            if (context != null)
            {
                return await (from a in context.Medicines

                              select new StockReportViewModel
                              {
                                  MedicineId = a.MedicineId,
                                  MedicineName = a.MedicineName,
                                  Stock = a.Stock
                              }

                ).ToListAsync();
            };
            return null;
        }
        #endregion

        #region GET Medicine Stock by Id
        [HttpGet]
        [Route ("GetStockReportById/{id}")]

        public async Task<StockReportViewModel> GetMedicineStockById(int id)
        {
            if (context != null)
            {
                return await (from a in context.Medicines
                              where a.MedicineId == id
                              select new StockReportViewModel
                              {
                                  MedicineId = a.MedicineId,
                                  MedicineName = a.MedicineName,
                                  Stock = a.Stock
                              }

                ).FirstOrDefaultAsync();
            };
            return null;
        }
        #endregion

        #region GET Medicine Stock by name
        [HttpGet]
        [Route("GetStockReportByName/{name}")]

        public async Task<StockReportViewModel> GetMedicineStockById(string name)
        {
            if (context != null)
            {
                return await (from a in context.Medicines
                              where a.MedicineName == name
                              select new StockReportViewModel
                              {
                                  MedicineId = a.MedicineId,
                                  MedicineName = a.MedicineName,
                                  Stock = a.Stock
                              }

                ).FirstOrDefaultAsync();
            };
            return null;
        }
        #endregion

        #region GET Sales report
        [HttpGet]
        [Route("GetSalesReport")]

        public async Task<List<SalesReportViewModel>> GetSalesReport()
        {
            if (context != null)
            {
                return await (from b in context.Bill
                              group b by b.BillDate.Month into g
                              select new SalesReportViewModel
                              {
                                  MonthOfSale = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Key),
                                  SumAmount = g.Sum(p => p.TotalAmount)
                              }

                ).ToListAsync();
            };
            return null;
        }
        #endregion

        #region lab test report
        [HttpGet]
        [Route("GetLabTestReport")]

        public async Task<List<LabTestReportViewModel>> GetLabTestReport()
        {
            if (context != null)
            {
                return await (from b in context.LabBill
                              join tr in context.TestReport
                              on b.TestReportId equals tr.TestReportId
                              join td in context.TestDetails
                              on tr.TestReportId equals td.TestReportId
                              join t in context.Test
                              on td.TestId equals t.TestId
                              
                              where b.TestReportId == td.TestReportId
                              group t by t.TestName into g
                              select new LabTestReportViewModel
                              {
                                  //TestId = g.Key,
                                  TestName = g.Key,      
                                  TotalCount = g.Count(),
                                  TotalPrice = ((from b in context.LabBill
                                                 join tr in context.TestReport
                                                 on b.TestReportId equals tr.TestReportId
                                                 join td in context.TestDetails
                                                 on tr.TestReportId equals td.TestReportId
                                                 join t in context.Test
                                                 on td.TestId equals t.TestId

                                                 where t.TestName ==g.Key                                                // group b by b.TestReportId into grp
                                                  
                                                 select b.TotalAmount).Sum())
                                  
                                  
                              
                              }

                ).ToListAsync();
            };
            return null;
        }
        #endregion
    }
}
