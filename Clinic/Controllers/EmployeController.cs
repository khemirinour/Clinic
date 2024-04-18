using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        private void PopulateServiceList()
        {
            var services = _context.Services.ToList();
            ViewBag.ServiceList = new SelectList(services, "Id", "Name");
        }
    }
}
