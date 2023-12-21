using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VaccineVerse.Model.DTO;

namespace VaccineVerse.Business.BusinessInterfaces
{
    public interface IAuthBusiness
    {
        public  Task<bool> AddUser(IdentityUser identityUser,RegisterViewDTO input);
        public Task<bool> LoginUser(LoginViewDTO input);
    }
}
