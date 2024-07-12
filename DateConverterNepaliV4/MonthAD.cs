using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateConverterNepali
{
    public class MonthAD
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string MonthCode { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
      
    }
    //public static class MonthADProvider
    //{
    //    public static List<MonthAD> GetMonths()
    //    {
    //        List<MonthAD> months = new List<MonthAD>
    //        {
    //            new MonthAD { Id = 1, MonthCode = "1", Name = "January" },
    //            new MonthAD { Id = 2, MonthCode = "2", Name = "February" },
    //            new MonthAD { Id = 3, MonthCode = "3", Name = "March" },
    //            new MonthAD { Id = 4, MonthCode = "4", Name = "April" },
    //            new MonthAD { Id = 5, MonthCode = "5", Name = "May" },
    //            new MonthAD { Id = 6, MonthCode = "6", Name = "June" },
    //            new MonthAD { Id = 7, MonthCode = "7", Name = "July" },
    //            new MonthAD { Id = 8, MonthCode = "8", Name = "August" },
    //            new MonthAD { Id = 9, MonthCode = "9", Name = "September" },
    //            new MonthAD { Id = 10, MonthCode = "10", Name = "October" },
    //            new MonthAD { Id = 11, MonthCode = "11", Name = "November" },
    //            new MonthAD { Id = 12, MonthCode = "12", Name = "December" }
    //        };

    //        return months;
    //    }
    //}
}
