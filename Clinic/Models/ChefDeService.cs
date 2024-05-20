using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class ChefDeService
    {
        [Key]
        public int ChefDeServiceId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int? ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }
        public ICollection<Emploi>? Emplois { get; set; }

        // Propriété de navigation pour les employés qui sont également chefs de service
        public ICollection<Employee>? Employees { get; set; }
    }
}
