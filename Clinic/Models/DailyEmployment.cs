
using Clinic.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class DailyEmployment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public string? DateofWeek { get; set; }
        public string?  Service { get; set; }

        public string? Categorie { get; set; }
        public List<Poste>? Postes { get; set; }
        public List<Repos>? Repos { get; set; }
        public List<Supplement>? Supplements { get; set; }

        
    }
}
