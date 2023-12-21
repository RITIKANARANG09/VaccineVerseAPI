using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;

namespace VaccineVerse.Controllers
{
    [Route("api/[controller]/{vaccinationCenterId?}")]
    [ApiController]
    public class LocalAdminController : ControllerBase
    {
        private readonly ILocalAdminBusiness localAdminBusiness;

       
        public LocalAdminController(ILocalAdminBusiness localAdminBusiness)
        {
            this.localAdminBusiness = localAdminBusiness;
        }
        [HttpGet]
        [Authorize(Roles = "GlobalAdmin")]
        public IActionResult Get(int? vaccinationCenterId)
        {
            try
            {
                var localAdminDetails = localAdminBusiness.ViewLocalAdmins(vaccinationCenterId);
                if (localAdminDetails == null)
                {
                    return BadRequest("No local Admins are there");
                }
                return Ok(localAdminDetails);
            }
            catch(Exception ex) 
            {
                return Ok(ex);
            }
      
        }
    }
}
