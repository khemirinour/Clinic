using Microsoft.EntityFrameworkCore;

namespace Clinic.Models
{
    public class ClinicDbContext : DbContext
    {
        // DbSet pour chaque entité
        public DbSet<Categorie>? Categories { get; set; }
        public DbSet<Employee>? Employee { get; set; }

        public DbSet<Poste>? Postes { get; set; }
        public DbSet<Repos>? Repos { get; set; }
        public DbSet<Supplement>? Supplements { get; set; }
        public DbSet<Emploi>? Emplois { get; set; }
        public DbSet<ChefDeService>? ChefsDeService { get; set; }
        public DbSet<Day>? Days { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<HR>? HR { get; set; }
        public DbSet<EmployeeSupplement>? EmployeeSupplements { get; set; }
        //public DbSet<GestionViewModel> GestionViewModels { get; set; }
         public DbSet<WeeklyEmployment>? WeeklyEmployments { get; set; }

         public DbSet<DailyEmployment>? DailyEmployments { get; set; }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
            
        }

        public ClinicDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    


        }
    }
}
