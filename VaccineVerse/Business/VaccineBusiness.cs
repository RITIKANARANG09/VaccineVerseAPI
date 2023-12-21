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
    public class VaccineBusiness:IVaccineBusiness
    {
        public ApiDbContext Context { get; set; }
        public VaccineBusiness(ApiDbContext context)
        {
            this.Context = context;
        }
        public bool AddVaccineGlobally([FromBody] Vaccine vaccine)
        {
             
        Context.Vaccines.Add(vaccine);
            Context.SaveChanges();
            return true;
        }
        public IEnumerable<Vaccine> ViewVaccine(int? id)
        {
            List<Vaccine> vaccines=new List<Vaccine>();

            if (id.HasValue)
            {
                var vaccine = Context.Vaccines.Find(id);
                if(vaccine != null)
                {
                    vaccines.Add(vaccine);
                }
                return vaccines; 
            }
           
            return Context.Vaccines;
           
        }
       
        
    }
}
