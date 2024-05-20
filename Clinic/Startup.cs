// Startup.cs

using Clinic.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clinic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext service
            services.AddDbContext<ClinicDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConn")));

            // Add other services as needed

            // Add controller services
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // Utilisez un nom de route différent pour éviter les conflits
                endpoints.MapControllerRoute(
                    name: "emploi",
                    pattern: "Emploi/{action=Affiche}/{id?}");
                // Définissez la route spécifique pour la méthode d'action AfficherEmploi
                endpoints.MapControllerRoute(
                    name: "afficherEmploi",
                    pattern: "Emploi/AfficherEmploi",
                    defaults: new { controller = "Emploi", action = "AfficherEmploi" });
            });
        }
    }
}
