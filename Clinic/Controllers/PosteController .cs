using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clinic.Controllers
{
    public class PosteController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly ILogger<PosteController> _logger;

        public PosteController(ClinicDbContext context, ILogger<PosteController> logger)
        {
            _context = context;
            _logger = logger;
        }

        private SelectList GetPosteSelectList(int? selectedPosteId = null)
        {
            var postes = _context.Postes.ToList();
            return new SelectList(postes, "PosteId", "Postename", selectedPosteId);
        }


        private SelectList GetCategoriesSelectList()
        {
            var categories = _context.Categories?.ToList() ?? new List<Categorie>();
            return new SelectList(categories, "CategorieId", "CategorieName");
        }

        public IActionResult Index()
        {
            ViewBag.PosteList = GetPosteSelectList();
            ViewBag.CategorieList = GetCategoriesSelectList();
            return View();
        }

        public IActionResult SelectPosteForUpdate()
        {
            ViewBag.PosteList = GetPosteSelectList();
            return View();
        }

        public IActionResult SelectPosteForDelete()
        {
            ViewBag.PosteList = GetPosteSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddPoste(Poste poste)
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

        // Action to display the form for updating a poste
        public async Task<IActionResult> UpdatePoste(int id)
        {
            var poste = await _context.Postes.FindAsync(id);
            if (poste == null)
            {
                return NotFound();
            }
            ViewBag.CategorieList = GetCategoriesSelectList();
            return View(poste);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePoste(int id, Poste updatedPoste)
        {
            try
            {
                var poste = await _context.Postes.FindAsync(id);
                if (poste == null)
                {
                    return NotFound();
                }

                poste.Postename = updatedPoste.Postename;
                poste.Matin = updatedPoste.Matin;
                poste.ApresMidi = updatedPoste.ApresMidi;
                poste.GardeSoir = updatedPoste.GardeSoir;
                poste.Seance1Debut = updatedPoste.Seance1Debut;
                poste.Seance1Fin = updatedPoste.Seance1Fin;
                poste.Seance2Debut = updatedPoste.Seance2Debut;
                poste.Seance2Fin = updatedPoste.Seance2Fin;
                poste.Actif = updatedPoste.Actif;
                poste.CategorieId = updatedPoste.CategorieId;

                _context.Update(poste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour du poste.");
                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePoste(int id)
        {
            try
            {
                var poste = await _context.Postes.FindAsync(id);
                if (poste == null)
                {
                    return NotFound();
                }

                _context.Postes.Remove(poste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du poste.");
                throw;
            }

        }

        }
}
