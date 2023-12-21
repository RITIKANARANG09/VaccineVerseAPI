using System.ComponentModel.DataAnnotations;

namespace VaccineVerse.Model.DTO
{
    public class AppointmentViewDTO
    {
        [Required]
        public int VaccinationCenterId { get; set; }
        [Required]
        public int VaccineId { get; set; }
        [Required]
        public string DateTime { get; set; }
        public string PatientId { get; set; }
    }
}
