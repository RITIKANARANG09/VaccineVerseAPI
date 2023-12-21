using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineVerse.Model
{
    public class VaccinationCenter
    {
        public int Id { get; set; }
        public string VaccineCenterName { get; set; }
        public string VaccineCenterAddress { get; set; }
        [ForeignKey("User")]
        public string LocalAdminId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }   
        public ICollection<VaccineCenterVaccineMapping> Vaccines { get; set; }

       
    }
   
}
