using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VaccineVerse.Business.BusinessInterfaces;
using VaccineVerse.Model;

namespace VaccineVerse.Business
{
    public class LocalAdminBusiness:ILocalAdminBusiness
    {
        public ApiDbContext Context { get; set; }
        public LocalAdminBusiness(ApiDbContext context)
        {
            this.Context = context;
        }
        public Dictionary<string, string> ViewLocalAdmins(int? vaccinationCenterId)
        {
           
            Dictionary<string, string> localAdminDetails = new Dictionary<string, string>();
            var users=Context.ApplicationUser;
           
            if (vaccinationCenterId.HasValue)
            {
                var vaccinationCenter=Context.vaccinationCenters.Find(vaccinationCenterId);
                if(vaccinationCenter != null)
                {
                    var user = users.Find(vaccinationCenter.LocalAdminId);
                    localAdminDetails[user.UserName] = vaccinationCenter.VaccineCenterName + ", " + vaccinationCenter.VaccineCenterAddress;
                    return localAdminDetails;
                }   
            }
            var vaccineCenterList = Context.vaccinationCenters;
            foreach (var list in vaccineCenterList)
            {
                var user=users.Find(list.LocalAdminId);
      
                localAdminDetails[user.UserName] =list.VaccineCenterName + ", " + list.VaccineCenterAddress ;
            }
            return localAdminDetails;
        }
    }
}
