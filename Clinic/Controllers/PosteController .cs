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
            // Chargez les catégories et affectez-les à la ViewBag
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

        // Action pour afficher la vue de suppression de supplément
        public IActionResult DeleteSupplement()
        {
            // Chargez les catégories et affectez-les à la ViewBag
            ViewBag.CategorieList = _context.Categories
                .Select(c => new SelectListItem { Value = c.CategorieId.ToString(), Text = c.CategorieName })
                .ToList();

            return View();
        }

        // Action pour traiter le formulaire de suppression de supplément
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSupplement(string nom, int categorieId)
        {
            try
            {
                var supplement = await _context.Supplements.FirstOrDefaultAsync(s => s.Nom == nom && s.CategorieId == categorieId);
                if (supplement == null)
                {
                    return NotFound();
                }

                _context.Supplements.Remove(supplement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après la suppression du supplement
            }
            catch (Exception ex)
            {
                // Enregistrez l'exception dans les logs
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du supplement.");
                throw; // Rethrow l'exception pour qu'elle soit gérée par le framework
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePoste(string nom, int categorieId)
        {
            try
            {
                ViewBag.CategorieList = _context.Categories
                    .Select(c => new { CategorieId = c.CategorieId, CategorieName = c.CategorieName })
                    .ToList();

                var postes = await _context.Postes.FirstOrDefaultAsync(s => s.Postename == nom && s.CategorieId == categorieId);
                if (postes == null)
                {
                    return NotFound();
                }

                _context.Postes.Remove(postes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après la suppression du repos
            }
            catch (Exception ex)
            {
                // Enregistrez l'exception dans les logs
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du postes.");
                throw; // Rethrow l'exception pour qu'elle soit gérée par le framework
            }
        }

        // Add Repos
        public IActionResult AddRepos()
        {
            ViewBag.CategorieList = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRepos(Repos repos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategorieList = GetCategoriesSelectList();
            return View(repos);
        }

        // Update Repos
        public IActionResult UpdateRepos()
        {
            ViewBag.CategorieList = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRepos(Repos repos)
        {
            if (ModelState.IsValid)
            {
                _context.Update(repos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategorieList = GetCategoriesSelectList();
            return View(repos);
        }

        // Delete Repos
        public IActionResult DeleteRepos()
        {
            ViewBag.CategorieList = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRepos(string nom, int categorieId)
        {
            try
            {
                var repos = await _context.Repos.FirstOrDefaultAsync(r => r.ReposName == nom && r.CategorieId == categorieId);
                if (repos == null)
                {
                    return NotFound();
                }

                _context.Repos.Remove(repos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du repos.");
                throw;
            }
        }

        private SelectList GetCategoriesSelectList()
        {
            var categories = _context.Categories?.ToList() ?? new List<Categorie>();
            return new SelectList(categories, "CategorieId", "CategorieName");
        }
    }
}
