using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Controllers
{
    public class PosteController : Controller
    {
        private readonly ClinicDbContext _context;

        public PosteController(ClinicDbContext context)
        {
            _context = context;
        }

        // POST: Poste/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Poste poste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après la création du poste
            }

            // Recharger la liste des catégories en cas de modèle non valide
            var categories = _context.Categories.ToList();
            if (categories.Any())
            {
                ViewBag.CategorieList = new SelectList(categories, "CategorieId", "CategorieName");
            }
            else
            {
                ViewBag.CategorieList = new SelectList(new List<string> { "Aucune catégorie disponible" });
            }

            return View(poste);
        }

        // GET: Poste/AddRepos
        public IActionResult AddRepos()
        {
            var categories = _context.Categories.ToList();

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

        // GET: Poste/AddSupplement

        public IActionResult AddSupplement()
        {
            return View();
        }

        // POST: Poste/AddSupplement
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSupplement(Supplement supplement)
        {
            var employeeName = supplement.Employee?.Name;

            if (ModelState.IsValid)
            {
                _context.Add(supplement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirection vers l'action Index après l'ajout du supplément
            }

            return View(supplement);
        }


        // Autres actions du contrôleur (Index, Edit, Delete, etc.)
    }
}
