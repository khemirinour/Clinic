using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            var emplois = _context.Emplois?.ToList();
            return View(emplois);
        }

        public IActionResult MonAction()
        {
            try
            {
                var emploi = _context.Emplois?.FirstOrDefault();
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
                Services = _context.Services?.ToList(),
                Categories = _context.Categories?.ToList(),
                Postes = _context.Postes?.ToList(),
                Repos = _context.Repos?.ToList(),
                Days = _context.Days?.ToList(),
                Employees = _context.Employee?.ToList(),
                Supplements = _context.Supplements?.ToList()
            };

            return View("Create", emploiViewModel);
        }

        [HttpPost]
        public IActionResult EnregistrerEmploi([FromBody] EmploiViewModel emploiViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
               
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine(ex);

                return StatusCode(500, "An error occurred while saving the data.");
            }
        }






        [HttpGet]
        public IActionResult GetServices()
        {
            try
            {
                var services = _context.Services?.ToList();
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
                var employees = _context.Employee?.Where(e => e.ServiceId == ServiceId).ToList();
                return Json(new { success = true, employees });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des employés.");
                return Json(new { success = false, message = "Une erreur s'est produite lors de la récupération des employés." });
            }
        }
        [HttpGet]
        public IActionResult GetPostesReposAndSupplementsByCategorie(int CategorieId)
        {
            try
            {
                var postes = _context.Postes?.Where(p => p.CategorieId == CategorieId).ToList();
                var repos = _context.Repos?.Where(r => r.CategorieId == CategorieId).ToList();
                var supplements = _context.Supplements?.Where(s => s.CategorieId == CategorieId).ToList();

                if (postes == null || repos == null || supplements == null)
                {
                    return Json(new { success = false, message = "Aucune donnée correspondante trouvée." });
                }

                return Json(new { success = true, postes, repos, supplements });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des postes, repos et supplements.");
                return Json(new { success = false, message = "Une erreur s'est produite lors de la récupération des postes, repos et supplements." });
            }
        }


    }
}
