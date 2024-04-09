using Microsoft.EntityFrameworkCore;

namespace Clinic.Models
{
    public class ClinicDbContext : DbContext
    {
        // DbSet pour chaque entité
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Poste> Postes { get; set; }
        public DbSet<Repos> Repos { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<Emploi> Emplois { get; set; }
        public DbSet<ChefDeService> ChefsDeService { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<HR> HR { get; set; }
        public DbSet<EmployeeSupplement> EmployeeSupplements { get; set; }
        public DbSet<GestionViewModel> GestionViewModels { get; set; }
     //   public DbSet<WeeklyEmployment> WeeklyEmployments { get; set; }

      //  public DbSet<DailyEmployment> DailyEmployments { get; set; }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
            
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure GestionViewModel as a keyless entity
            modelBuilder.Entity<GestionViewModel>().HasNoKey();
      
           
            // Configure la relation entre Categorie et Poste
            modelBuilder.Entity<Categorie>()
                .HasMany(c => c.Postes)
                .WithOne(p => p.Categorie)
                .HasForeignKey(p => p.CategorieId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure la relation entre Categorie et Poste
            modelBuilder.Entity<Categorie>()
                .HasMany(c => c.Repos)
                .WithOne(p => p.Categorie)
                .HasForeignKey(p => p.CategorieId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configure la relation entre Employee et Supplement
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Supplements)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

      

            // Configure la relation entre ChefDeService et Service
            modelBuilder.Entity<ChefDeService>()
                .HasOne(cs => cs.Service)
                .WithMany(s => s.ChefsDeService)
                .HasForeignKey(cs => cs.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure la relation entre Service et Employee
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Employees)
                .WithOne(e => e.Service)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure la relation entre Emploi et Service
            modelBuilder.Entity<Emploi>()
                .HasOne(e => e.Service)
                .WithMany(s => s.Emplois)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);



            // Configure la relation entre Supplement et Employee
            modelBuilder.Entity<Supplement>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.Supplements)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure la relation entre Service et HR
            modelBuilder.Entity<Service>()
                .HasOne(s => s.HR)
                .WithMany(hr => hr.Services)
                .HasForeignKey(s => s.HRId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeePoste>()
                   .HasKey(ep => new { ep.EmployeeId, ep.PosteId });

            modelBuilder.Entity<EmployeePoste>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeePostes)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeePoste>()
                .HasOne(ep => ep.Poste)
                .WithMany(p => p.EmployeePostes)
                .HasForeignKey(ep => ep.PosteId);

            modelBuilder.Entity<EmployeeRepos>()
          .HasKey(er => new { er.EmployeeId, er.ReposId });

            // Configure la relation entre EmployeeRepos et Employee
            modelBuilder.Entity<EmployeeRepos>()
                .HasOne(er => er.Employee)
                .WithMany(e => e.EmployeeRepos)
                .HasForeignKey(er => er.EmployeeId);

            // Configure la relation entre EmployeeRepos et Repos
            // Configure la relation entre EmployeeRepos et Repos
            modelBuilder.Entity<EmployeeRepos>()
                .HasOne(er => er.Repos)
                .WithMany() // Aucune navigation nécessaire car EmployeeRepos n'a pas de collection de Repos
                .HasForeignKey(er => er.ReposId);




        }
    }
}
