using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging; // Pour ILogger
using Microsoft.EntityFrameworkCore; // Pour les extensions EF Core asynchrones

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

        // Action pour ajouter un poste
        [HttpPost]
        public async Task<IActionResult> AddPoste(Poste model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Postes.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erreur lors de l'ajout du poste.");
                    ModelState.AddModelError("", "Une erreur s'est produite lors de l'ajout du poste.");
                }
            }

            return View(model);
        }

        // Action pour supprimer un poste
        [HttpPost]
        public async Task<IActionResult> DeletePoste(string nom, int categorieId)
        {
            try
            {
                var poste = await _context.Postes
                    .FirstOrDefaultAsync(p => p.Postename == nom && p.CategorieId == categorieId);

                if (poste == null)
                {
                    return NotFound();
                }

                _context.Postes.Remove(poste);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du poste.");
                throw;
            }
        }

        // Action pour afficher la liste des postes (page d'accueil par exemple)
        public IActionResult Index()
        {
            var postes = _context.Postes.ToList();
            return View(postes);
        }
    }
}
