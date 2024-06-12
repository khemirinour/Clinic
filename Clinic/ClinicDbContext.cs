using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Clinic.Models
{
    public class ClinicDbContext : DbContext
    {
       
        public DbSet<Categorie>? Categories { get; set; }
        public DbSet<Employee>? Employee { get; set; }

        public DbSet<Poste>? Postes { get; set; }
        public DbSet<Repos>? Repos { get; set; }
        public DbSet<Supplement>? Supplements { get; set; }
        public DbSet<Emploi>? Emplois { get; set; }
        public DbSet<ChefDeService>? ChefDeServices   { get; set; }
        public DbSet<Day>? Days   { get; set; }
        public DbSet<Service>? Services { get; set; }
         public DbSet<DailyEmployment>? DailyEmployments { get; set; }
        public DbSet<SelectListGroup> SelectListGroups { get; set; }
        public DbSet<SelectListItem> SelectListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignorer complètement les classes SelectListItem et SelectListGroup
            modelBuilder.Ignore<SelectListItem>();
            modelBuilder.Ignore<SelectListGroup>();

            // Autres configurations de modèle
        }
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
            
        }


    }
}
