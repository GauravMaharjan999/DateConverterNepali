using DateConverterNepali;
using System;
using System.Collections.Generic;
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

        #region Date Converter
        // Convert AD date to BS date
        int year = 2002;
        int month = 03;
        int day = 01;
        var dateInBS = GetDateInBS(year, month, day, DateFormats.yMd, seperator: "/");
        //Console.WriteLine($"Converted AD Date ({month}/{day}/{year}) to BS Date:");
        //Console.WriteLine($"Date in BS: {dateInBS}");

        Console.WriteLine($"Input Year: {year}");
        Console.WriteLine($"Input Month: {month}");
        Console.WriteLine($"Input Day: {day}");
        PrintProperties(dateInBS);
        Console.WriteLine($"------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

        int yearBs = 2058;
        int monthBs = 11;
        int dayBs = 17;
        var dateInAd = GetDateInAD(yearBs, monthBs, dayBs);



        Console.WriteLine($"Input Year: {yearBs}");
        Console.WriteLine($"Input Month: {monthBs}");
        Console.WriteLine($"Input Day: {dayBs}");
        PrintProperties(dateInAd);
        #endregion

        Console.WriteLine($"####################################################################################################################################################################################################################################");

        #region Calender
        // Check if a year is a leap year
        Console.WriteLine("Is 2024 a leap year? " + Calendar.IsLeapYear(2024)); // Expected output: True
        Console.WriteLine("Is 2023 a leap year? " + Calendar.IsLeapYear(2023)); // Expected output: False

        // Get the name of the day of the week from its number
        Console.WriteLine("Day of week for 0: " + Calendar.GetDayOfWeek(0)); // Expected output: Sunday
        Console.WriteLine("Day of week for 3: " + Calendar.GetDayOfWeek(3)); // Expected output: Wednesday
        Console.WriteLine("Day of week for 6: " + Calendar.GetDayOfWeek(6)); // Expected output: Saturday

        // Get the name of the English month for the provided month number
        Console.WriteLine("English month for 1: " + Calendar.GetEnglishMonth(1)); // Expected output: January
        Console.WriteLine("English month for 12: " + Calendar.GetEnglishMonth(12)); // Expected output: December

        // Get the name of the Nepali month for the provided month number
        Console.WriteLine("Nepali month for 1: " + Calendar.GetNepaliMonthInNepaliFont(1)); // Expected output: बैशाख
        Console.WriteLine("Nepali month for 12: " + Calendar.GetNepaliMonthInNepaliFont(12)); // Expected output: चैत्र

        // Validate if an English date is valid
        Console.WriteLine("Is 2024-02-29 a valid English date? " + Calendar.ValidEnglishDate(2024, 2, 29)); // Expected output: True
        Console.WriteLine("Is 2023-02-29 a valid English date? " + Calendar.ValidEnglishDate(2023, 2, 29)); // Expected output: False

        // Convert an English date to a Nepali date
        var nepaliDate = TimeConverter.ConvertToNepaliDateTime(new DateTime(2024, 7, 11));
        Console.WriteLine($"Converted Nepali Date: {nepaliDate.year}-{nepaliDate.month}-{nepaliDate.day} {nepaliDate.hour}:{nepaliDate.minute}:{nepaliDate.second}");
        // Expected output: Converted Nepali Date: 2081-3-27 5:45:00 (or close approximation)

        // Convert UTC time to Nepali time
        TimeSpan utcTime = new TimeSpan(12, 0, 0); // 12:00 PM UTC
        TimeSpan nepaliTime = TimeConverter.ConvertUtcToNepaliTime(utcTime);
        Console.WriteLine("Nepali time for 12:00 PM UTC: " + nepaliTime); // Expected output: 17:45:00

        // Convert Nepali time to UTC time
        TimeSpan nepaliTimeToConvert = DateTime.Now.TimeOfDay; // 5:45 PM Nepali Time
        TimeSpan utcConvertedTime = TimeConverter.ConvertNepaliTimeToUtc(nepaliTimeToConvert);
        Console.WriteLine($"UTC time for {nepaliTimeToConvert} Nepali Time: " + utcConvertedTime); // Expected output: 12:00:00

        #endregion

        Console.WriteLine($"####################################################################################################################################################################################################################################");

        #region FiscalYearHelper
        // Example dates
        DateTime engDate = new DateTime(2024, 7, 12);


        // Get year in Nepali calendar
        int nepaliYear = FiscalYearHelper.GetYear(engDate, OprDateType.Nepali);
        Console.WriteLine($"Nepali Year: {nepaliYear}");


        // Get day in Nepali calendar
        int nepaliDay = FiscalYearHelper.GetDay(engDate, OprDateType.Nepali);
        Console.WriteLine($"Day in Nepali Calendar: {nepaliDay}");


        // Get fiscal year for Nepali date
        string nepaliFiscalYear = FiscalYearHelper.GetFiscalYear(engDate, OprDateType.Nepali);
        Console.WriteLine($"Fiscal Year (Nepali): {nepaliFiscalYear}");

        // Get list of years from 2000 to current year
        IEnumerable<int?> years = FiscalYearHelper.GetYearListAd();
        Console.WriteLine("Years from 2000 to Current Year:");
        foreach (var yr in years)
        {
            Console.Write($"{yr} ");
        }
        Console.WriteLine();

        // Get fiscal year details for a specific year
        string yearToFind = "2080"; // Example year
        FiscalYear fiscalYearDetails = FiscalYearHelper.GetFiscalYearByYear(yearToFind);
        if (fiscalYearDetails != null)
        {
            Console.WriteLine($"Fiscal Year Details for {yearToFind}: ");
            PrintProperties(fiscalYearDetails);
        }
        else
        {
            Console.WriteLine($"Fiscal Year Details not found for {yearToFind}");
        }

        // Calculate time duration between two times
        string fromTime = "09:00:00";
        string toTime = "17:30:00";
        string duration = FiscalYearHelper.GetTimeDurationFromTwoTimeSpan(fromTime, toTime);
        Console.WriteLine($"Time Duration: {duration}");
        #endregion

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