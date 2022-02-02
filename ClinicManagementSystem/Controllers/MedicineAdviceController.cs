using ClinicManagementSystem.Models;
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
            private readonly ClinicManagementSystemDBContext _medcineAdviceRepository;

            public MedicineAdviceController(ClinicManagementSystemDBContext medcineAdviceRepository)
            {
                _medcineAdviceRepository = medcineAdviceRepository;
            }
            [HttpGet]
            public async Task<List<MedicineAdvice>> GetAllMedicineAdvicess()
            {
                //LINQ
                if (_medcineAdviceRepository != null)
                {
                    return await _medcineAdviceRepository.MedicineAdvice.ToListAsync();
                }
                return null;
            

        }
    }
}
