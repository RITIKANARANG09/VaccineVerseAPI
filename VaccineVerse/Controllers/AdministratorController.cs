using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VaccineVerse.Model;

namespace VaccineVerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministratorController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] Role userRole)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole { Name = userRole.RoleName };
                var result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return Ok("Role added successfully");
                }
            }
     return BadRequest("Something went wrong");
    }
        [HttpGet]
        public IActionResult RolesList()
        {
            var roles = roleManager.Roles.ToList();
            if (roles.Count() == 0) return NotFound("No roles found");
            return Ok(roles);
        }
    }
}
