using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Clinic.Controllers
{
    public class EmployeController : Controller
    {
        private readonly ClinicDbContext _context;

        public EmployeController(ClinicDbContext context)
        {
            _context = context;
        }



        public IActionResult Create()
        {
            var services = _context.Services.ToList();

            if (services.Any())
            {
                ViewBag.ServiceList = new SelectList(services, "ServiceId", "ServiceName");
            }
            else
            {
                ViewBag.ServiceList = new SelectList(new List<string> { "Aucun service disponible" });
            }

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

            // Recharger la liste des services en cas de modèle non valide
            ViewBag.ServiceList = new SelectList(_context.Services.ToList(), "ServiceId", "ServiceName");
            return View(newEmployee);
        }










    }
}
