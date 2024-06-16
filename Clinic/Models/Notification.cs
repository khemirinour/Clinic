using System;

namespace Clinic.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int? ServiceId { get; set; } // ID du service du chef
        public string? Message { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsRead { get; set; } = false;
    }
}
