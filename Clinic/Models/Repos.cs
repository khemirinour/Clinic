using System;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Repos
    {
        [Key]
        [Display(Name = "ID")]
        public int ReposId { get; set; }

        [Required]
        public string ReposName { get; set; } = string.Empty;

    
        public DateTime?  Date_Jours { get; set; }

        public DateTime? Date_Joursfin { get; set; }

        public ICollection<EmployeeRepos>? Employee { get; set; }

        // Clé étrangère vers la catégorie du repos
        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        // Clé étrangère vers l'employé
        public int? EmployeeId { get; set; }
        // Autres propriétés...
        public int? EmploiId { get; set; }
        public Emploi?   Emploi { get; set; }
        public int? PositionX { get; set; } 
        public int? PositionY { get; set; } 
    }
}
