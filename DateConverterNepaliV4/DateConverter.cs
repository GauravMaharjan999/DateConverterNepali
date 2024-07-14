using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace DateConverterNepali
{

    /// <summary>
    /// Provides methods for converting dates between Nepali (Bikram Sambat) and Gregorian (AD) calendars.
    /// </summary>
    public static class DateConverter
    {
        /// <summary>
        /// Converts a Gregorian (AD) date to Nepali (BS) date.
        /// </summary>
        /// <param name="year">The year in AD.</param>
        /// <param name="month">The month in AD.</param>
        /// <param name="day">The day in AD.</param>
        /// <param name="date_format">The format of the Nepali date.</param>
        /// <returns>A NepaliDate object representing the converted date.</returns>
        public static NepaliDate GetDateInBS(int year, int month, int day, DateFormats date_format = 0, string seperator = "-")
        {
            // Checking for invalid dates
            if (!IsValidDate(year, month, day))
            {
                return new NepaliDate();
            }
            else
            {
                var inputDate = new DateTime(year, month, day);
                return GetDateInBS(inputDate, date_format,seperator);
            }
        }

        /// <summary>
        /// Converts a Gregorian (AD) DateTime object to Nepali (BS) date.
        /// </summary>
        /// <param name="dateInAD">The DateTime object in AD.</param>
        /// <param name="date_format">The format of the Nepali date.</param>
        /// <returns>A NepaliDate object representing the converted date.</returns>
        public static NepaliDate GetDateInBS(DateTime dateInAD, DateFormats date_format = 0,string seperator = "-")
        {
            if (dateInAD == DateTime.MinValue)
            {
                return new NepaliDate();
            }
            else
            {
                //Getting BS date data for BS date calculation
                int yearInAD = dateInAD.Year;
                int[] bsFirstData = DateArray.DateDataArray(yearInAD);
                int[] bsSecondData = DateArray.DateDataArray(yearInAD + 1);
                //Getting AD day of the year
                int dayOfYearInAD = dateInAD.DayOfYear;
                //Initializing BS Year from the data
                int yearInBS = bsFirstData[1];
                //Initializing BS month to Poush          
                int initMonthInBS = 9;
                //Initializing BS DaysInMonth with total days in the month of Poush
                int bsDaysInMonth = bsFirstData[11];
                //Initializing temp nepali days
                //This is sum of total days in each BS month starting Jan 1 in month Poush
                int bsTempDays = bsFirstData[11] - bsFirstData[2] + 1;
                List<int> fromBSFirstData = new List<int>();
                //generates array of days from poush to chait
                for (int p = 11; p < bsFirstData.Length; p++)
                {
                    fromBSFirstData.Add(bsFirstData[p]);
                }
                List<int> fromBSSecondData = new List<int>();
                //generate array of days from baisakh to poush
                for (int q = 3; q < 12; q++)
                {
                    fromBSSecondData.Add(bsSecondData[q]);
                }
                //  generate array of days in BS months
                int[] newBSDateArray = fromBSFirstData.Concat(fromBSSecondData).ToArray();
                //Looping through BS date data array to get exact BS month, BS year & BS daysInMonth information
                for (int i = 1; dayOfYearInAD > bsTempDays; i++)
                {
                    bsTempDays += newBSDateArray[i];
                    bsDaysInMonth = newBSDateArray[i];
                    initMonthInBS++;
                    if (initMonthInBS > 12)
                    {
                        initMonthInBS -= 12;
                        yearInBS++;
                    }
                }
                //Calculating BS day  
                int dayInBS = bsDaysInMonth - (bsTempDays - dayOfYearInAD);
                string finalMonthInBS = (initMonthInBS < 10) ? "0" + initMonthInBS : initMonthInBS.ToString();
                string finaldayInBS = (dayInBS < 10) ? "0" + dayInBS : dayInBS.ToString();
                string dateInBS = String.Format("{0}/{1}/{2}", yearInBS, finalMonthInBS, finaldayInBS);

                var formattedDate = "";
                switch (date_format)
                {
                    case DateFormats.mDy:
                        formattedDate = finalMonthInBS.ToString() + "-" + finaldayInBS.ToString() + "-" + yearInBS;
                        break;
                    case DateFormats.dMy:
                        formattedDate = finaldayInBS.ToString() + "-" + finalMonthInBS.ToString() + "-" + yearInBS;
                        break;
                    case DateFormats.yMd:
                        formattedDate = yearInBS + "-" + finalMonthInBS.ToString() + "-" + finaldayInBS.ToString();
                        break;
                    default:
                        formattedDate = String.Format("{0}/{1}/{2}", yearInBS, finalMonthInBS, finaldayInBS);
                        break;
                }

                var ifinalDayInBs = int.Parse(finaldayInBS);
                var ifinalMonthInBS = int.Parse(finalMonthInBS);
                var iyearInBS = yearInBS;
                var nepaliDate = new NepaliDate();
                nepaliDate.setFormattedDate(iyearInBS, ifinalMonthInBS, ifinalDayInBs, date_format,seperator);
                nepaliDate.npDay = ifinalDayInBs;
                nepaliDate.npMonth = ifinalMonthInBS;
                nepaliDate.npYear = iyearInBS;
                //1 is added since we are using Sunday as 1 although it is 0
                nepaliDate.dayNumber = (int)dateInAD.DayOfWeek + 1;
                nepaliDate.dayName = dateInAD.DayOfWeek.ToString();
                nepaliDate.npDaysInMonth = bsDaysInMonth;
                nepaliDate.nepaliMonthInNepaliFont = ifinalMonthInBS.ToString();
                nepaliDate.nepaliMonthInEnglishFont = ifinalMonthInBS.ToString();
                nepaliDate.nepaliDayInNepaliFont = ((int)dateInAD.DayOfWeek).ToString();

                return nepaliDate;
            }
        }

        /// <summary>
        /// Converts a Nepali (BS) date to Gregorian (AD) date.
        /// </summary>
        /// <param name="bsYear">The year in BS.</param>
        /// <param name="bsMonth">The month in BS.</param>
        /// <param name="bsDay">The day in BS.</param>
        /// <param name="date_format">The format of the Gregorian date.</param>
        /// <returns>An EnglishDate object representing the converted date.</returns>
        public static EnglishDate GetDateInAD(int bsYear, int bsMonth, int bsDay)
        {
            DateTime dateAD = DateTime.MinValue;

            // Validate input
            if (bsYear <= 0 || bsMonth <= 0 || bsDay <= 0 || bsMonth > 12 || bsDay > 32)
            {
                return new EnglishDate();
            }

            return GetDateInAD(string.Concat(bsYear, "/", bsMonth, "/", bsDay));
        }

        /// <summary>
        /// Converts a Nepali (BS) date string to Gregorian (AD) date.
        /// </summary>
        /// <param name="dateInBS">The Nepali date string in "yyyy/MM/dd" format.</param>
        /// <param name="date_format">The format of the Gregorian date.</param>
        /// <returns>An EnglishDate object representing the converted date.</returns>
        public static EnglishDate GetDateInAD(string dateInBS)
        {
            DateTime dateAD;
            var k = new string[3];
            var d = new string[3];
            int bsYear = 0, bsMonth = 0, bsDay = 0;
            if ((dateInBS.Contains("-")) || (dateInBS.Contains("/")))
            {
                if (dateInBS.Contains("-"))
                {
                    d = dateInBS.Split("-");
                    if (d.Length == 3)
                    {
                        dateInBS = d[0] + '/' + d[1] + '/' + d[2];
                    }
                }
                if (dateInBS.Contains("/"))
                {
                    k = dateInBS.Split("/");
                    if (k.Length == 3)
                    {
                        bsYear = (int.TryParse(k[0], out int yr)) == true ? yr : 0;
                        bsMonth = (int.TryParse(k[1], out int mm)) == true ? mm : 0;
                        bsDay = (int.TryParse(k[2], out int dd)) == true ? dd : 0;
                    }
                }
            }
            if (bsYear <= 0 || bsMonth <= 0 || bsDay <= 0 || bsMonth > 12 || bsDay > 32)
            {
                return new EnglishDate();
            }
            int DayOfYearInBS = 0;
            int yearInAD = bsYear - 57;
            int[] bsDateData = DateArray.DateDataArray(yearInAD + 1);
            if (bsDateData == null) { return new EnglishDate(); }
            for (int j = 3; j <= bsMonth + 1; j++)
            {
                DayOfYearInBS += bsDateData[j];
            }
            DayOfYearInBS += bsDay;
            int initMonthInAD = 4;
            int[] months = new int[] { 0, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30 };
            int[] leapmonths = new int[] { 0, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 29, 31, 30 };
            int initDaysInMonthAD = months[1];
            int adTempDays = months[1] - bsDateData[0] + 1;
            for (int i = 2; DayOfYearInBS > adTempDays; i++)
            {
                if (DateTime.IsLeapYear(yearInAD))
                {
                    adTempDays += leapmonths[i];
                    initDaysInMonthAD = leapmonths[i];
                }
                else
                {
                    adTempDays += months[i];
                    initDaysInMonthAD = months[i];
                }
                initMonthInAD++;
                if (initMonthInAD > 12)
                {
                    initMonthInAD -= 12;
                    yearInAD++;
                }
            }
            int dayInAD = initDaysInMonthAD - (adTempDays - DayOfYearInBS);
            string finalMonthInAD = (initMonthInAD < 10) ? "0" + initMonthInAD : initMonthInAD.ToString();
            string finaldayInAD = (dayInAD < 10) ? "0" + dayInAD : dayInAD.ToString();
            string dateInAD = String.Format("{0}/{1}/{2}", yearInAD, finalMonthInAD, finaldayInAD);
            bool hasDate = DateTime.TryParse(dateInAD, out dateAD);

            var ifinalMonthInAD = int.Parse(finalMonthInAD);
            var ifinaldayInAD = int.Parse(finaldayInAD);
            var iyearInAD = yearInAD;
            var englishDate = new EnglishDate();
            if (hasDate == true)
            {
                englishDate.setFormattedDate(iyearInAD, ifinalMonthInAD, ifinaldayInAD);
                englishDate.engYear = iyearInAD;
                englishDate.engMonth = ifinalMonthInAD;
                englishDate.engDay = ifinaldayInAD;
                englishDate.dayNumber = (int)dateAD.DayOfWeek + 1;
                englishDate.dayName = dateAD.DayOfWeek.ToString();
                englishDate.engDaysInMonth = DateTime.DaysInMonth(iyearInAD, ifinalMonthInAD);

                return englishDate;
            }
            else
                return new EnglishDate();
        }

        #region Validation

        /// <summary>
        /// Checks if the given year, month, and day form a valid date in Gregorian calendar.
        /// </summary>
        /// <param name="year">The year to validate.</param>
        /// <param name="month">The month to validate.</param>
        /// <param name="day">The day to validate.</param>
        /// <returns>True if the date is valid; otherwise, false.</returns>
        private static bool IsValidDate(int year, int month, int day)
        {
            if (year < 1 || month < 1 || month > 12 || day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                return false;
            }
            return true;
        }

        #endregion
    }
    public class Calendar
    {
        // Method to check if a year is leap year
        public static bool IsLeapYear(int englishYear)
        {
            if ((englishYear % 4 == 0 && englishYear % 100 != 0) || englishYear % 400 == 0)
            {
                return true;
            }
            return false;
        }

        // Method to get the name of the day of the week from its number (0-6, Sunday-Saturday)
        public static string GetDayOfWeek(int weekDayNumber)
        {
            if (weekDayNumber < 0 || weekDayNumber > 6)
            {
                throw new ArgumentException("Invalid week day number. Week day number must be between 0 and 6.");
            }
            return Enum.GetName(typeof(DayOfWeek), weekDayNumber);
        }

        // Method to get the name of the English month for the provided month number (1-12)
        public static string GetEnglishMonth(int monthNumber)
        {
            if (monthNumber < 1 || monthNumber > 12)
            {
                throw new ArgumentException("Invalid month number. Month number must be between 1 and 12.");
            }
            return new DateTime(2000, monthNumber, 1).ToString("MMMM");
        }

        // Method to get the name of the Nepali month for the provided month number (1-12)
        public static string GetNepaliMonthInNepaliFont(int monthNumber)
        {
            switch (monthNumber)
            {
                case 1: return "बैशाख";
                case 2: return "जेठ";
                case 3: return "असार";
                case 4: return "साउन";
                case 5: return "भदौ";
                case 6: return "असोज";
                case 7: return "कार्तिक";
                case 8: return "मंसिर";
                case 9: return "पुष";
                case 10: return "माघ";
                case 11: return "फाल्गुन";
                case 12: return "चैत्र";
                default: throw new ArgumentException("Invalid month number. Month number must be between 1 and 12.");
            }
        }

        public static string GetTimeDurationFromTwoTimeSpan(string FromTime, string ToTime)
        {
            try
            {
                DateTime dFrom;
                DateTime dTo;
                var TotalWorkingTime = string.Empty;
                if (DateTime.TryParse(FromTime, out dFrom) && DateTime.TryParse(ToTime, out dTo))
                {
                    TimeSpan TS = dTo - dFrom;
                    int hour = TS.Hours;
                    int mins = TS.Minutes;
                    int secs = TS.Seconds;

                    TotalWorkingTime = hour.ToString("00") + " hrs" + " " + mins.ToString("00") + " min" + " " + secs.ToString("00") + " sec";
                }
                return TotalWorkingTime;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }



        // Method to validate if an English date is valid
        public static bool ValidEnglishDate(int year, int month, int day)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
        public static bool ValidEnglishDate(DateTime date)
        {
            try
            {
                DateTime validDate = new DateTime(date.Year, date.Month, date.Day);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        // Method to validate if a Nepali date is valid
        public static bool ValidNepaliDate(int npYear, int npMonth, int npDay)
        {
            try
            {
                // Convert Nepali date to AD date and then validate
                var npDate = DateConverter.GetDateInAD(npYear, npMonth, npDay);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
        public static bool ValidNepaliDate(string npDate, DateFormats dateFormats=0)
        {
            try
            {
                // Convert Nepali date to AD date and then validate
                var nepaliDate = DateConverter.GetDateInAD(npDate);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }

    /// <summary>
    /// The TimeConverter class provides methods for converting dates and times 
    /// between the English (Gregorian) calendar and the Nepali (Bikram Sambat) calendar.
    /// It also includes methods for converting between UTC time and Nepali time.
    /// </summary>
    public static class TimeConverter
    {

        /// <summary>
        /// An array representing the total number of days in each month of the Bikram Sambat (BS) calendar.
        /// This array is used to assist in date calculations.
        /// </summary>
        // Total number of days in each month of the BS calendar (example data)
        private static readonly int[] bsDaysInMonth = new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 30, 29, 30, 29 };

        /// <summary>
        /// A DateTime object representing the base date in the English calendar for conversion purposes.
        /// </summary>
        // Base dates for conversion
        private static readonly DateTime baseEnglishDate = new DateTime(1943, 4, 13);
        /// <summary>
        /// A DateTime object representing the base date in the Nepali calendar for conversion purposes.
        /// </summary>
        private static readonly DateTime baseNepaliDate = new DateTime(2000, 1, 1);

        /// <summary>
        /// A TimeSpan object representing the time offset of Nepal Standard Time from UTC (+5:45 hours).
        /// </summary>
        // Nepal Time Offset from UTC (+5:45 hours)
        private static readonly TimeSpan nepalTimeOffset = new TimeSpan(5, 45, 0);

        /// <summary>
        /// Converts an English date and time to Nepali date and time.
        /// </summary>
        /// <param name="englishDateTime">The English date and time to convert.</param>
        /// <returns>A tuple containing the Nepali date and time components: year, month, day, hour, minute, and second.</returns>
        /// <example>
        /// <code>
        /// var nepaliDateTime = TimeConverter.ConvertToNepaliDateTime(new DateTime(2024, 7, 12, 15, 30, 0));
        /// Console.WriteLine($"Nepali Date and Time: {nepaliDateTime.year}/{nepaliDateTime.month}/{nepaliDateTime.day} {nepaliDateTime.hour}:{nepaliDateTime.minute}:{nepaliDateTime.second}");
        /// </code>
        /// </example>
        public static (int year, int month, int day, int hour, int minute, int second) ConvertToNepaliDateTime(DateTime englishDateTime)
        {
            // Adjust the English date time by the Nepal time offset
            DateTime adjustedDateTime = englishDateTime.Add(nepalTimeOffset);

            // Date conversion
            int nepaliYear = 2000;
            int nepaliMonth = 1;
            int nepaliDay = 1;

            // Calculate the difference in days from the base date
            TimeSpan dateDifference = adjustedDateTime.Date - baseEnglishDate;
            int totalDays = (int)dateDifference.TotalDays;

            // Convert totalDays to BS date
            nepaliDay += totalDays;

            // Adjust the days, months, and years
            while (nepaliDay > bsDaysInMonth[nepaliMonth - 1])
            {
                nepaliDay -= bsDaysInMonth[nepaliMonth - 1];
                nepaliMonth++;
                if (nepaliMonth > 12)
                {
                    nepaliMonth = 1;
                    nepaliYear++;
                }
            }

            // Time conversion
            int hour = adjustedDateTime.Hour;
            int minute = adjustedDateTime.Minute;
            int second = adjustedDateTime.Second;

            return (nepaliYear, nepaliMonth, nepaliDay, hour, minute, second);
        }

        /// <summary>
        /// Converts a given UTC time to Nepali time.
        /// </summary>
        /// <param name="utcTime">The UTC time to convert.</param>
        /// <returns>The corresponding Nepali time as a TimeSpan.</returns>
        /// <example>
        /// <code>
        /// var nepaliTime = TimeConverter.ConvertUtcToNepaliTime(new TimeSpan(10, 0, 0));
        /// Console.WriteLine($"Nepali Time: {nepaliTime}");
        /// </code>
        /// </example>
        public static TimeSpan ConvertUtcToNepaliTime(TimeSpan utcTime)
        {
            return utcTime.Add(nepalTimeOffset);
        }

        /// <summary>
        /// Converts a given Nepali time to UTC time.
        /// </summary>
        /// <param name="nepaliTime">The Nepali time to convert.</param>
        /// <returns>The corresponding UTC time as a TimeSpan.</returns>
        /// <example>
        /// <code>
        /// var utcTime = TimeConverter.ConvertNepaliTimeToUtc(new TimeSpan(15, 45, 0));
        /// Console.WriteLine($"UTC Time: {utcTime}");
        /// </code>
        /// </example>
        public static TimeSpan ConvertNepaliTimeToUtc(TimeSpan nepaliTime)
        {
            return nepaliTime.Subtract(nepalTimeOffset);
        }
    }

    /// <summary>
    /// The FiscalYearHelper class provides methods for handling fiscal year operations,
    /// including date and time conversions between English and Nepali calendars.
    /// </summary>
    public static class FiscalYearHelper
    {
        /// <summary>
        /// Gets the year part of the provided date in either English or Nepali calendar (depending on opr parameter).
        /// </summary>
        /// <param name="dateInAD">The date in English calendar or equivalent in Nepali calendar.</param>
        /// <param name="opr">The type of calendar system, English or Nepali.</param>
        /// <returns>The year part of the date.</returns>
        public static int GetYear(DateTime dateInAD, OprDateType opr)
        {
            if (opr == OprDateType.English)
            {
                return dateInAD.Year;
            }
            else
            {
                var convertedDated = DateConverter.GetDateInBS(dateInAD,seperator:"/");
                string dateInBS = convertedDated.formattedDate;
                string[] k = new string[] { };
                //if (dateInBS != null && dateInBS.Contains("-"))
                if (dateInBS != null && dateInBS.Contains("/"))
                {
                    k = dateInBS.Split('/');
                }
                int year;
                bool check = int.TryParse(k[0], out year);
                return (check == true ? year : dateInAD.Year);
            }
        }

        /// <summary>
        /// Gets the day part of the provided date in either English or Nepali calendar (depending on opr parameter).
        /// </summary>
        /// <param name="dateInAD">The date in English calendar or equivalent in Nepali calendar.</param>
        /// <param name="opr">The type of calendar system, English or Nepali.</param>
        /// <returns>The day part of the date.</returns>
        public static int GetDay(DateTime dateInAD, OprDateType opr)
        {
            if (opr == OprDateType.English)
            {
                return dateInAD.Day;
            }
            else
            {
                var convertedDated = DateConverter.GetDateInBS(dateInAD, seperator: "/");
                string dateInBS = convertedDated.formattedDate;
                string[] k = new string[] { };
                //if (dateInBS != null && dateInBS.Contains("-"))
                if (dateInBS != null && dateInBS.Contains("/"))
                {
                    k = dateInBS.Split('/');
                }
                int day;
                bool check = int.TryParse(k[2], out day);
                return (check == true ? day : dateInAD.Day);
            }
        }

        /// <summary>
        /// Determines the fiscal year based on the provided date and calendar type.
        /// </summary>
        /// <param name="date">The date for which to determine the fiscal year.</param>
        /// <param name="oprDateType">The type of calendar system, English or Nepali.</param>
        /// <returns>The fiscal year in the format "YYYY/YY".</returns>
        public static string GetFiscalYear(DateTime date, OprDateType oprDateType)
        {
            int givenYear, givenMonth, yearAfterGivenYear, yearBeforeGivenYear;
            string requiredFiscalYear, possibleFiscalYearOne, possibleFiscalYearTwo;
            var oprDate = oprDateType;
            string appointmentDate = "";
            if (oprDate == OprDateType.English)
            {
                appointmentDate = date.ToString("yyyy/MM/dd");
            }
            else
            {
                var convertedDated = DateConverter.GetDateInBS(date, seperator: "/");
                appointmentDate = convertedDated.formattedDate;
            }
            string[] k = appointmentDate.Split('/');
            givenYear = int.Parse(k[0]);
            givenMonth = int.Parse(k[1]);
            yearAfterGivenYear = givenYear + 1;
            yearBeforeGivenYear = givenYear - 1;
            //if fiscal year comprises of two different years. (ex:2075/76=>{2-1, 3-2, 4-3})
            possibleFiscalYearOne = (yearBeforeGivenYear + "/" + givenYear % 100); //one possible fiscal year for appointed year
            possibleFiscalYearTwo = (givenYear + "/" + yearAfterGivenYear % 100);  // another possible fiscal year for appointed year
            var durationOfPossibleFiscalYearOne = FiscalYearProvider.GetFiscalYears().Where(w => w.Year.Contains(possibleFiscalYearOne)).Select(fm => new
            {
                StartMonth = fm.FromMonth,
                EndMonth = fm.ToMonth,
            }).FirstOrDefault();
            //if fiscal year ends within a single year (ex:2075=>{1=12, 4=12, 3-12})
            if (durationOfPossibleFiscalYearOne == null)
            {
                var fiscalYearNew = FiscalYearProvider.GetFiscalYears().Where(w => w.Year.Equals(givenYear)).FirstOrDefault(); //Select(fm => fm.FromMonth).
                if (fiscalYearNew != null)
                {
                    requiredFiscalYear = fiscalYearNew.ToString();
                }
                else
                {
                    requiredFiscalYear = "";
                }
            }
            else
            {
                requiredFiscalYear = (givenMonth < durationOfPossibleFiscalYearOne.StartMonth && givenMonth <= durationOfPossibleFiscalYearOne.EndMonth) ? possibleFiscalYearOne : possibleFiscalYearTwo;
            }
            return requiredFiscalYear;
        }

        /// <summary>
        /// Retrieves a list of years from the start year (2000) to the current year in the English calendar.
        /// </summary>
        /// <returns>An enumerable list of integers representing years.</returns>
        public static IEnumerable<int?> GetYearListAd()
        {
            int startYear = 2000;
            int endYear = DateTime.Now.Year;

            List<int?> years = new List<int?>();
            for (int year = startYear; year <= endYear; year++)
            {
                years.Add(year);
            }

            return years;
        }

        /// <summary>
        /// Retrieves the fiscal year details based on the provided year in the format "YYYY/YY".
        /// </summary>
        /// <param name="year">The fiscal year to retrieve details for.</param>
        /// <returns>The fiscal year details or null if not found.</returns>
        public static FiscalYear GetFiscalYearByYear(string year)
        {
            // Assuming FiscalYearProvider.GetFiscalYears() returns a list of FiscalYear objects
            var fiscalYears = FiscalYearProvider.GetFiscalYears();

            // Filter the fiscal years based on the input year
            var fiscalYear = fiscalYears
                .FirstOrDefault(x => x.Year.Split('/')[0] == year);

            // Return the found fiscal year or null if not found
            return fiscalYear;
        }

        /// <summary>
        /// Calculates the duration between two time spans formatted as "HH:mm:ss".
        /// </summary>
        /// <param name="FromTime">The start time in "HH:mm:ss" format.</param>
        /// <param name="ToTime">The end time in "HH:mm:ss" format.</param>
        /// <returns>The duration between the two times formatted as "HH hrs mm min ss sec".</returns>
        public static string GetTimeDurationFromTwoTimeSpan(string FromTime, string ToTime)
        {
            try
            {
                DateTime dFrom;
                DateTime dTo;
                var TotalWorkingTime = string.Empty;
                if (DateTime.TryParse(FromTime, out dFrom) && DateTime.TryParse(ToTime, out dTo))
                {
                    TimeSpan TS = dTo - dFrom;
                    int hour = TS.Hours;
                    int mins = TS.Minutes;
                    int secs = TS.Seconds;

                    TotalWorkingTime = hour.ToString("00") + " hrs" + " " + mins.ToString("00") + " min" + " " + secs.ToString("00") + " sec";
                }
                return TotalWorkingTime;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }



    }

    
}