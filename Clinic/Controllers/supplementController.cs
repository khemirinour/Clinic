using Microsoft.AspNetCore.Mvc;
using Clinic.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Controllers
{
    public class SupplementController : Controller
    {
        private readonly ClinicDbContext _context;

        public SupplementController(ClinicDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.CategorieList = _context.Categories.ToList();
            return View();
        }
      public IActionResult Index()
        {
            ViewBag.CategorieList = GetCategoriesSelectList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Supplement supplement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplement);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieList = _context.Categories.ToList();
            return View(supplement);
        }

        public IActionResult Delete()
        {
            var supplements = _context.Supplements.ToList();
            return View(supplements);
        }
        private SelectList GetCategoriesSelectList()
        {
            var categories = _context.Categories?.ToList() ?? new List<Categorie>();
            return new SelectList(categories, "CategorieId", "CategorieName");
        }
        [HttpPost]
        public IActionResult Delete(int SupplementId, int CategorieId)
        {
            var supplement = _context.Supplements.FirstOrDefault(s => s.SupplementId == SupplementId && s.CategorieId == CategorieId);
            if (supplement != null)
            {
                _context.Supplements.Remove(supplement);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Delete", _context.Supplements.ToList());
        }
    }
}
