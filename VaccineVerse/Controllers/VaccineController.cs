using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;

namespace VaccineVerse.Controllers
{
    [Route("api/[controller]/{id?}")]
    [ApiController]
    public class VaccineController : Controller
    {
        private readonly IVaccineBusiness vaccineBusiness;

        public VaccineController(IVaccineBusiness vaccineBusiness)
        {
            this.vaccineBusiness = vaccineBusiness;
        }
       
        [HttpPost]
        [Authorize(Roles = "GlobalAdmin")]
        public  IActionResult Post([FromBody] Vaccine vaccine)
        {
            try
            {
                var result = vaccineBusiness.AddVaccineGlobally(vaccine);
                if (result)
                    return Ok("Vaccine added succesfully");
                return BadRequest("Vaccine can't be added");
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
         
        }
        [HttpGet]
        public IActionResult Get(int? id)
        {
            try
            {
                var result = vaccineBusiness.ViewVaccine(id);
                if (result.Count() == 0)
                {
                    return NotFound("No vaccine found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
           
        }
        

    }
}
