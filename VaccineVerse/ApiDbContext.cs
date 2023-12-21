using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaccineVerse.Model;

namespace VaccineVerse
{
    public class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccinationCenter> vaccinationCenters { get; set; }
        public DbSet<VaccineCenterVaccineMapping> VaccineCenterVaccineMappings { get; set; }    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
