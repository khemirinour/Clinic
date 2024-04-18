using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    public class PosteController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly ILogger<PosteController> _logger; // Déclarer un logger

        // Injecter le logger dans le constructeur
        public PosteController(ClinicDbContext context, ILogger<PosteController> logger)
        {
            _context = context;
            _logger = logger; // Initialiser le logger
        }
        // Action pour afficher le formulaire d'ajout de poste
        public IActionResult AddPoste()
        {
            var categories = _context.Categories?.ToList();

            if (categories.Any())
            {
                ViewBag.CategorieList = new SelectList(categories, "CategorieId", "CategorieName");
            }
            else
            {
                ViewBag.CategorieList = new SelectList(new List<string> { "Aucune catégorie disponible" });
            }

            return View();
        }

        // Action pour traiter le formulaire d'ajout de poste
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPoste(Poste poste)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(poste);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après l'ajout du poste
                }
                catch (Exception ex)
                {
                    // Log de l'exception pour le débogage
                    _logger.LogError(ex, "Erreur lors de l'ajout du poste.");
                    // Optionnel : retourner une vue d'erreur ou un message à l'utilisateur
                    ModelState.AddModelError("", "Une erreur s'est produite lors de l'ajout du poste.");
                    return View(poste);
                }
            }

            // Si le modèle n'est pas valide, retourner la vue avec les erreurs de validation
            return View(poste);
        }
        public IActionResult AddSupplement()
        {
            var categories = _context.Categories?.ToList();
            var viewModel = new AddSupplementViewModel();

            if (categories.Any())
            {
                ViewBag.CategorieList = new SelectList(categories, "CategorieId", "CategorieName");
                viewModel.CategoriesWithSupplements = _context.Categories
                    .Include(c => c.Supplements)
                    .Select(c => new CategoryWithSupplements
                    {
                        CategorieName = c.CategorieName,
                        Supplements = c.Supplements.ToList()
                    })
                    .ToList();
            }
            else
            {
                ViewBag.CategorieList = new SelectList(new List<string> { "Aucune catégorie disponible" });
            }

            viewModel.NewSupplement = new Supplement();
            return View(viewModel); // Retourner le modèle correct
        }



        // Action pour traiter le formulaire d'ajout de supplément
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSupplement(Supplement supplement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(supplement);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après l'ajout du supplément
                }
                catch (Exception ex)
                {
                    // Log de l'exception pour le débogage
                    _logger.LogError(ex, "Erreur lors de l'ajout du supplément.");
                    // Optionnel : retourner une vue d'erreur ou un message à l'utilisateur
                    ModelState.AddModelError("", "Une erreur s'est produite lors de l'ajout du supplément.");
                    return View(supplement);
                }
            }

            // Si le modèle n'est pas valide, retourner la vue avec les erreurs de validation
            return View(supplement);
        }

        public IActionResult AddRepos()
        {
            var categories = _context.Categories?.ToList();

            if (categories.Any())
            {
                ViewBag.CategorieList = new SelectList(categories, "CategorieId", "CategorieName");
            }
            else
            {
                ViewBag.CategorieList = new SelectList(new List<string> { "Aucune catégorie disponible" });
            }

            return View();
        }


        // POST: Poste/AddRepos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRepos(Repos repos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après l'ajout du repos
            }

            return View(repos);
        }
   

        // Autres actions du contrôleur (Index, Edit, Delete, etc.)
    }
}
