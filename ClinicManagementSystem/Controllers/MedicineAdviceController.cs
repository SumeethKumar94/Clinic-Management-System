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

        #region view all medicine advices
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

        #endregion

        #region Add medicine advices
        [HttpPost]
        public async Task<IActionResult> AddMedcineAdvice([FromBody]MedicineAdvice medicineAdvice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var adviceID = await _medcineAdviceRepository.AddMedicineAdvice(medicineAdvice);
                    if (adviceID > 0)
                    {
                        return Ok(adviceID);
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

        #region Update Medicine Advices
        [HttpPut]
        public async Task<IActionResult> UpdateMedicineAdvice([FromBody] MedicineAdvice medicineAdvice)
        {
            //since it is frombody we need to check the validation of body , n lowda
            if (ModelState.IsValid)
            {
                try
                {
                    await _medcineAdviceRepository.UpdateMedicineAdvice(medicineAdvice);
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

        #region Get Medicine Advice by ID
        [HttpGet]
        [Route("Id/{id}")]
        public async Task<MedicineAdviceView> GetMedicineAdvicebyId(int id)
        {
            return await _medcineAdviceRepository.GetMedicineAdvicebyId(id);
        }

            #endregion

            #region Get Medicine Advice by Name
            [HttpGet]
        [Route("Name/{name}")]
        public async Task<MedicineAdviceView> GetMedicineAdvicebyName(string name)
        {
            return await _medcineAdviceRepository.GetMedicineAdvicebyName(name);
        }
            #endregion

            #region Get Medicine Advice by Phone
            [HttpGet]
        [Route("Phone/{phone}")]
        public async Task<MedicineAdviceView> GetMedicineAdvicebyPhone(Int64 phone)
        {
            return await _medcineAdviceRepository.GetMedicineAdvicebyPhone(phone);
        }
            #endregion

        }
}
