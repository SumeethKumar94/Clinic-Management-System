using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.MedicinesRepo;
using ClinicManagementSystem.View_Models;
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


        [HttpGet]
        [Route("Id/{id}")]
        public async Task<MedicineListView> GetMedicineDetailsById(int id)
        {
            return await _medicineDetailsRepository.GetMedicineDetailsById(id);
        }
        [HttpGet]
        public async Task<List<MedicineListView>> GetMedicineDetails()
        {
            return await _medicineDetailsRepository.GetMedicineDetails();
        }
        [HttpGet]
        [Route("/Name/{name}")]
        public async Task<MedicineListView> GetMedicineDetailsByname(string name)
        {
            return await _medicineDetailsRepository.GetMedicineDetailsByname(name);
        }
        [HttpGet]
        [Route("/Phone/{phone}")]
        public async Task<MedicineListView> GetMedicineDetailsByPhone(Int64 phone)
        {
            return await _medicineDetailsRepository.GetMedicineDetailsByPhone(phone);
        }
   


        }
}
