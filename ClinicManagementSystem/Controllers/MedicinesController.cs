using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using ClinicManagementSystem.View_Models;
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
        private readonly IMedicinesRepository _medicinesRepository;

        public MedicinesController(IMedicinesRepository medicinesRepository)
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
                return await _medicinesRepository.GetAllMedicines();        
            }
            return null;
        }

        #endregion

        #region get medicine by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicines>> GetMedicineById(int? id)
        {
            try
            {
                return await _medicinesRepository.GetMedicineById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Add an Medicine
        [HttpPost]
        public async Task<IActionResult> AddMedicines([FromBody] Medicines medicine)
        {
            // check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var medicineId = await _medicinesRepository.AddMedicine(medicine);
                    if (medicineId > 0)
                    {
                        return Ok(medicineId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

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

        #region delete Medicine by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _medicinesRepository.DeleteMedicine(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok("Delete successfull");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region update a medicine
        [HttpPut]
        public async Task<IActionResult> UpdateMedicine([FromBody] Medicines id)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _medicinesRepository.UpdateMedicine(id);
                    return Ok(id);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        

        #region get medicine stock
        [HttpGet]
        [Route("stock")]
        public async Task<MedicineStock> GetMedicineStockByName(string id)
        {
            //LINQ
            if (_medicinesRepository != null)
            {
                return await _medicinesRepository.GetMedicineStockByName(id);
            }
            return null;
        }
        #endregion



    }
}
