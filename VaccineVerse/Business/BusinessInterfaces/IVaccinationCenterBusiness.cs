using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaccineVerse.Model;

namespace VaccineVerse.Business.BusinessInterfaces
{
    public interface IVaccinationCenterBusiness
    {
        public IEnumerable<VaccinationCenter> ViewVaccinationCenters(int? vaccineId);
        public IEnumerable<Vaccine> ViewVaccinesInVaccinationCenters(string id);
        public bool AddVaccinationCenter(VaccinationCenter vaccinationCenter);
        public bool AddVaccine(VaccineCenterVaccineMapping vaccineDetails);
        public bool IncreaseVaccineCount(VaccineCenterVaccineMapping vaccineDetails);
        public bool DecreaseVaccineCount(VaccineCenterVaccineMapping vaccineDetails);
    }
}