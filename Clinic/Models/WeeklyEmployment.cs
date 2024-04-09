using System;
using System.Collections.Generic;

namespace Clinic.Models
{
    public class DailyEmployment
    {
        public int EmployeeId { get; set; }
        public DateTime DateofWeek{ get; set; }
        public List<Poste>? Postes { get; set; }
        public List<Repos>? Repos { get; set; }
        public List<Supplement>? Supplements { get; set; }
    }

    public class WeeklyEmployment  
    {

        public Service Service { get; set; }
        public DateTime WeekStartDay { get; set; }        
        public int EmployeeId { get; set; }

        public List<DailyEmployment> DailyEmployment { get; set; }


    }

  

}
