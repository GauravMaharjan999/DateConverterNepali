using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateConverterNepali
{
    public class MonthBS
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string MonthCode { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string MonthNameLocLang { get; set; }
    }
    public static class MonthBSProvider
    {
        public static List<MonthBS> GetMonths()
        {
            List<MonthBS> months = new List<MonthBS>
            {
                new MonthBS
                {
                    Id = 1,
                    MonthCode = "01",
                    Name = "Baisakh"
                },
                new MonthBS
                {
                    Id = 2,
                    MonthCode = "02",
                    Name = "Jestha"
                },
                new MonthBS
                {
                    Id = 3,
                    MonthCode = "03",
                    Name = "Ashad"
                },
                new MonthBS
                {
                    Id = 4,
                    MonthCode = "04",
                    Name = "Shrawan"
                },
                new MonthBS
                {
                    Id = 5,
                    MonthCode = "05",
                    Name = "Bhadra"
                },
                new MonthBS
                {
                    Id = 6,
                    MonthCode = "06",
                    Name = "Ashwin"
                },
                new MonthBS
                {
                    Id = 7,
                    MonthCode = "07",
                    Name = "Kartik"
                },
                new MonthBS
                {
                    Id = 8,
                    MonthCode = "08",
                    Name = "Mangshir"
                },
                new MonthBS
                {
                    Id = 9,
                    MonthCode = "09",
                    Name = "Poush"
                },
                new MonthBS
                {
                    Id = 10,
                    MonthCode = "10",
                    Name = "Magh"
                },
                new MonthBS
                {
                    Id = 11,
                    MonthCode = "11",
                    Name = "Falgun"
                },
                new MonthBS
                {
                    Id = 12,
                    MonthCode = "12",
                    Name = "Chaitra"
                }
            };
            return months;
        }
    }
    public static class NepaliDayProvider
    {
        private static readonly string[] NepaliDays =
        {
        "आइतबार", // Sunday
        "सोमबार", // Monday
        "मंगलबार", // Tuesday
        "बुधबार", // Wednesday
        "बिहीबार", // Thursday
        "शुक्रबार", // Friday
        "शनिबार"  // Saturday
    };
        

        public static string GetNepaliFontDayName(int dayNumber)
        {
            if (dayNumber < 0 || dayNumber > 6)
            {
                throw new ArgumentException("Invalid day number. Day number must be between 0 (Sunday) and 6 (Saturday).");
            }
            return NepaliDays[dayNumber];
        }
        
    }

}
