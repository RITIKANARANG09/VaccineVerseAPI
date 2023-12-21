using System.Collections.Generic;
using System.Threading.Tasks;
using VaccineVerse.Model;

namespace VaccineVerse.Business.BusinessInterfaces
{
    public interface IVaccineBusiness
    {
        public bool AddVaccineGlobally(Vaccine vaccine);
        public IEnumerable<Vaccine> ViewVaccine(int? id);
       
    }
}
