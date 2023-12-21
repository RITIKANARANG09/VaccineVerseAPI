using System.ComponentModel.DataAnnotations;

namespace VaccineVerse.Model.DTO
{
    public class LocalAdminVaccineDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
        [Required]
        public string VaccinationCenterName { get; set; }
        [Required]
        public string VaccinationCenterAddress { get; set; }
        public string LocalAdminId { get; set; }

    }
}
