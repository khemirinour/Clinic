
namespace Clinic.Models
{
    public class EmploymentViewModel
    {
        public string? EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public List<string>? DayNames { get; set; } // Renommé de dayname à DayNames
        public List<EmploymentDetailsViewModel>? Employments { get; set; } // Mis à jour en List<EmploymentDetailsViewModel>
    }

    public class EmploymentDetailsViewModel
    {
        public string? Poste { get; set; }
        public string? Repos { get; set; }
        public string? Supplement { get; set; }
        public string? DayName { get; set; } // Renommé de dayname à DayName
    }
}
