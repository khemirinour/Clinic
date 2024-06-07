using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(ClinicDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ApproveRegistrationRequests()
        {
            var employees = _context.Employee?.ToList();

            if (employees == null || !employees.Any())
            {
                Console.WriteLine("No employees found in the database.");
            }
            else
            {
                Console.WriteLine($"Found {employees.Count} employees in the database.");
            }

            var emploiViewModel = new EmploiViewModel
            {
                Services = _context.Services?.ToList() ?? new List<Service>(),

                Employees = employees,
            };
            return View(emploiViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
