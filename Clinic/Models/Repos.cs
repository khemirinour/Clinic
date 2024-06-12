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
 

        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        public int? EmployeeId { get; set; }
        // Autres propriétés...
        public Emploi? Emploi { get; set; }

   

    }
}
