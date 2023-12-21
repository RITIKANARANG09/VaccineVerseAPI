using System.ComponentModel.DataAnnotations;

namespace VaccineVerse.Model.DTO
{
    public class LoginViewDTO
    {

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
