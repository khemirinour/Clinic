using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public string ServiceName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Password { get; set; }

        // Propriétés de navigation
        public ICollection<Emploi>? Emplois { get; set; }

        // Clé étrangère vers le Chef de Service
        public int? ChefDeServiceId { get; set; }
        public ChefDeService? ChefDeService { get; set; }

        // Clé étrangère vers le HR
        public int? HRId { get; set; }
        public HR? HR { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        [NotMapped]
       public List<Service> Services { get; set; } = new List<Service>(); // Initialisez la liste ici

        // Clé étrangère vers un Chef de Service qui est également un Employee
        public int? ChefServiceId { get; set; }
        public Employee? ChefService { get; set; }
        public ICollection<ChefDeService>? ChefsDeService { get; set; }
    }
}
