using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VaccineVerse.Model
{
    public class Vaccine
    {

        public int Id { get; set; }
        public string VaccineName { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        [JsonIgnore]
        public ICollection<VaccineCenterVaccineMapping> VaccinationCenter { get; set; }
    }
}
