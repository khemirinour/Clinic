using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Build.Framework;

namespace Clinic.Controllers
{
    public class EmployeController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly ILogger<EmployeController> _logger;

        public EmployeController(ClinicDbContext context, ILogger<EmployeController> logger)
        {
            _context = context;
            _logger = logger;
        }
       
        public IActionResult Create()
        {
            PopulateServiceList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateServiceList();
            return View(newEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployee(string employeeName)
        {
            try
            {
                var employee = await _context.Employee.FirstOrDefaultAsync(e => e.Name == employeeName);
                if (employee == null)
                {
                    return NotFound();
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après la suppression de l'employé
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression de l'employé.");
                throw; // Rethrow l'exception pour qu'elle soit gérée par le framework
            }
        }

        // Méthode pour peupler la liste des services
        private void PopulateServiceList()
        {
            var services = _context.Services?.ToList();
            ViewBag.ServiceList = new SelectList(services, "Id", "Name");
        }
    }
}
