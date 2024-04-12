using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models
{
    public class EmployeeRepos
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee?     Employee { get; set; }

        public int ReposId { get; set; }
        public Repos?   Repos { get; set; }
    }
}
