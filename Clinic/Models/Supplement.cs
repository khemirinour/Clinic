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

        public string Nom { get; set; } = string.Empty;
        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }




        public Employee? Employee { get; set; }

  


        // Emploi associé à ce supplément (relation de navigation)
        public Emploi? Emploi { get; set; }


        
    }
}
