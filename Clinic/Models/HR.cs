using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class HR
    {
        public int HRId { get; set; }

        [Required]
        public string HRName { get; set; } = string.Empty;
      public string? Email { get; set; }

       public string? Password { get; set; }
        public List<Service> Services { get; set; } = new List<Service>(); // Initialisez la liste ici

        // Propriété de navigation
        public ICollection<Emploi>? Emplois { get; set; }
    }
}