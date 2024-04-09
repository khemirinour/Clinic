namespace Clinic.Models
{
    public class EmploiViewModel
    {
        public List<Categorie>? Categories { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Day>? Days { get; set; }
        public List<Poste>? Postes { get; set; }
        public List<Repos>? Repos { get; set; } // Ajout de la propriété Repos
        public List<Supplement>? Supplements { get; set; } // Ajout de la propriété Supplements
        public List<Service>? Services { get; set; } // Ajouter une liste de services

        public Emploi? Emploi { get; set; } // Ajouter une propriété pour un seul emploi
    }
}
