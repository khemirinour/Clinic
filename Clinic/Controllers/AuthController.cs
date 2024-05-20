using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class AccountController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ClinicDbContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var employee = await _context.Employee?
                    .Include(e => e.Service)
                    .FirstOrDefaultAsync(e => e.Email == username && e.Password == password);

                if (employee != null && employee.Approved == true)
                {
                    // Authentication successful
                    var redirectUrl = (bool)employee.IsChefDeService ? Url.Action("Create", "Emploi") : Url.Action("Affiche", "Emploi");
                    return Json(new
                    {
                        success = true,
                        redirectUrl = redirectUrl,
                        employeeId = employee.EmployeeId,
                        serviceId = employee.ServiceId
                    });
                }
                else
                {
                    return Json(new { success = false, message = "Nom d'utilisateur ou mot de passe incorrect." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login process.");
                return Json(new { success = false, message = "Une erreur s'est produite lors de la connexion." });
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            var services = _context.Services?.ToList();
            var serviceList = new SelectList(services, "Id", "Name");
            var model = new Login { ServiceList = serviceList };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Employee employee)
        {
            try
            {

                


                if (employee.Email!=null)
                {
                    employee.IsChefDeService = false;
                    employee.Approved = false;
               
               
                    _context.Employee.Add(employee);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration process.");
                ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de l'enregistrement de l'utilisateur.");
            }

            return Json(new { success = false, message = "Registration failed. Please check the form." });
        }

        [HttpGet]
        public async Task<IActionResult> ApproveRegistrationRequests()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int userIdInt = int.Parse(userId);

                var chefDeService = await _context.Employee
                    .FirstOrDefaultAsync(c => c.EmployeeId == userIdInt && c.IsChefDeService == true);

                if (chefDeService != null)
                {
                    var pendingEmployees = await _context.Employee
                        .Include(e => e.Service)
                        .Where(e => e.Service.ChefDeServiceId == userIdInt && e.Approved == false)
                        .ToListAsync();

                    return View(pendingEmployees);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving pending registration requests.");
                ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de la récupération des demandes d'inscription en attente.");
                return View(new List<Employee>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRegistration(int employeeId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int userIdInt = int.Parse(userId);

                var employee = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.Service.ChefDeServiceId == userIdInt);

                if (employee != null)
                {
                    employee.Approved = true;
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("ApproveRegistrationRequests");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving registration request.");
                ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de l'approbation de la demande d'inscription.");
                return RedirectToAction("ApproveRegistrationRequests");
            }
        }
    }
}
