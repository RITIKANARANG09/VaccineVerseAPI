using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VaccineVerse.Business;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;

namespace VaccineVerse.Controllers
{
    [Route("api/[controller]/{id?}")]
    [ApiController]
    public class VaccinationCenterController : Controller
    {
        private readonly IVaccinationCenterBusiness VaccineCenterBusiness;

        public VaccinationCenterController(IVaccinationCenterBusiness vaccineCenter)
        {
            VaccineCenterBusiness = vaccineCenter;
        }

       

        [HttpGet]
        public IActionResult Get(int? vaccineId)
        {
            try
            {
                var result = VaccineCenterBusiness.ViewVaccinationCenters(vaccineId);
                if (result.Count() == 0 || result == null)
                {
                    return BadRequest("No vaccination centers available");
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        [Authorize(Roles = "GlobalAdmin")]
        public IActionResult Post([FromBody] VaccinationCenter vaccinationCenter)
        {
            try
            {
                var result = VaccineCenterBusiness.AddVaccinationCenter(vaccinationCenter);
                if (result)
                    return Ok("Vaccination Center added successfully !!");
                return BadRequest("Something went wrong");
            }
         catch(Exception ex)
            {
                return Ok(ex);
            }
            
        }
       
        [HttpPost("Vaccine")]
        [Authorize(Roles = "LocalAdmin")]
        public IActionResult AddVaccine([FromBody] VaccineCenterVaccineMapping vaccineDetails)
        {
            try
            {
                var result = VaccineCenterBusiness.AddVaccine(vaccineDetails);
                if (result == false)
                    return BadRequest("Something went wrong");
                return Ok("Vaccine added successfully");
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
           
        }
        [HttpGet]
        [Route("Vaccine")]
        public IActionResult ViewVaccinesInVaccinationCenters()
        {
            try
            {
                var userId = User.Identity.GetUserId();

                var result = VaccineCenterBusiness.ViewVaccinesInVaccinationCenters(userId);
                if (result == null)
                    return BadRequest("Something went wrong");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
           
        }
        [HttpPatch]
        [Route("Vaccine/Increase")]
        [Authorize(Roles = "LocalAdmin")]
        public IActionResult Increase([FromBody] VaccineCenterVaccineMapping vaccineDetails)
        {
            try
            {
                var result = VaccineCenterBusiness.IncreaseVaccineCount(vaccineDetails);
                if (result == false)
                    return BadRequest("Something went wrong");
                return Ok("Vaccine increases successfully");
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
            
        }
        [HttpPatch]
        [Route("Vaccine/Decrease")]
        [Authorize(Roles = "LocalAdmin")]
        public IActionResult Decrease([FromBody] VaccineCenterVaccineMapping vaccineDetails)
        {
            try
            {
                var result = VaccineCenterBusiness.DecreaseVaccineCount(vaccineDetails);
                if (result == false)
                    return BadRequest("Something went wrong");
                return Ok("Vaccine decreases successfully");
            }
            catch( Exception ex)
            {
                return Ok(ex);
            }
        }
           
    }
    
}

