using System;
using System.Collections.Generic;

namespace Clinic.Models
{
  
    public class WeeklyEmployment  
    {
        public int Id { get; set; }
        public Service? Service { get; set; }
        public DateTime DateofWeek { get; set; }
        public int EmployeeId { get; set; }

        public List<DailyEmployment>? DailyEmployment { get; set; }


    }

  

}
