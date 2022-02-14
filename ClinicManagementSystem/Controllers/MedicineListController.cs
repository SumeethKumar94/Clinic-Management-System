//using ClinicManagementSystem.Models;
//using ClinicManagementSystem.View_Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ClinicManagementSystem.Controllers
//{
//    public class MedicineListController : Controller
//    {
//        [ApiController]
//        [Route("api/[controller]")]
//        public class MedicinesController : Controller
//        {


//            //data fields
//            private readonly ClinicManagementSystemDBContext _context;

//            public MedicinesController(ClinicManagementSystemDBContext medicinesRepository)
//            {
//                _context = medicinesRepository;
//            }
//            [HttpGet]
//            public async Task<List<MedicineListView>> GetPrescriptionDetails();
//            {
//                //LINQ
//                if (_context != null)
//                {
//                    return await _context.Medicines.ToListAsync();
//                }
//                return null;
//            }

//        }
//    }
//}
