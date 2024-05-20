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
        public DbSet<ChefDeService>? ChefDeServices   { get; set; }
        public DbSet<Day>? Days   { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<HR>? HR { get; set; }
         public DbSet<DailyEmployment>? DailyEmployments { get; set; }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
            
        }


      
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //    }

    //    public override int SaveChanges()
    //    {
    //        UpdateChefDeService();
    //        return base.SaveChanges();
    //    }

    //    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    //    {
    //        UpdateChefDeService();
    //        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    //    }

    //    private void UpdateChefDeService()
    //    {
    //        var employees = ChangeTracker.Entries<Employee>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
    //        foreach (var entry in employees)
    //        {
    //            var employee = entry.Entity;
    //            if (employee.IsChefDeService == true)
    //            {
    //                var chefDeService = ChefDeServices?.FirstOrDefault(c => c.ChefDeServiceId == employee.EmployeeId);
    //                if (chefDeService == null)
    //                {
    //                    chefDeService = new ChefDeService { ChefDeServiceId = employee.EmployeeId };
    //                    ChefDeServices.Add(chefDeService);
    //                }

    //                chefDeService.Name = employee.Name;
    //                chefDeService.Email = employee.Email;
    //                chefDeService.Password = employee.Password;
    //                chefDeService.ServiceId = employee.ServiceId;
    //            }
    //        }
    //    }
    }
}
