using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Emploi
    {
        [Key]
        public int EmploiId { get; set; }

        public DateTime? DateOfWeek { get; set; } // Changer le nom de la propriété

        // Ajouter une propriété pour le nom de la catégorie sélectionnée
        public string? ServiceSelected { get; set; }
        public string? CategorieSelected { get; set; }
        public ICollection<Day>? Days { get; set; }
        public ICollection<Poste>? Postes { get; set; }
        public ICollection<Repos>? Repos { get; set; }
        public ICollection<Supplement>? Supplements { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public int? EmployeeId { get; set; }   
        public ICollection<DailyEmployment>?   DailyEmployments { get; set; }
        [ForeignKey("Service")]
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }

        [ForeignKey("Categorie")]
        public int? CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        public Emploi()
        {
            // Initialisation des collections
            Days = new List<Day>();
            Postes = new List<Poste>();
            Repos = new List<Repos>();
            Supplements = new List<Supplement>();
            Employees = new List<Employee>();
            DailyEmployments = new List<DailyEmployment>();
            DateOfWeek = DateTime.Now; // Initialise la propriété Date avec la date actuelle
        }
    }
}
