using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Http;

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

        #region get medicines
        [HttpGet]
        public async Task<List<Medicines>> GetAllMedicines()
        {
            //LINQ
            if (_medicinesRepository != null)
            {
                return await _medicinesRepository.Medicines.ToListAsync();            }
            return null;
        }

        #endregion

        #region get medicine by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicines>> GetMedicineById(int? id)
        {
            try
            {
                var medicine = await (
                                    from m in _medicinesRepository.Medicines
                                    where m.MedicineId == id
                                    select new Medicines()
                                    ).ToListAsync();
                if (medicine == null)
                {
                    return NotFound();
                }
                return Ok(medicine); 
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //#region add medicines

        #region Add an Medicine
        //[HttpPost]
        //public async Task<IActionResult> AddMedicines([FromBody] Medicines medicine)
        //{
        //    // check the validation of the body
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var medicineId = await _medicinesRepository.Medicines.AddMedicines(medicine);
        //            if (medicineId > 0)
        //            {
        //                return Ok(medicineId);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            return BadRequest();
        //        }
        //    }
        //    return BadRequest();
        //}

        //#region  Add Medicine
        //[HttpPost]

        //public async Task<ActionResult<Medicines>> AddMedicine([FromBody] Medicines medicine)
        //{
        //    // check the validation of the body
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var medicineId = await _medicinesRepository.AddMedicine(medicine);
        //            if (medicine.MedicineId > 0)
        //            {
        //                return Ok(medicineId);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            return BadRequest();
        //        }
        //    }
        //    return BadRequest();
        //}
        ////#endregion
        ////#endregion

        #endregion




    }
}
