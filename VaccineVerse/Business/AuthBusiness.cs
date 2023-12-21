using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;
using VaccineVerse.Model.DTO;

namespace VaccineVerse.Business
{
    public class AuthBusiness:IAuthBusiness
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public ApiDbContext Context { get; set; }
        public AuthBusiness(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApiDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.Context = context;
        }
        public async Task<bool> AddUser(IdentityUser identityUser,RegisterViewDTO model)
        {
           
            
            var result = await userManager.CreateAsync(identityUser, model.Password);
            if(!result.Succeeded) { return false; }
            var result2= await userManager.AddToRoleAsync(identityUser,model.Role);
            if (result.Succeeded && result2.Succeeded)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Id=identityUser.Id,
                    UserName=model.UserName,
                    PhoneNumber= model.Phone,
                    age=model.age
                };
                Context.ApplicationUser.Add(user);
                Context.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<bool> LoginUser(LoginViewDTO model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Phone, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            { 
                return true;
            }
            return false;
        }
    }
}
