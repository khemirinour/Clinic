using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using Clinic;
using Clinic.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configurer les services
        builder.Services.AddDbContext<ClinicDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configurer le pipeline de requ�te HTTP
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            app.UseHttpsRedirection(); // Redirection HTTPS
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        // Configurer les routes du contr�leur
        app.MapControllerRoute(
            name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

        // Cr�er un h�te Web ASP.NET Core
    }

   
}
