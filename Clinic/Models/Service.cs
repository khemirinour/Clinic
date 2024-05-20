using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Service
    {
        [Key]
        public int?  Id { get; set; }

        public string? Name { get; set; }

        public string? Password { get; set; }

        // Propriétés de navigation
        public ICollection<Emploi>? Emplois { get; set; }

        public ICollection<Employee>? Employees { get; set; }

        [ForeignKey("ChefDeService")]
        public int? ChefDeServiceId { get; set; }
        public ChefDeService? ChefDeService { get; set; }
    }
}