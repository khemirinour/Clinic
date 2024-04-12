using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;    

        public string? Description { get; set; }

        public string? Password { get; set; }

        // Propriétés de navigation
        public ICollection<Emploi>? Emplois { get; set; }

       
        public HR? HR { get; set; }
        public ICollection<Employee>? Employees { get; set; }
              
        public ICollection<ChefDeService>? ChefsDeService { get; set; }
    }
}
