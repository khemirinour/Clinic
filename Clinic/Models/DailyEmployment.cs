namespace Clinic.Models
{
    public class DailyEmployment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateofWeek { get; set; }
        public List<Poste>? Postes { get; set; }
        public List<Repos>? Repos { get; set; }
        public List<Supplement>? Supplements { get; set; }
    }
}
