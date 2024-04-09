using System.ComponentModel.DataAnnotations;

namespace Clinic.Models

{
    public class Day
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;

    }
}
