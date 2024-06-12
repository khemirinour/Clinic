using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Ajout de cette directive

namespace Clinic.Controllers
{
    public class ReposController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly ILogger<ReposController> _logger; // Déclarer un logger

        // Injecter le logger dans le constructeur
        public ReposController(ClinicDbContext context, ILogger<ReposController> logger)
        {
            _context = context;
            _logger = logger; // Initialiser le logger
        }

        // Action pour afficher le formulaire d'ajout de repos
        public IActionResult Index()
        {
            ViewBag.ReposList = GetReposSelectList();
            ViewBag.CategorieList = GetCategoriesSelectList();
            return View();
        }

        private SelectList GetCategoriesSelectList()
        {
            var categories = _context.Categories?.ToList() ?? new List<Categorie>();
            return new SelectList(categories, "CategorieId", "CategorieName");
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Repos repos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(repos);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'ajout du repos.");
                ModelState.AddModelError("", "Une erreur s'est produite lors de l'ajout du repos.");
            }
            ViewBag.CategorieList = GetCategoriesSelectList();
            return View(repos);
        }

        // Action pour afficher le formulaire de mise à jour de repos
        public async Task<IActionResult> Update(int id)
        {
            var repos = await _context.Repos.FindAsync(id);
            if (repos == null)
            {
                return NotFound();
            }
            return View(repos);
        }

        // Action pour traiter le formulaire de mise à jour de repos
        private SelectList GetReposSelectList()
        {
            var repos = _context.Repos.ToList();
            return new SelectList(repos, "ReposId", "ReposName");
        }

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Update(int id, Repos repos)
{
    if (id != repos.ReposId)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            // Retrouver le repos à partir de l'identifiant sélectionné dans le formulaire
            var existingRepos = await _context.Repos.FindAsync(repos.ReposId);

            if (existingRepos == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés du repos avec les nouvelles valeurs
            existingRepos.ReposName = repos.ReposName;
            existingRepos.Date_Jours = repos.Date_Jours;
            existingRepos.CategorieId = repos.CategorieId;

            _context.Update(existingRepos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirection vers l'index
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReposExists(repos.ReposId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }
    return View(repos);
}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int reposId, int categorieId)
        {
            try
            {
                var repos = await _context.Repos.FirstOrDefaultAsync(s => s.ReposId == reposId && s.CategorieId == categorieId);
                if (repos == null)
                {
                    return NotFound();
                }

                _context.Repos.Remove(repos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après la suppression du repos
            }
            catch (Exception ex)
            {
                // Enregistrez l'exception dans les logs
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du repos.");
                throw; // Rethrow l'exception pour qu'elle soit gérée par le framework
            }
        }


        private bool ReposExists(int id)
        {
            return _context.Repos.Any(e => e.ReposId == id);
        }
    }
}
