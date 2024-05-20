using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class Poste
    {
        [Key]
        public int PosteId { get; set; }

        [Required]
        public string Postename { get; set; } = string.Empty;

        public bool Matin { get; set; }
        public bool ApresMidi { get; set; }
        public bool GardeSoir { get; set; }
        public TimeSpan Seance1Debut { get; set; }
        public TimeSpan Seance1Fin { get; set; }
        public TimeSpan? Seance2Debut { get; set; }
        public TimeSpan? Seance2Fin { get; set; }
        public bool Actif { get; set; }

        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        public int? EmployeeId { get; set; }
        public ICollection<Employee>?    Employees { get; set; }

        public int? EmploiId { get; set; }
        public Emploi? Emploi { get; set; }

        public int? PositionX { get; set; }
        public int? PositionY { get; set; }
        public Poste()
        {
            Seance1Debut = new TimeSpan(0, 0, 0); // 00:00
            Seance1Fin = new TimeSpan(0, 0, 0); // 00:00
            Seance2Debut = new TimeSpan?(new TimeSpan(0, 0, 0)); // 00:00
            Seance2Fin = new TimeSpan?(new TimeSpan(0, 0, 0)); // 00:00
        }
    }
}