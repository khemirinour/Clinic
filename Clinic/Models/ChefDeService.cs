using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class ChefDeService
    {
        [Key]
        public int Id { get; set; }


        public string ChefDeServiceName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Password { get; set; }

        // Clé étrangère vers le service auquel appartient le chef de service
        public int ServiceId { get; set; }
        public Service?  Service { get; set; }

        // Propriété de navigation
        public ICollection<Emploi>? Emplois { get; set; }

        // Clé étrangère vers l'employé qui est également un chef de service
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
