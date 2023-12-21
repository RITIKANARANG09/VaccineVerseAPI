using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineVerse.Model
{
    public class ApplicationUser
    {
        [Key,ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public IdentityUser identityUser { get; set; }
        public int age { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
