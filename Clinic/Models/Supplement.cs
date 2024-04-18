using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class Supplement
    {
        [Key]
        public int SupplementId { get; set; }

        // Nom du supplément
        public string Nom { get; set; } = string.Empty;
        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        // ID de l'employé associé à ce supplément
        public int? EmployeeId { get; set; }

        // Nom de l'employé associé à ce supplément
        public string? EmployeeName { get; set; }

        // Matricule de l'employé associé à ce supplément
        public string? Matricule { get; set; }

        // Heure de début du supplément
        public TimeSpan? StartHour { get; set; } = DateTime.Today.TimeOfDay;

        // Heure de fin du supplément
        public TimeSpan? EndHour { get; set; } = DateTime.Today.TimeOfDay;

        // Date du supplément
        public DateTime? Date { get; set; }

        // Employé associé à ce supplément (relation de navigation)
        public Employee? Employee { get; set; }

        // Liste des liens entre les employés et ce supplément
        public ICollection<EmployeeSupplement> EmployeeSupplement { get; set; } = new List<EmployeeSupplement>();

        // ID de l'emploi associé à ce supplément
        public int? EmploiId { get; set; }

        // Emploi associé à ce supplément (relation de navigation)
        public Emploi? Emploi { get; set; }

        // Position X du supplément (si nécessaire)
        public int? PositionX { get; set; }

        // Position Y du supplément (si nécessaire)
        public int? PositionY { get; set; }

        // Constructeur
        public Supplement()
        {
            // Initialize properties if necessary
            EmployeeSupplement = new List<EmployeeSupplement>();
            Employee = new Employee();
            Date = DateTime.Now;

            // Assign TimeSpan values to StartHour and EndHour
            StartHour = new TimeSpan(24); // For example, 8:00 AM
            EndHour = new TimeSpan(24);   // For example, 5:00 PM
        }
    }
}
