using System.ComponentModel.DataAnnotations;

namespace Clinic.Models

{
    public class Day
    {
        [Key]
        [Display(Name = "ID")]
        public int Id_day { get; set; }
        public string? Dayname { get; set; }

    }
  
}
