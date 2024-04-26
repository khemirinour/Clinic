using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class EmploiViewModel
    {
        public DateTime? DateofWeek { get; set; }

        public int? ServiceId { get; set; }
        public int? EmployeeId { get; set; }

        // Propriétés
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
        public int PosteId { get; set; }
        public int SupplementId { get; set; }
        public int Id_day { get; set; }
        public string? name { get; set; }

        public int ReposId { get; set; }
        public DailyEmployment?  DailyEmployments { get; set; }

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
            // Initialisation de Emploi
            Emploi = new Emploi(); // Ou une autre initialisation selon vos besoins
        }
    }

  

    public class EmploiData
    {
        public List<Employee>? Employees { get; set; }
        public List<Day>? Days { get; set; }
        public Dictionary<int, Dictionary<string, Dictionary<string, List<Position>>>> EmployeeData { get; set; }

        public List<PositionData>?   Postes { get; set; }
        public List<ReposData>?  Repos { get; set; }
        public List<SupplementData>? Supplements { get; set; }
    }
    public class Position
    {
        public string Data { get; set; }
    }
    public class PositionData
    {
        public string? Data { get; set; }
        public string? CategorieId { get; set; }
    }

    public class ReposData
    {
        public string? Data { get; set; }
        public string? CategorieId { get; set; }
    }

    public class SupplementData
    {
        public string? Data { get; set; }
        public string? CategorieId { get; set; }
    }
}
