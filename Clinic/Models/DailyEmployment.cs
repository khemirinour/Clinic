using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    namespace Clinic.Models
    {
        public class DailyEmployment
        {
        [Key]
        public int DailyEmploymentId { get; set; }
        public string? dayname { get; set; }
        //public string EmployeeName { get; set; }

        public DateTime? DateOfWeek { get; set; }
        public string? PosteId { get; set; }
        public string? ReposId { get; set; }
        public string? SupplementId { get; set; }
        [ForeignKey("EmploiId")]
        public int EmploiId { get; set; }

        public Emploi? Emploi { get; set; }
        [ForeignKey("CategorieId")]
        public int? CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        [ForeignKey("ServiceId")]
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        // Add EmployeeId property to serve as the foreign key
        public int EmployeeId { get; set; }


    }



    public class EnregistrerEmploiModel
    {
        public string? ServiceSelected { get; set; }
        public string? DateSelected { get; set; }
        public string? CategorieSelected { get; set; }
        public List<DailyEmployment>? EmploiData { get; set; } // Utilisation d'une liste directe de DailyEmployment
    }


}

