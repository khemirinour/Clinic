using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Clinic.Controllers.EmploiController;


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
        [HttpGet]
        public IActionResult Affiche()
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

            return View("Affiche", emploiViewModel);
        }

        [HttpGet]
        public IActionResult GetEmploiByServiceCategorieAndDate(int serviceId, int categorieId, DateTime dateSelected)
        {
            try
            {
                var emploiData = _context.DailyEmployments?
                    .Where(de => de.ServiceId == serviceId && de.CategorieId == categorieId && de.DateOfWeek == dateSelected)
                    .Include(de => de.Employee)
                    .ToList();

                if (emploiData != null && emploiData.Count > 0)
                {
                    var responseData = emploiData.Select(de => new EmployeData
                    {
                        EmployeeId = de.EmployeeId,
                        EmployeeName = de.Employee?.Name,
                        DayName = de.dayname,
                        PosteId = !string.IsNullOrEmpty(de.PosteId) ? int.Parse(de.PosteId) : (int?)null,
                        ReposId = !string.IsNullOrEmpty(de.ReposId) ? int.Parse(de.ReposId) : (int?)null,
                        SupplementId = !string.IsNullOrEmpty(de.SupplementId) ? int.Parse(de.SupplementId) : (int?)null,
                        PosteName = GetNameById(de.PosteId, _context.Postes),
                        ReposName = GetNameById(de.ReposId, _context.Repos),
                        SupplementName = GetNameById(de.SupplementId, _context.Supplements),
                        Matin = GetNameById(de.PosteId, _context.Postes),
                        ApresMidi = GetNameById(de.PosteId, _context.Postes),
                        GardeSoir = GetNameById(de.PosteId, _context.Postes),
                        Seance1Debut = GetNameById(de.PosteId, _context.Postes),
                        Seance1Fin = GetNameById(de.PosteId, _context.Postes),
                        Seance2Debut = GetNameById(de.PosteId, _context.Postes),
                        Seance2Fin = GetNameById(de.PosteId, _context.Postes),
                        Date_Jours = GetNameById(de.ReposId, _context.Repos),
                        Date_Joursfin = GetNameById(de.ReposId, _context.Repos),

                    }).ToList();

                    return Json(new { success = true, data = responseData });
                }
                else
                {
                    // Aucune donnée d'emploi trouvée pour les critères sélectionnés
                    return Json(new { success = false, message = "Aucune donnée d'emploi trouvée pour les critères sélectionnés." });
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs si nécessaire
                return Json(new { success = false, message = $"Une erreur s'est produite : {ex.Message}" });
            }
        }


        // Répétez le même processus pour les autres méthodes GetNameById.
        // Gérer les erreurs si nécessaire

        private string GetNameById(string? id, DbSet<Poste> context)
        {
            if (!string.IsNullOrEmpty(id))
            {
                // Vérifiez d'abord si l'ID est convertible en int
                if (int.TryParse(id, out int postId))
                {
                    var poste = context.FirstOrDefault(p => p.PosteId == postId);
                    if (poste != null)
                    {
                        // Construction de la chaîne de sortie avec les champs supplémentaires
                        string output = poste.Postename;

                        // Ajout des informations sur les séances si elles sont disponibles
                        if (poste.Matin)
                        {
                            output += " : Matin ";
                        }

                        if (poste.ApresMidi)
                        {
                            output += " : Après-midi ";
                        }

                        if (poste.GardeSoir)
                        {
                            output += " : Garde Soir ";
                        }

                        if (poste?.Seance1Debut != null && poste?.Seance1Fin != null)
                        {
                            output += $"Séance 1: {poste.Seance1Debut}-{poste.Seance1Fin}";
                        }

                        if (poste.Seance2Debut != null && poste.Seance2Fin != null)
                        {
                            output += $" Séance 2: {poste.Seance2Debut}-{poste.Seance2Fin}";
                        }

                        return output;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        private string GetNameById(string? id, DbSet<Repos> context)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (int.TryParse(id, out int reposId))
                {
                    var repos = context.FirstOrDefault(r => r.ReposId == reposId);
                    if (repos != null)
                    {
                        string output = repos.ReposName;

                        if (repos.Date_Jours != null)
                        {
                            output += $": Date: {repos.Date_Jours}";
                        }


                        return output;
                    }
                    else
                    {

                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }


        private string GetNameById(string? id, DbSet<Supplement> context)
        {
            if (!string.IsNullOrEmpty(id))
            {
                // Vérifiez d'abord si l'ID est convertible en int
                if (int.TryParse(id, out int supplementId))
                {
                    var supplement = context.FirstOrDefault(s => s.SupplementId == supplementId);
                    return supplement != null ? supplement.Nom : "";
                }
                else
                {

                    return ""; // ou une autre valeur par défaut appropriée
                }
            }
            return "";
        }

        // POST: api/Emploi/EnregistrerEmploi
        [HttpPost("EnregistrerEmploi")]
        public async Task<IActionResult> EnregistrerEmploi([FromBody] EnregistrerEmploiModel emploiModel)
        {
            if (!ModelState.IsValid || emploiModel == null || emploiModel.EmploiData == null)
            {
                return BadRequest("Données invalides ou manquantes.");
            }
            // Convertir ServiceSelected en int (ServiceId)
            int? serviceId = null;
            if (!string.IsNullOrEmpty(emploiModel.ServiceSelected) && int.TryParse(emploiModel.ServiceSelected, out int parsedServiceId))
            {
                serviceId = parsedServiceId;
            }

            // Convertir CategorieSelected en int (CategorieId)
            int? categorieId = null;
            if (!string.IsNullOrEmpty(emploiModel.CategorieSelected) && int.TryParse(emploiModel.CategorieSelected, out int parsedCategorieId))
            {
                categorieId = parsedCategorieId;
            }

            try
            {
                // Créer un nouvel objet Emploi
                var emploi = new Emploi
                {
                    DateOfWeek = DateTime.Parse(emploiModel.DateSelected), // Convertir la chaîne en DateTime
                    ServiceSelected = emploiModel.ServiceSelected,
                    CategorieSelected = emploiModel.CategorieSelected,
                    ServiceId = serviceId,
                    CategorieId = categorieId
                };

                // Ajouter l'emploi à la base de données
                _context.Emplois.Add(emploi);
                await _context.SaveChangesAsync(); // Sauvegarder les changements pour générer l'ID de l'emploi

                // Enregistrer les données d'emploi quotidien pour chaque employé
                foreach (var dailyEmploymentModel in emploiModel.EmploiData)
                {
                    // Créer un nouvel objet DailyEmployment
                    var dailyEmployment = new DailyEmployment
                    {
                        EmployeeId = dailyEmploymentModel.EmployeeId,
                        DateOfWeek = DateTime.Parse(emploiModel.DateSelected), // Convertir la chaîne en DateTime
                        ServiceId = serviceId, // Utiliser la variable serviceId convertie
                        CategorieId = categorieId, // Utiliser la variable categorieId convertie
                        dayname = dailyEmploymentModel.dayname,
                        PosteId = dailyEmploymentModel.PosteId,
                        ReposId = dailyEmploymentModel.ReposId,
                        SupplementId = dailyEmploymentModel.SupplementId,
                        EmploiId = emploi.EmploiId // Associer au même emploi
                    };

                    _context.DailyEmployments.Add(dailyEmployment);
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Données d'emploi enregistrées avec succès." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de l'enregistrement des données : {ex.Message}");
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
        public IActionResult GetEmploiByEmployee(int categorieId, DateTime dateOfWeek)
        {
            var userEmail = User.Identity.Name;
            var connectedEmployee = _context.Employee?.FirstOrDefault(e => e.Email == userEmail);

            if (connectedEmployee == null)
            {
                return Json(new { success = false, message = "Employé connecté non trouvé." });
            }

          

            var emploiData = _context.DailyEmployments?
                .Where(e => e.EmployeeId == connectedEmployee.EmployeeId && e.ServiceId == ServiceId && e.CategorieId == categorieId && e.DateOfWeek == dateOfWeek)
                .Include(e => e.Employee)
                .ToList();

            var responseData = emploiData?.Select(de => new EmployeData
            {

                EmployeeId = de.EmployeeId,
                EmployeeName = de.Employee?.Name,
                DayName = de.dayname,
                PosteId = !string.IsNullOrEmpty(de.PosteId) ? int.Parse(de.PosteId) : (int?)null,
                ReposId = !string.IsNullOrEmpty(de.ReposId) ? int.Parse(de.ReposId) : (int?)null,
                SupplementId = !string.IsNullOrEmpty(de.SupplementId) ? int.Parse(de.SupplementId) : (int?)null,
                PosteName = GetNameById(de.PosteId, _context.Postes),
                ReposName = GetNameById(de.ReposId, _context.Repos),
                SupplementName = GetNameById(de.SupplementId, _context.Supplements),
                Matin = GetNameById(de.PosteId, _context.Postes),
                ApresMidi = GetNameById(de.PosteId, _context.Postes),
                GardeSoir = GetNameById(de.PosteId, _context.Postes),
                Seance1Debut = GetNameById(de.PosteId, _context.Postes),
                Seance1Fin = GetNameById(de.PosteId, _context.Postes),
                Seance2Debut = GetNameById(de.PosteId, _context.Postes),
                Seance2Fin = GetNameById(de.PosteId, _context.Postes),
                Date_Jours = GetNameById(de.ReposId, _context.Repos),
                Date_Joursfin = GetNameById(de.ReposId, _context.Repos),
            });

            return Json(new { success = true, data = responseData });
        }
        [HttpGet]
        public IActionResult GetPostesReposAndSupplementsByCategorie(int CategorieId)
        {
            try
            {
                // Validation du paramètre CategorieId
                if (CategorieId <= 0)
                {
                    return Json(new { success = false, message = "L'identifiant de catégorie n'est pas valide." });
                }

                // Récupération des postes, repos et suppléments associés à la catégorie
                var postes = _context.Postes?.Where(p => p.CategorieId == CategorieId).ToList();
                var repos = _context.Repos?.Where(r => r.CategorieId == CategorieId).ToList();
                var supplements = _context.Supplements?.Where(s => s.CategorieId == CategorieId).ToList();

                return Json(new { success = true, postes, repos, supplements });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des postes, repos et suppléments.");
                return Json(new { success = false, message = "Une erreur s'est produite lors de la récupération des données. Veuillez réessayer." });
            }
        }



        public class EmployeData
        {
            public int EmployeeId { get; set; }
            public string? EmployeeName { get; set; }
            public string? DayName { get; set; }
            public int? PosteId { get; set; }
            public int? ReposId { get; set; }
            public int? SupplementId { get; set; }
            public string? PosteName { get; set; }
            public string? ReposName { get; set; }
            public string? SupplementName { get; set; }
            public string? Matin { get; set; }
            public string? ApresMidi { get; set; }

            public string? GardeSoir { get; set; }
            public string? Seance1Debut { get; set; }
            public string? Seance1Fin { get; set; }
            public string? Seance2Debut { get; set; }
            public string? Seance2Fin { get; set; }
            public string? Date_Jours { get; set; }

            public string? Date_Joursfin { get; set; }




        }
        [HttpGet]
        public IActionResult GetService(int employeeId)
        {
            var employee = _context.Employee.Find(employeeId);
            if (employee != null)
            {
                return Json(new { success = true, data = employee.ServiceId });
            }
            return Json(new { success = false });
        }
       
    }
}
