using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }

        [Required]
        public string CategorieName { get; set; } = string.Empty;

        // Propriété de navigation pour les Postes
        public ICollection<Poste>? Postes { get; set; }

        // Propriété de navigation pour les Repos
        public ICollection<Repos>? Repos { get; set; }

        // Propriété de navigation pour les Suppléments
        public ICollection<Supplement>? Supplements { get; set; }
    }
}
