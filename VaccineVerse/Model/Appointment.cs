using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VaccineVerse.Model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string PatientId { get; set; }
        
        public ApplicationUser Patient { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("VaccinationCenter")]
        [Required]
        public int VaccinationCenterId { get; set; }
        public VaccinationCenter VaccinationCenter { get; set; }
        [ForeignKey("Vaccine")]
        [Required] 
        public int VaccineId { get; set; }
        [JsonIgnore]
        public Vaccine Vaccine { get; set; }
    }
}
