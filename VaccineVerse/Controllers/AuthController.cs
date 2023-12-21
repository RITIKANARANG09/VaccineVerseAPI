
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;
using VaccineVerse.Model.DTO;

namespace VaccineVerse.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAuthBusiness authBusiness;
        private readonly IVaccinationCenterBusiness vaccinationCenter;

        public AuthController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,IAuthBusiness authBusiness,IVaccinationCenterBusiness vaccinationCenter)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authBusiness = authBusiness;
            this.vaccinationCenter = vaccinationCenter;
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public  async Task<IActionResult> Register([FromBody] RegisterViewDTO input)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            input.Role = "Patient";
            var user = new IdentityUser
            {
                UserName=input.Phone,
                PhoneNumber=input.Phone
            };
           var result= await authBusiness.AddUser(user,input);

           

            if (result)
            {
                return Ok("User added successfully");
            }

            return BadRequest("Something went wrong");
        }
        [HttpPost]
        [Authorize(Roles = "GlobalAdmin")]
        public async Task<IActionResult> AddLocalAdmin([FromBody] LocalAdminVaccineDTO input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Something went wrong");
                }
                input.Role = "LocalAdmin";
                var user = new IdentityUser { UserName = input.Phone, PhoneNumber = input.Phone };
                var model = new RegisterViewDTO
                {
                    UserName = input.UserName,
                    Password = input.Password,
                    Role = input.Role,
                    age = input.age
                };
                var result = await authBusiness.AddUser(user, model);

                var vaccineCenter = new VaccinationCenter
                {
                    VaccineCenterName = input.VaccinationCenterName,
                    VaccineCenterAddress = input.VaccinationCenterAddress,
                    LocalAdminId = user.Id
                };
                vaccinationCenter.AddVaccinationCenter(vaccineCenter);

                if (result)
                {
                    return Ok("User added successfully");
                }

                return BadRequest("Something went wrong");
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewDTO input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await authBusiness.LoginUser(input);

                if (result)
                {
                    return Ok("Logged in");
                }

                return BadRequest();
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
          
        }
    }
}
