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
        public string Name { get; set; }=string.Empty;  

        public string? Email { get; set; }
        public string? Sex { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Nationality { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public DateTime? RecruitmentDate { get; set; }
        public string? City { get; set; }
        public string? PhotoUrl { get; set; }
        public bool? IsChefDeService { get; set; }
        public int? TotalWeeklyHours { get; set; }

        public int? CategorieId { get; set; }
        public Categorie? Categorie { get; set; }
        public ICollection<EmployeeRepos>? EmployeeRepos { get; set; }
        public ICollection<EmployeePoste>? EmployeePostes { get; set; }
        public ICollection<DailyEmployment>? DailyEmployments { get; set; }
        public ICollection<Supplement>? Supplements { get; set; }

        [ForeignKey("Emploi")]
        public int? EmploiId { get; set; }
        public Emploi? Emploi { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

    }
}
