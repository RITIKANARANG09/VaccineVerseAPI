using System.Collections.Generic;
using VaccineVerse.Model;

namespace VaccineVerse.Business.BusinessInterfaces
{
    public interface ILocalAdminBusiness
    {
        public Dictionary<string, string> ViewLocalAdmins(int? vaccinationCenterId);
    }
}
