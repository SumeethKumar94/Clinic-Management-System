using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using ClinicManagementSystem.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineAdviceController : ControllerBase
    {
            //data fields
            private readonly IMedicineAdviceRepository _medcineAdviceRepository;

            public MedicineAdviceController(IMedicineAdviceRepository medcineAdviceRepository)
            {
                _medcineAdviceRepository = medcineAdviceRepository;
            }
            [HttpGet]
            public async Task<List<MedicineAdviceView>> GetAllMedicineAdvicess()
            {
                //LINQ
                if (_medcineAdviceRepository != null)
                {
                return await _medcineAdviceRepository.GetAllMedicineAdvicess();
                }
                return null;
            }
            

        
    }
}
