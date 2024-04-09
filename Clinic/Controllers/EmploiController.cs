using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinic.Controllers
{
    public class EmploiController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly ILogger<EmploiController> _logger;

        public EmploiController(ClinicDbContext context, ILogger<EmploiController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var emplois = _context.Emplois.ToList();
            return View(emplois);
        }

        public IActionResult MonAction()
        {
            try
            {
                var emploi = _context.Emplois.FirstOrDefault();
                if (emploi == null) throw new Exception("L'objet emploi est null.");
                return View(emploi);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une exception s'est produite dans MonAction");
                ViewBag.ErrorMessage = "Une erreur s'est produite. Veuillez contacter l'administrateur du site.";
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var emploiViewModel = new EmploiViewModel
            {
                Services = _context.Services.ToList(),
                Categories = _context.Categories.ToList(),
                Postes = _context.Postes.ToList(),
                Repos = _context.Repos.ToList(),
                Days = _context.Days.ToList(),
                Employees = _context.Employee.ToList(),
                Supplements = _context.Supplements.ToList()
            };

            return View("Create", emploiViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Emploi emploi)
        {
            if (emploi == null)
            {
                ViewBag.ErrorMessage = "L'objet emploi est null.";
                return View("Error");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Services = _context.Services.ToList();
                return View(emploi);
            }

            try
            {
                _context.Emplois.Add(emploi);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la création de l'emploi.");
                ViewBag.ErrorMessage = "Une erreur s'est produite lors de la création de l'emploi.";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EnregistrerEmploi(int serviceSelected,DateTime dateSelected)
        {
            Service service = await _context.Services.FindAsync(serviceSelected);

            return View("Error");
            //if (emploiViewModel == null || emploiViewModel.Emploi == null)
            //{
            //    ViewBag.ErrorMessage = "L'objet emploiViewModel ou son propriété Emploi est null.";
            //    return View("Error");
            //}

            //if (!ModelState.IsValid)
            //{
            //    // Repopulate ViewModel properties if needed
            //    return View("Create", emploiViewModel);
            //}

            //try
            //{
            //    _context.Emplois.Add(emploiViewModel.Emploi);
            //    _context.SaveChanges();
            //    return RedirectToAction(nameof(Index));
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Une erreur s'est produite lors de l'enregistrement de l'emploi.");
            //    ViewBag.ErrorMessage = "Une erreur s'est produite lors de l'enregistrement de l'emploi.";
            //    return View("Error");
            //}
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            try
            {
                var services = _context.Services.ToList();
                return Json(new { success = true, services });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving services.");
                return Json(new { success = false, message = "An error occurred while retrieving services." });
            }
        }

        [HttpGet]
        public IActionResult GetEmployeesByService(int ServiceId)
        {
            try
            {
                var employees = _context.Employee.Where(e => e.ServiceId == ServiceId).ToList();
                return Json(new { success = true, employees });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des employés.");
                return Json(new { success = false, message = "Une erreur s'est produite lors de la récupération des employés." });
            }
        }

        [HttpGet]
        public IActionResult GetPostesAndReposByCategorie(int categorieId)
        {
            try
            {
                var postes = _context.Postes.Where(p => p.CategorieId == categorieId).ToList();
                var repos = _context.Repos.Where(r => r.CategorieId == categorieId).ToList();
                return Json(new { success = true, postes, repos });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des postes et repos.");
                return Json(new { success = false, message = "Une erreur s'est produite lors de la récupération des postes et repos." });
            }
        }

        [HttpGet]
        public IActionResult GetSupplements()
        {
            try
            {
                var supplements = _context.Supplements.ToList();
                return Json(new { success = true, supplements });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving supplements.");
                return Json(new { success = false, message = "An error occurred while retrieving supplements." });
            }
        }
    }
}

