using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ClinicDbContext _context;

        public NotificationController(ClinicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications(int serviceId)
        {
            var notifications = await _context.Notification
                .Where(n => n.ServiceId == serviceId && !(bool)n.IsRead)
                .ToListAsync(); // Assurez-vous que ToListAsync est importé

            return Json(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int serviceId)
        {
            var notifications = await _context.Notification
                .Where(n => n.ServiceId == serviceId && (bool)!n.IsRead)
                .ToListAsync();

            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUnreadCount(int serviceId)
        {
            var count = await _context.Notification
                .CountAsync(n => n.ServiceId == serviceId && !(bool)n.IsRead); // Assurez-vous que CountAsync est importé

            return Json(count);
        }
    }
}
