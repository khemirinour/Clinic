using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class EmploiViewModel
    {
        public DateTime? DateofWeek { get; set; }

        public int? EmployeeId { get; set; }
         public int? ServiceId { get; set; }
        public Employee Employee { get; set; } // Ajoutez cette propriété
        public Employee ConnectedEmployee { get; set; }

        public List<Service>? Services { get; set; }
        public List<Supplement>? Supplements { get; set; }
        public List<Day>? Days { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Categorie>? Categories { get; set; }
        public List<Poste>? Postes { get; set; }
        public List<Repos>? Repos { get; set; }
        public Emploi? Emploi { get; set; }
        public string? ServiceSelected { get; set; }
        public string? DateSelected { get; set; }
        public int?  PosteId { get; set; }
        public int? SupplementId { get; set; }
        public int? Id_day { get; set; }

       public string? Dayname  { get; set; }
        public string? EmployeeName { get; set; }

        public List<DailyEmployment>? DailyEmployments { get; set; }
        public SelectList ServiceList { get; set; } // Modifier le type pour SelectList

        public int? ReposId { get; set; }

        public int? CategorieId { get;  set; }

        public EmploiViewModel()
        {
            // Initialisation des listes
            Services = new List<Service>();
            Supplements = new List<Supplement>();
            Days = new List<Day>();
            Employees = new List<Employee>();
            Categories = new List<Categorie>();
            Postes = new List<Poste>();
            Repos = new List<Repos>();
            DailyEmployments = new List<DailyEmployment>();

            // Initialisation de Emploi
            Emploi = new Emploi(); // Ou une autre initialisation selon vos besoins
        }
    }

}
