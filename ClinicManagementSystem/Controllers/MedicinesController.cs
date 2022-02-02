using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
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
    public class MedicinesController : Controller
    {


        //data fields
        private readonly ClinicManagementSystemDBContext _medicinesRepository;

        public MedicinesController(ClinicManagementSystemDBContext medicinesRepository)
        {
            _medicinesRepository = medicinesRepository;
        }
        [HttpGet]
        public async Task<List<Medicines>> GetAllMedicines()
        {
            //LINQ
            if (_medicinesRepository != null)
            {
                return await _medicinesRepository.Medicines.ToListAsync();            }
            return null;
        }

    }
}
