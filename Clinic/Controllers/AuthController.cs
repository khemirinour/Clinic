using Clinic.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Net.Mail;

namespace Clinic.Controllers
{
    public class AccountController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        public AccountController(ClinicDbContext context, ILogger<AccountController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        private string GenerateJwtToken(Employee user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(_configuration["Jwt:ExpireHours"]));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.EmployeeId.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("ServiceId", user.ServiceId.ToString()),
                new Claim("IsChefDeService", user.IsChefDeService.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var employee = await _context.Employee
                    .Include(e => e.Service)
                    .FirstOrDefaultAsync(e => e.Email == username && e.Password == password);

                if (employee != null && employee.Approved == true)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId.ToString()),
                        new Claim(ClaimTypes.Name, employee.Name),
                        new Claim("ServiceId", employee.ServiceId.ToString()),
                        new Claim("IsChefDeService", employee.IsChefDeService.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Login");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    var isChefDeService = employee.IsChefDeService ?? false;
                    var redirectUrl = isChefDeService ? Url.Action("Create", "Emploi") : Url.Action("Affiche", "Emploi");

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
                    _logger.LogWarning("Login failed: Invalid username or password for {username}", username);
                    return Json(new { success = false, message = "Invalid username or password." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login process for {username}", username);
                return Json(new { success = false, message = "An error occurred during login." });
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

        public class ApproveEmployeeRequest
        {
            public int EmployeeId { get; set; }
            public int TotalHours { get; set; }
        }

        [HttpPost]
        public IActionResult ApproveEmployee([FromBody] ApproveEmployeeRequest request)
        {
            try
            {
                var employee = _context.Employee.FirstOrDefault(e => e.EmployeeId == request.EmployeeId);

                if (employee != null)
                {
                    employee.Approved = true;
                    employee.TotalWeeklyHours = request.TotalHours;
                    _context.SaveChanges();
                    return Ok(new { message = "Employee approved successfully." });
                }
                else
                {
                    return NotFound("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while approving the employee.", details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.IsChefDeService = false;
                    employee.Approved = false;

                    _context.Employee.Add(employee);
                    await _context.SaveChangesAsync();

                    var notification = new Notification
                    {
                        ServiceId = employee.ServiceId,
                        Message = $"Nouvel employé inscrit: {employee.Name}",
                        Date = DateTime.Now
                    };

                    _context.Notification.Add(notification);
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
        public IActionResult GetUnapprovedEmployees(int serviceId)
        {
            try
            {
                var unapprovedEmployees = _context.Employee
                    .Where(e => e.ServiceId == serviceId && !(bool)e.Approved)
                    .Select(e => new EmploiViewModel
                    {
                        EmployeeId = e.EmployeeId,
                        EmployeeName = e.Name,
                        Email = e.Email
                    }).ToList();

                return Json(unapprovedEmployees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while fetching unapproved employees.", details = ex.Message });
            }
        }

      


        [HttpPost]
        public IActionResult ApproveEmployeeById([FromBody] ApproveEmployeeRequest request)
        {
            try
            {
                var employee = _context.Employee.FirstOrDefault(e => e.EmployeeId == request.EmployeeId);

                if (employee != null)
                {
                    employee.Approved = true;
                    employee.TotalWeeklyHours = request.TotalHours;
                    _context.SaveChanges();


                    return Ok(new { message = "Employee approved successfully." });
                }
                else
                {
                    return NotFound("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while approving the employee.", details = ex.Message });
            }
        }

   
        public async Task<IActionResult> ApproveRegistrationRequests(int serviceId)
        {
            try
            {
                var pendingEmployees = await _context.Employee
                    .Include(e => e.Service)
                    .Where(e => e.ServiceId == serviceId && (e.Approved == false || e.Approved == null))
                    .ToListAsync();

                if (pendingEmployees == null || !pendingEmployees.Any())
                {
                    _logger.LogInformation("No pending employees found for serviceId: {serviceId}", serviceId);
                    return View(new List<EmploiViewModel>());
                }

                var model = pendingEmployees.Select(employee => new EmploiViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.Name,
                    ServiceId = employee.ServiceId
                }).ToList();

                _logger.LogInformation("Model type: {type}", model.GetType());
                ViewBag.ServiceId = serviceId;
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving pending registration requests.");
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving pending registration requests.");
                return View(new List<EmploiViewModel>());
            }
        }

    }
}
