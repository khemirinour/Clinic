using System.Collections.Generic;

namespace Clinic.Models
{
    public class GestionViewModel
    {
        public int CategorieId { get; set; }
        public string? NouveauPoste { get; set; }
        public string? NouveauRepos { get; set; }
        public string? NouveauSupplement { get; set; }

        public List<Categorie>? Categories { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
