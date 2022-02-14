using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.MedicinesRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineDetailsController : ControllerBase
    {
        private readonly IMedicineDetailsRepository _medicineDetailsRepository;
        public MedicineDetailsController(IMedicineDetailsRepository medicineDetailsRepository)
        {
            _medicineDetailsRepository = medicineDetailsRepository;
        }

        #region add medicine details
        [HttpPost]
        public async Task<IActionResult> AddMedicineDetails([FromBody] MedicineDetails medicineDetails)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var testID = await _medicineDetailsRepository.AddMedicineDetails(medicineDetails);
                    if (testID > 0)
                    {
                        return Ok(testID);
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region update medicine details
        [HttpPut]
        public async Task<IActionResult> UpdateMedicineDetails([FromBody] MedicineDetails medicineDetails)
        {
            //since it is frombody we need to check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _medicineDetailsRepository.UpdateMedicineDetails(medicineDetails);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

    }
}
