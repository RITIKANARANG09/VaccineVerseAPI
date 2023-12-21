using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineVerse.Model
{
    public class VaccineCenterVaccineMapping
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Vaccine")]
        public int VaccineId { get; set;}
        [Required]
        [ForeignKey("VaccinationCenter")]
        public int VaccinationCenterId { get; set;}
        [Required]
        public int VaccineCount { get; set;}
        public VaccinationCenter VaccinationCenter { get; set; }
        public Vaccine Vaccine { get; set; }    

    }
}
