using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;

namespace VaccineVerse.Business
{
    public class VaccinationCenterBusiness:IVaccinationCenterBusiness
    {
         public ApiDbContext Context { get; set; }
        public VaccinationCenterBusiness(ApiDbContext context)
        {
            this.Context = context;
        }
        public IEnumerable<VaccinationCenter> ViewVaccinationCenters(int? vaccineId)
        {
            IEnumerable<VaccinationCenter> vaccineCenters = null;
            if(vaccineId.HasValue)
            {
                vaccineCenters= Context.VaccineCenterVaccineMappings.Where(v => v.VaccinationCenterId != null && v.VaccineId==vaccineId).Select(v => v.VaccinationCenter);
              
                return vaccineCenters;
            }
            vaccineCenters = Context.vaccinationCenters;
            return vaccineCenters;
        }
        public bool AddVaccinationCenter(VaccinationCenter vaccinationCenter)
        {

            Context.vaccinationCenters.Add(vaccinationCenter);
            Context.SaveChanges();
            return true;
        }
        public IEnumerable<Vaccine> ViewVaccinesInVaccinationCenters(string userId)
        {
            var user=Context.ApplicationUser.Find(userId);
            int age = user.age;
            IEnumerable<Vaccine> vaccinesList = null;
            var vaccinationCenters = Context.VaccineCenterVaccineMappings;
            vaccinesList=vaccinationCenters.Where(v => v.VaccinationCenterId!=null).Select(v=>v.Vaccine);
            var updatedVaccineslist = vaccinesList.Where(a => a.MaxAge >= age && a.MinAge <= age);
            return updatedVaccineslist;
        }

        public bool AddVaccine(VaccineCenterVaccineMapping vaccineDetails)
        {
           var vaccineId= Context.Vaccines.Find(vaccineDetails.VaccineId);
           var vaccineCenterId= Context.vaccinationCenters.Find(vaccineDetails.VaccinationCenterId);
           
            if (vaccineId == null || vaccineCenterId == null )
                return false;
          
            Context.VaccineCenterVaccineMappings.Add(vaccineDetails);
            
            Context.SaveChanges();
            return true;
           
        }
        public bool IncreaseVaccineCount(VaccineCenterVaccineMapping vaccineDetails)
        {
            var result = Context.VaccineCenterVaccineMappings.FirstOrDefault(v => v.VaccinationCenterId == vaccineDetails.VaccinationCenterId && v.VaccineId == vaccineDetails.VaccineId);
            if (result == null)
                return false;
            result.VaccineCount += vaccineDetails.VaccineCount;
            Context.SaveChanges();
            return true;

        }
        public bool DecreaseVaccineCount(VaccineCenterVaccineMapping vaccineDetails)
        {
            var result = Context.VaccineCenterVaccineMappings.FirstOrDefault(v => v.VaccinationCenterId == vaccineDetails.VaccinationCenterId && v.VaccineId == vaccineDetails.VaccineId);
            if (result == null || result.VaccineCount<vaccineDetails.VaccineCount)
                return false;
            result.VaccineCount -= vaccineDetails.VaccineCount;
            Context.SaveChanges();
            return true;

        }
    }
}
