using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string? Name { get; set; } 

        [EmailAddress]
        public string? Email { get; set; }
        public string? Sex { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Nationality { get; set; }
        public string?  Password { get; set; }
        public DateTime? RecruitmentDate { get; set; }
        public string? City { get; set; }
        public bool? IsChefDeService { get; set; }
        public int? TotalWeeklyHours { get; set; }

        public int? CategorieId { get; set; }
        public Categorie? Categorie { get; set; }
        public List<Poste>? Postes { get; set; }

        // Propriété de navigation pour les Repos
        public List<Repos>? Repos { get; set; }

        // Propriété de navigation pour les Suppléments
        public List<Supplement>? Supplements { get; set; }
        public bool? Approved { get; set; } 

        [ForeignKey("Emploi")]
        public int? EmploiId { get; set; }
        public Emploi? Emploi { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

    }
}