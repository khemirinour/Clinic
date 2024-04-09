using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class EmployeeSupplement
    {
        [Key]
        public int EmployeeSupplementId { get; set; }

        // Clé étrangère vers l'employé
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        // Clé étrangère vers le supplément associé à l'employé
        public int SupplementId { get; set; }
        public Supplement? Supplement { get; set; }
    }
}
