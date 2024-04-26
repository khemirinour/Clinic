using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class Emploi
    {
        [Key]
        public int EmploiId { get; set; }

        [Required]
        public DateTime DateofWeek { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

        public int CategorieId { get; set; }
        public ICollection<Day> Days { get; set; }

        public ICollection<Poste> Postes { get; set; }
        public ICollection<Repos> Repos { get; set; }
        public ICollection<Supplement> Supplements { get; set; }
        public ICollection<Employee> Employees { get; set; }
    

        public List<DailyEmployment>? DailyEmployments { get; internal set; }

        public Emploi()
        {
            // Initialisation des collections
            Days = new List<Day>();
            Postes = new List<Poste>();
            Repos = new List<Repos>();
            Supplements = new List<Supplement>();
            Employees = new List<Employee>();
            DailyEmployments =new List<DailyEmployment>();
            DateofWeek = DateTime.Now; // Initialise la propriété Date avec la date actuelle
        }


    }
}
