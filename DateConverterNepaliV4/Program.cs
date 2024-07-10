using DateConverterNepali;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using static DateConverterNepali.DateConverter;  // Import the static class members


class Program
{
    static void Main(string[] args)
    {
        #region Group1
        // Set console output encoding to UTF-8 to support Unicode characters
        Console.OutputEncoding = Encoding.UTF8;

        //// Current date in Bikram Sambat (BS)
        //Console.WriteLine("Current Date in Bikram Sambat (BS):");
        //Console.WriteLine(GetDateInBS(DateTime.Now));

        //Console.WriteLine();

        //// Convert BS date to AD date
        //string bsDate = "2081/08/32";
        //DateTime dateInAD = GetDateInAD(bsDate);
        //Console.WriteLine($"Converted BS Date ({bsDate}) to AD Date:");
        //Console.WriteLine($"Date in AD: {dateInAD:yyyy/MM/dd}");

        //Console.WriteLine();

        //// Get fiscal year
        //Console.WriteLine($"Fiscal Year: {GetFiscalYear(DateTime.Now, OprDateType.Nepali)}");

        //Console.WriteLine();

        //// Convert AD date to BS date
        //int year = 2024;
        //int month = 7;
        //int day = 2;
        //string dateInBS = GetDateInBS(year, month, day);
        //Console.WriteLine($"Converted AD Date ({month}/{day}/{year}) to BS Date:");
        //Console.WriteLine($"Date in BS: {dateInBS}");

        //Console.WriteLine();

        //// Example usage of ConvertToNepali
        //int adYear = 2024;
        //int adMonth = 7;
        //int adDay = 2;

        //NepaliDate nepaliDate = ConvertToNepali(adYear, adMonth, adDay);
        //Console.WriteLine($"Converted {adMonth}/{adDay}/{adYear} to Nepali Date:");
        //Console.WriteLine($"Year: {nepaliDate.Year}, Month: {nepaliDate.Month}, Day: {nepaliDate.Day}");
        //Console.WriteLine($"Week Day Name: {nepaliDate.WeekDayName}, Month Name (English): {nepaliDate.MonthNameEnglish}, Month Name (Nepali): {nepaliDate.MonthNameNepali}");
        //Console.WriteLine($"Week Day: {nepaliDate.WeekDay}");

        //Console.WriteLine();

        //// Example usage of ConvertToEnglish
        //int bsYear = 2081;
        //int bsMonth = 8;
        //int bsDay = 32;

        //NepaliDate englishDate = ConvertToEnglish(bsYear, bsMonth, bsDay);
        //Console.WriteLine($"Converted {bsYear}/{bsMonth}/{bsDay} to English Date:");
        //Console.WriteLine($"Year: {englishDate.Year}, Month: {englishDate.Month}, Day: {englishDate.Day}");
        //Console.WriteLine($"Week Day Name: {englishDate.WeekDayName}, Month Name (English): {englishDate.MonthNameEnglish}, Month Name (Nepali): {englishDate.MonthNameNepali}");
        //Console.WriteLine($"Week Day: {englishDate.WeekDay}"); 
        #endregion



        //// Example UTC TimeSpan
        //TimeSpan utcTime = new TimeSpan(11, 00, 29); // 10 hours and 30 minutes

        //// Convert UTC TimeSpan to Nepali TimeSpan
        //TimeSpan nepaliTime = TimeConverter.ConvertUtcToNepaliTime(utcTime);

        //Console.WriteLine($"UTC Time: {utcTime}");
        //Console.WriteLine($"Nepali Time: {nepaliTime}");



        // Convert AD date to BS date
        int year = 2024;
        int month = 7;
        int day = 10;
        var dateInBS = GetDateInBS(year, month, day,DateFormats.yMd);
        //Console.WriteLine($"Converted AD Date ({month}/{day}/{year}) to BS Date:");
        //Console.WriteLine($"Date in BS: {dateInBS}");

        PrintProperties(dateInBS);
    }
    public static void PrintProperties(object obj)
    {
        // Get the type of the object
        Type type = obj.GetType();

        // Get all the properties of the type
        PropertyInfo[] properties = type.GetProperties();

        // Iterate over the properties and print their names and values
        foreach (PropertyInfo property in properties)
        {
            string name = property.Name;
            object value = property.GetValue(obj, null);
            Console.WriteLine($"{name}: {value}");
        }
    }

}