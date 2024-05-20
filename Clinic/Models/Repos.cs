using System;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Repos
    {
        [Key]
        public int ReposId { get; set; }

        [Required]
        public string ReposName { get; set; } = string.Empty;


        [DisplayFormat(DataFormatString = "{0:yyyy-dd-MM}")]
        public DateTime? Date_Jours { get; set; }
        public TimeSpan? hdebut{ get; set; }

        public TimeSpan? hFin { get; set; }

        // Clé étrangère vers la catégorie du repos
        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        // Clé étrangère vers l'employé
        public int? EmployeeId { get; set; }
        // Autres propriétés...
        public int? EmploiId { get; set; }
        public Emploi? Emploi { get; set; }
        public int? PositionX { get; set; }
        public int? PositionY { get; set; }
        public Repos()
        {
            hdebut = new TimeSpan(0, 0, 0); // 00:00
            hFin = new TimeSpan(0, 0, 0); // 00:00

        }

    }
}
