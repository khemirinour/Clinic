using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class EmployeePoste
    {
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int PosteId { get; set; }
        public Poste? Poste { get; set; }
    }
}
