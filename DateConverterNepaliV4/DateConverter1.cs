/*
* MIT License
*
* Copyright (c) 2024 Gaurav Maharjan
* Email: gauravmaharjan000@gmail.com
* Unique GUID: 821ac4ef-94a3-4d1f-8a5d-c0c45a2c4984
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/

/*
* Apache License
* Version 2.0, January 2004
* http://www.apache.org/licenses/
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
//using System.Text.RegularExpressions;
//using System.Text;
//using System;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Linq;
//using System.Globalization;

//namespace DateConverterNepali
//{

//    public class DateConverter1
//    {
//        public static DateTime GetDateInAD(string dateInBS)
//        {
//            DateTime dateAD;
//            var k = new string[3];
//            var d = new string[3];
//            int bsYear = 0, bsMonth = 0, bsDay = 0;
//            if ((dateInBS.Contains("-")) || (dateInBS.Contains("/")))
//            {
//                if (dateInBS.Contains("-"))
//                {
//                    d = dateInBS.Split("-");
//                    if (d.Length == 3)
//                    {
//                        dateInBS = d[0] + '/' + d[1] + '/' + d[2];
//                    }
//                }
//                if (dateInBS.Contains("/"))
//                {
//                    k = dateInBS.Split("/");
//                    if (k.Length == 3)
//                    {
//                        bsYear = (int.TryParse(k[0], out int yr)) == true ? yr : 0;
//                        bsMonth = (int.TryParse(k[1], out int mm)) == true ? mm : 0;
//                        bsDay = (int.TryParse(k[2], out int dd)) == true ? dd : 0;
//                    }
//                }
//            }
//            if (bsYear <= 0 || bsMonth <= 0 || bsDay <= 0 || bsMonth > 12 || bsDay > 32)
//            {
//                return DateTime.MinValue;
//            }
//            int DayOfYearInBS = 0;
//            int yearInAD = bsYear - 57;
//            int[] bsDateData = DateArray.DateDataArray(yearInAD + 1);
//            if (bsDateData == null) { return DateTime.MinValue; }
//            for (int j = 3; j <= bsMonth + 1; j++)
//            {
//                DayOfYearInBS += bsDateData[j];
//            }
//            DayOfYearInBS += bsDay;
//            int initMonthInAD = 4;
//            int[] months = new int[] { 0, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30 };
//            int[] leapmonths = new int[] { 0, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 29, 31, 30 };
//            int initDaysInMonthAD = months[1];
//            int adTempDays = months[1] - bsDateData[0] + 1;
//            for (int i = 2; DayOfYearInBS > adTempDays; i++)
//            {
//                if (DateTime.IsLeapYear(yearInAD))
//                {
//                    adTempDays += leapmonths[i];
//                    initDaysInMonthAD = leapmonths[i];
//                }
//                else
//                {
//                    adTempDays += months[i];
//                    initDaysInMonthAD = months[i];
//                }
//                initMonthInAD++;
//                if (initMonthInAD > 12)
//                {
//                    initMonthInAD -= 12;
//                    yearInAD++;
//                }
//            }
//            int dayInAD = initDaysInMonthAD - (adTempDays - DayOfYearInBS);
//            string finalMonthInAD = (initMonthInAD < 10) ? "0" + initMonthInAD : initMonthInAD.ToString();
//            string finaldayInAD = (dayInAD < 10) ? "0" + dayInAD : dayInAD.ToString();
//            string dateInAD = String.Format("{0}/{1}/{2}", yearInAD, finalMonthInAD, finaldayInAD);
//            bool hasDate = DateTime.TryParse(dateInAD, out dateAD);
//            if (hasDate == true)
//            {
//                return dateAD;
//            }
//            else return DateTime.MinValue;
//        }
//        public static DateTime GetDateInAD(int bsYear, int bsMonth, int bsDay)
//        {
//            DateTime dateAD = DateTime.MinValue;

//            // Validate input
//            if (bsYear <= 0 || bsMonth <= 0 || bsDay <= 0 || bsMonth > 12 || bsDay > 32)
//            {
//                return DateTime.MinValue;
//            }

//            return GetDateInAD(string.Concat(bsYear, "/", bsMonth, "/", bsDay));
//        }
//        public static int GetYear(DateTime dateInAD, OprDateType opr)
//        {
//            if (opr == OprDateType.English)
//            {
//                return dateInAD.Year;
//            }
//            else
//            {
//                string dateInBS = GetDateInBS(dateInAD);
//                string[] k = new string[] { };
//                //if (dateInBS != null && dateInBS.Contains("-"))
//                if (dateInBS != null && dateInBS.Contains("/"))
//                {
//                    k = dateInBS.Split('/');
//                }
//                int year;
//                bool check = int.TryParse(k[0], out year);
//                return (check == true ? year : dateInAD.Year);
//            }
//        }
//        public static int GetDay(DateTime dateInAD, OprDateType opr)
//        {
//            if (opr == OprDateType.English)
//            {
//                return dateInAD.Day;
//            }
//            else
//            {
//                string dateInBS = GetDateInBS(dateInAD);
//                string[] k = new string[] { };
//                //if (dateInBS != null && dateInBS.Contains("-"))
//                if (dateInBS != null && dateInBS.Contains("/"))
//                {
//                    k = dateInBS.Split('/');
//                }
//                int day;
//                bool check = int.TryParse(k[2], out day);
//                return (check == true ? day : dateInAD.Day);
//            }
//        }
//        //Converts AD to BS
//        public static string GetFiscalYear(DateTime date, OprDateType oprDateType)
//        {
//            int givenYear, givenMonth, yearAfterGivenYear, yearBeforeGivenYear;
//            string requiredFiscalYear, possibleFiscalYearOne, possibleFiscalYearTwo;
//            var oprDate = oprDateType;
//            string appointmentDate = "";
//            if (oprDate == OprDateType.English)
//            {
//                appointmentDate = date.ToString("yyyy/MM/dd");

//            }
//            else
//            {
//                appointmentDate = GetDateInBS(date);

//            }
//            string[] k = appointmentDate.Split('/');
//            givenYear = int.Parse(k[0]);
//            givenMonth = int.Parse(k[1]);
//            yearAfterGivenYear = givenYear + 1;
//            yearBeforeGivenYear = givenYear - 1;
//            //if fiscal year comprises of two different years. (ex:2075/76=>{2-1, 3-2, 4-3})
//            possibleFiscalYearOne = (yearBeforeGivenYear + "/" + givenYear % 100); //one possible fiscal year for appointed year
//            possibleFiscalYearTwo = (givenYear + "/" + yearAfterGivenYear % 100);  // another possible fiscal year for appointed year
//            var durationOfPossibleFiscalYearOne = FiscalYearProvider.GetFiscalYears().Where(w => w.Year.Contains(possibleFiscalYearOne)).Select(fm => new
//            {
//                StartMonth = fm.FromMonth,
//                EndMonth = fm.ToMonth,
//            }).FirstOrDefault();
//            //if fiscal year ends within a single year (ex:2075=>{1=12, 4=12, 3-12})
//            if (durationOfPossibleFiscalYearOne == null)
//            {
//                var fiscalYearNew = FiscalYearProvider.GetFiscalYears().Where(w => w.Year.Equals(givenYear)).FirstOrDefault(); //Select(fm => fm.FromMonth).
//                if (fiscalYearNew != null)
//                {
//                    requiredFiscalYear = fiscalYearNew.ToString();
//                }
//                else
//                {
//                    requiredFiscalYear = "";
//                }
//            }
//            else
//            {
//                requiredFiscalYear = (givenMonth < durationOfPossibleFiscalYearOne.StartMonth && givenMonth <= durationOfPossibleFiscalYearOne.EndMonth) ? possibleFiscalYearOne : possibleFiscalYearTwo;
//            }
//            return requiredFiscalYear;
//        }
//        public static IEnumerable<int?> GetYearListAd()
//        {
//            int startYear = 2000;
//            int endYear = DateTime.Now.Year;

//            List<int?> years = new List<int?>();
//            for (int year = startYear; year <= endYear; year++)
//            {
//                years.Add(year);
//            }

//            return years;
//        }
//        public static string GetYearByFiscalYearId(int fiscalYearId)
//        {
//            var year = FiscalYearProvider.GetFiscalYears().Where(x => x.Id == fiscalYearId).Select(x => x.Year).FirstOrDefault();
//            return year;
//        }
//        public static string GetTimeDurationFromTwoTimeSpan(string FromTime, string ToTime)
//        {
//            try
//            {
//                DateTime dFrom;
//                DateTime dTo;
//                var TotalWorkingTime = string.Empty;
//                if (DateTime.TryParse(FromTime, out dFrom) && DateTime.TryParse(ToTime, out dTo))
//                {
//                    TimeSpan TS = dTo - dFrom;
//                    int hour = TS.Hours;
//                    int mins = TS.Minutes;
//                    int secs = TS.Seconds;

//                    TotalWorkingTime = hour.ToString("00") + " hrs" + " " + mins.ToString("00") + " min" + " " + secs.ToString("00") + " sec";
//                }
//                return TotalWorkingTime;
//            }
//            catch (Exception)
//            {
//                return string.Empty;
//            }
//        }

//        public static string GetDateInBS(DateTime dateInAD)
//        {
//            if (dateInAD == DateTime.MinValue)
//            {
//                return "";
//            }
//            else
//            {
//                //Getting BS date data for BS date calculation
//                int yearInAD = dateInAD.Year;
//                int[] bsFirstData = DateArray.DateDataArray(yearInAD);
//                int[] bsSecondData = DateArray.DateDataArray(yearInAD + 1);
//                //Getting AD day of the year
//                int dayOfYearInAD = dateInAD.DayOfYear;
//                //Initializing BS Year from the data
//                int yearInBS = bsFirstData[1];
//                //Initializing BS month to Poush          
//                int initMonthInBS = 9;
//                //Initializing BS DaysInMonth with total days in the month of Poush
//                int bsDaysInMonth = bsFirstData[11];
//                //Initializing temp nepali days
//                //This is sum of total days in each BS month starting Jan 1 in month Poush
//                int bsTempDays = bsFirstData[11] - bsFirstData[2] + 1;
//                List<int> fromBSFirstData = new List<int>();
//                //generates array of days from poush to chait
//                for (int p = 11; p < bsFirstData.Length; p++)
//                {
//                    fromBSFirstData.Add(bsFirstData[p]);
//                }
//                List<int> fromBSSecondData = new List<int>();
//                //generate array of days from baisakh to poush
//                for (int q = 3; q < 12; q++)
//                {
//                    fromBSSecondData.Add(bsSecondData[q]);
//                }
//                //  generate array of days in BS months
//                int[] newBSDateArray = fromBSFirstData.Concat(fromBSSecondData).ToArray();
//                //Looping through BS date data array to get exact BS month, BS year & BS daysInMonth information
//                for (int i = 1; dayOfYearInAD > bsTempDays; i++)
//                {
//                    bsTempDays += newBSDateArray[i];
//                    bsDaysInMonth = newBSDateArray[i];
//                    initMonthInBS++;
//                    if (initMonthInBS > 12)
//                    {
//                        initMonthInBS -= 12;
//                        yearInBS++;
//                    }
//                }
//                //Calculating BS day  
//                int dayInBS = bsDaysInMonth - (bsTempDays - dayOfYearInAD);
//                Console.WriteLine($"bsDaysInMonth : {bsDaysInMonth}");
//                string finalMonthInBS = (initMonthInBS < 10) ? "0" + initMonthInBS : initMonthInBS.ToString();
//                string finaldayInBS = (dayInBS < 10) ? "0" + dayInBS : dayInBS.ToString();
//                string dateInBS = String.Format("{0}/{1}/{2}", yearInBS, finalMonthInBS, finaldayInBS);
//                return dateInBS;
//            }
//        }
//        public static string GetDateInBS(int year, int month, int day)
//        {
//            // Checking for invalid dates
//            if (!IsValidDate(year, month, day))
//            {
//                return "";
//            }
//            else
//            {
//                var inputDate = new DateTime(year, month, day);
//                return GetDateInBS(inputDate);

//            }
//        }
//        public static ConvertToNepalOrEnglish.NepaliDate GetDateInBS(DateTime dateInAD)
//        {
//            if (dateInAD == DateTime.MinValue)
//            {
//                return new ConvertToNepalOrEnglish.NepaliDate();
//            }
//            else
//            {
//                //Getting BS date data for BS date calculation
//                int yearInAD = dateInAD.Year;
//                int[] bsFirstData = DateArray.DateDataArray(yearInAD);
//                int[] bsSecondData = DateArray.DateDataArray(yearInAD + 1);
//                //Getting AD day of the year
//                int dayOfYearInAD = dateInAD.DayOfYear;
//                //Initializing BS Year from the data
//                int yearInBS = bsFirstData[1];
//                //Initializing BS month to Poush          
//                int initMonthInBS = 9;
//                //Initializing BS DaysInMonth with total days in the month of Poush
//                int bsDaysInMonth = bsFirstData[11];
//                //Initializing temp nepali days
//                //This is sum of total days in each BS month starting Jan 1 in month Poush
//                int bsTempDays = bsFirstData[11] - bsFirstData[2] + 1;
//                List<int> fromBSFirstData = new List<int>();
//                //generates array of days from poush to chait
//                for (int p = 11; p < bsFirstData.Length; p++)
//                {
//                    fromBSFirstData.Add(bsFirstData[p]);
//                }
//                List<int> fromBSSecondData = new List<int>();
//                //generate array of days from baisakh to poush
//                for (int q = 3; q < 12; q++)
//                {
//                    fromBSSecondData.Add(bsSecondData[q]);
//                }
//                //  generate array of days in BS months
//                int[] newBSDateArray = fromBSFirstData.Concat(fromBSSecondData).ToArray();
//                //Looping through BS date data array to get exact BS month, BS year & BS daysInMonth information
//                for (int i = 1; dayOfYearInAD > bsTempDays; i++)
//                {
//                    bsTempDays += newBSDateArray[i];
//                    bsDaysInMonth = newBSDateArray[i];
//                    initMonthInBS++;
//                    if (initMonthInBS > 12)
//                    {
//                        initMonthInBS -= 12;
//                        yearInBS++;
//                    }
//                }
//                //Calculating BS day  
//                int dayInBS = bsDaysInMonth - (bsTempDays - dayOfYearInAD);
//                Console.WriteLine($"bsDaysInMonth : {bsDaysInMonth}");
//                string finalMonthInBS = (initMonthInBS < 10) ? "0" + initMonthInBS : initMonthInBS.ToString();
//                string finaldayInBS = (dayInBS < 10) ? "0" + dayInBS : dayInBS.ToString();
//                string dateInBS = String.Format("{0}/{1}/{2}", yearInBS, finalMonthInBS, finaldayInBS);
//                var finalNepaliDate = new ConvertToNepalOrEnglish.NepaliDate
//                {
//                    Year = yearInBS,
//                    Month = int.Parse(finalMonthInBS),
//                    Day = int.Parse(finalMonthInBS),


//                    //             public int Year { get; set; }
//                    //public int Month { get; set; }
//                    //public int Day { get; set; }
//                    //public string finalMonthInBS { get; set; }
//                    //public string MonthNameEnglish { get; set; }
//                    //public string MonthNameNepali { get; set; }
//                    //public int WeekDay { get; set; }
//                    //public int DaysInMonth { get; set; }
//                };
//                return dateInBS;
//            }
//        }


//        //Helper method to check if the date is valid
//        private static bool IsValidDate(int year, int month, int day)
//        {
//            if (year < 1 || month < 1 || month > 12 || day < 1 || day > DateTime.DaysInMonth(year, month))
//            {
//                return false;
//            }
//            return true;
//        }
//    }

//    public class ConvertToNepalOrEnglish
//    {
//        public class NepaliDate
//        {
//            public int Year { get; set; }
//            public int Month { get; set; }
//            public int Day { get; set; }
//            public string WeekDayName { get; set; }
//            public string MonthNameEnglish { get; set; }
//            public string MonthNameNepali { get; set; }
//            public int WeekDay { get; set; }
//            public int DaysInMonth { get; set; }

//        }


//        public static NepaliDate ConvertToNepali(int year, int month, int day)
//        {
//            NepaliDate nepaliDate = new NepaliDate();

//            // Convert AD date to BS date
//            string dateInBS = DateConverter1.GetDateInBS(year, month, day);

//            // Parse BS date to NepaliDate object
//            if (!string.IsNullOrEmpty(dateInBS))
//            {
//                string[] parts = dateInBS.Split('/');
//                if (parts.Length == 3 &&
//                    int.TryParse(parts[0], out int bsYear) &&
//                    int.TryParse(parts[1], out int bsMonth) &&
//                    int.TryParse(parts[2], out int bsDay))
//                {
//                    nepaliDate.Year = bsYear;
//                    nepaliDate.Month = bsMonth;
//                    nepaliDate.Day = bsDay;

//                    // Calculate weekday and month names
//                    DateTime adDate = new DateTime(year, month, day);
//                    nepaliDate.WeekDayName = adDate.ToString("dddd", CultureInfo.InvariantCulture);
//                    nepaliDate.MonthNameEnglish = adDate.ToString("MMMM", CultureInfo.InvariantCulture);
//                    nepaliDate.MonthNameNepali = GetNepaliMonthName(bsMonth);
//                    nepaliDate.WeekDay = (int)adDate.DayOfWeek;
//                }
//            }

//            return nepaliDate;
//        }

//        // Helper method to get Nepali month name
//        private static string GetNepaliMonthName(int month)
//        {
//            switch (month)
//            {
//                case 1: return "बैशाख";
//                case 2: return "जेठ";
//                case 3: return "असार";
//                case 4: return "साउन";
//                case 5: return "भदौ";
//                case 6: return "असोज";
//                case 7: return "कार्तिक";
//                case 8: return "मंसिर";
//                case 9: return "पुष";
//                case 10: return "माघ";
//                case 11: return "फाल्गुन";
//                case 12: return "चैत्र";
//                default: return "";
//            }
//        }

//        public static NepaliDate ConvertToEnglish(int bsYear, int bsMonth, int bsDay)
//        {
//            NepaliDate englishDate = new NepaliDate();

//            // Convert BS date to AD date
//            DateTime dateAD = DateConverter1.GetDateInAD(bsYear, bsMonth, bsDay);


//            // Populate NepaliDate object with AD date properties
//            if (dateAD != DateTime.MinValue)
//            {
//                englishDate.Year = dateAD.Year;
//                englishDate.Month = dateAD.Month;
//                englishDate.Day = dateAD.Day;
//                englishDate.WeekDayName = dateAD.ToString("dddd", CultureInfo.InvariantCulture);
//                englishDate.MonthNameEnglish = dateAD.ToString("MMMM", CultureInfo.InvariantCulture);
//                englishDate.MonthNameNepali = GetNepaliMonthName(bsMonth);
//                englishDate.WeekDay = (int)dateAD.DayOfWeek;
//            }

//            return englishDate;
//        }


//    }

//    public class Calendar
//    {
//        // Method to check if a year is leap year
//        public static bool IsLeapYear(int year)
//        {
//            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
//            {
//                return true;
//            }
//            return false;
//        }

//        // Method to get the name of the day of the week from its number (0-6, Sunday-Saturday)
//        public static string GetDayOfWeek(int weekDayNumber)
//        {
//            if (weekDayNumber < 0 || weekDayNumber > 6)
//            {
//                throw new ArgumentException("Invalid week day number. Week day number must be between 0 and 6.");
//            }
//            return Enum.GetName(typeof(DayOfWeek), weekDayNumber);
//        }

//        // Method to get the name of the English month for the provided month number (1-12)
//        public static string GetEnglishMonth(int monthNumber)
//        {
//            if (monthNumber < 1 || monthNumber > 12)
//            {
//                throw new ArgumentException("Invalid month number. Month number must be between 1 and 12.");
//            }
//            return new DateTime(2000, monthNumber, 1).ToString("MMMM");
//        }

//        // Method to get the name of the Nepali month for the provided month number (1-12)
//        public static string GetNepaliMonthInNepaliFont(int monthNumber)
//        {
//            switch (monthNumber)
//            {
//                case 1: return "बैशाख";
//                case 2: return "जेठ";
//                case 3: return "असार";
//                case 4: return "साउन";
//                case 5: return "भदौ";
//                case 6: return "असोज";
//                case 7: return "कार्तिक";
//                case 8: return "मंसिर";
//                case 9: return "पुष";
//                case 10: return "माघ";
//                case 11: return "फाल्गुन";
//                case 12: return "चैत्र";
//                default: throw new ArgumentException("Invalid month number. Month number must be between 1 and 12.");
//            }
//        }

//        // Method to validate if an English date is valid
//        public static bool ValidEnglishDate(int year, int month, int day)
//        {
//            try
//            {
//                DateTime date = new DateTime(year, month, day);
//                return true;
//            }
//            catch (ArgumentOutOfRangeException)
//            {
//                return false;
//            }
//        }

//        // Method to validate if a Nepali date is valid
//        public static bool ValidNepaliDate(int year, int month, int day)
//        {
//            try
//            {
//                // Convert Nepali date to AD date and then validate
//                DateTime adDate = DateConverter1.GetDateInAD(year, month, day);
//                return true;
//            }
//            catch (ArgumentOutOfRangeException)
//            {
//                return false;
//            }
//        }
//    }
//    public static class DateArray
//    {
//        public static int[] DateDataArray(int year)
//        {
//            switch (year)
//            {
//                case 1934: return new int[15] { 14, 1990, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 29 };
//                case 1935: return new int[15] { 13, 1991, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 1936: return new int[15] { 13, 1992, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1937: return new int[15] { 13, 1993, 18, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1938: return new int[15] { 13, 1994, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1939: return new int[15] { 13, 1995, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 1940: return new int[15] { 13, 1996, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1941: return new int[15] { 13, 1997, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1942: return new int[15] { 13, 1998, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1943: return new int[15] { 13, 1999, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1944: return new int[15] { 14, 2000, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1945: return new int[15] { 13, 2001, 19, 31, 31, 31, 31, 31, 31, 30, 29, 30, 29, 30, 31 };
//                case 1946: return new int[15] { 13, 2002, 18, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1947: return new int[15] { 13, 2003, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1948: return new int[15] { 14, 2004, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1949: return new int[15] { 13, 2005, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1950: return new int[15] { 13, 2006, 18, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1951: return new int[15] { 13, 2007, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1952: return new int[15] { 14, 2008, 17, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 };
//                case 1953: return new int[15] { 13, 2009, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1954: return new int[15] { 13, 2010, 18, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1955: return new int[15] { 13, 2011, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1956: return new int[15] { 14, 2012, 17, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 1957: return new int[15] { 13, 2013, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1958: return new int[15] { 13, 2014, 18, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1959: return new int[15] { 13, 2015, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1960: return new int[15] { 14, 2016, 17, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 1961: return new int[15] { 13, 2017, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1962: return new int[15] { 13, 2018, 18, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1963: return new int[15] { 13, 2019, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1964: return new int[15] { 14, 2020, 17, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1965: return new int[15] { 13, 2021, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1966: return new int[15] { 13, 2022, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 1967: return new int[15] { 13, 2023, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1968: return new int[15] { 14, 2024, 17, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1969: return new int[15] { 13, 2025, 18, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1970: return new int[15] { 13, 2026, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1971: return new int[15] { 14, 2027, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1972: return new int[15] { 14, 2028, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1973: return new int[15] { 13, 2029, 18, 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 };
//                case 1974: return new int[15] { 13, 2030, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1975: return new int[15] { 14, 2031, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1976: return new int[15] { 14, 2032, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1977: return new int[15] { 13, 2033, 18, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1978: return new int[15] { 13, 2034, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1979: return new int[15] { 14, 2035, 17, 30, 32, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 };
//                case 1980: return new int[15] { 14, 2036, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1981: return new int[15] { 13, 2037, 18, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1982: return new int[15] { 13, 2038, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1983: return new int[15] { 14, 2039, 17, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 1984: return new int[15] { 14, 2040, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1985: return new int[15] { 13, 2041, 18, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1986: return new int[15] { 13, 2042, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1987: return new int[15] { 14, 2043, 17, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 1988: return new int[15] { 14, 2044, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1989: return new int[15] { 13, 2045, 18, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 1990: return new int[15] { 13, 2046, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 1991: return new int[15] { 14, 2047, 17, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1992: return new int[15] { 14, 2048, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1993: return new int[15] { 13, 2049, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 1994: return new int[15] { 13, 2050, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1995: return new int[15] { 14, 2051, 17, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1996: return new int[15] { 14, 2052, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 1997: return new int[15] { 13, 2053, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 1998: return new int[15] { 13, 2054, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 1999: return new int[15] { 14, 2055, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2000: return new int[15] { 14, 2056, 17, 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 };
//                case 2001: return new int[15] { 13, 2057, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2002: return new int[15] { 14, 2058, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2003: return new int[15] { 14, 2059, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2004: return new int[15] { 14, 2060, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2005: return new int[15] { 13, 2061, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2006: return new int[15] { 14, 2062, 17, 31, 31, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31 };
//                case 2007: return new int[15] { 14, 2063, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2008: return new int[15] { 14, 2064, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2009: return new int[15] { 13, 2065, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2010: return new int[15] { 14, 2066, 17, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 };
//                case 2011: return new int[15] { 14, 2067, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2012: return new int[15] { 14, 2068, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2013: return new int[15] { 13, 2069, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2014: return new int[15] { 14, 2070, 17, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 2015: return new int[15] { 14, 2071, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2016: return new int[15] { 14, 2072, 17, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2017: return new int[15] { 13, 2073, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2018: return new int[15] { 14, 2074, 17, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2019: return new int[15] { 14, 2075, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2020: return new int[15] { 14, 2076, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 2021: return new int[15] { 13, 2077, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2022: return new int[15] { 14, 2078, 17, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2023: return new int[15] { 14, 2079, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2024: return new int[15] { 14, 2080, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 2025: return new int[15] { 13, 2081, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                //case 2025: return new int[15] { 13, 2081, 17, 31, 31, 32, 32, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2026: return new int[15] { 14, 2082, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2027: return new int[15] { 14, 2083, 17, 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2028: return new int[15] { 14, 2084, 17, 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2029: return new int[15] { 13, 2085, 17, 31, 32, 31, 32, 30, 31, 30, 30, 29, 30, 30, 30 };
//                case 2030: return new int[15] { 14, 2086, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2031: return new int[15] { 14, 2087, 16, 31, 31, 32, 31, 31, 31, 30, 30, 29, 30, 30, 30 };
//                case 2032: return new int[15] { 15, 2088, 16, 30, 31, 32, 32, 30, 31, 30, 30, 29, 30, 30, 30 };
//                case 2033: return new int[15] { 14, 2089, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2034: return new int[15] { 14, 2090, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2035: return new int[15] { 14, 2091, 16, 31, 31, 32, 31, 31, 31, 30, 30, 29, 30, 30, 30 };
//                case 2036: return new int[15] { 15, 2092, 16, 30, 31, 32, 32, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2037: return new int[15] { 14, 2093, 17, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2038: return new int[15] { 14, 2094, 17, 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2039: return new int[15] { 14, 2095, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 30, 30, 30 };
//                case 2040: return new int[15] { 15, 2096, 17, 30, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2041: return new int[15] { 13, 2097, 17, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 };
//                case 2042: return new int[15] { 14, 2098, 17, 31, 31, 32, 31, 31, 31, 29, 30, 29, 30, 29, 31 };
//                case 2043: return new int[15] { 14, 2099, 17, 31, 31, 32, 31, 31, 31, 30, 29, 29, 30, 30, 30 };
//                case 2044: return new int[15] { 14, 2100, 17, 31, 32, 31, 32, 30, 31, 30, 29, 30, 29, 30, 30 };
//                case 2045: return new int[15] { 14, 2101, 17, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2046: return new int[15] { 14, 2102, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2047: return new int[15] { 14, 2103, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 2048: return new int[15] { 14, 2104, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2049: return new int[15] { 14, 2105, 17, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2050: return new int[15] { 14, 2106, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2051: return new int[15] { 14, 2107, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 2052: return new int[15] { 14, 2108, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2053: return new int[15] { 14, 2109, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2054: return new int[15] { 14, 2110, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2055: return new int[15] { 14, 2111, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2056: return new int[15] { 15, 2112, 16, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2057: return new int[15] { 14, 2113, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2058: return new int[15] { 14, 2114, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2059: return new int[15] { 14, 2115, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2060: return new int[15] { 15, 2116, 16, 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31 };
//                case 2061: return new int[15] { 14, 2117, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2062: return new int[15] { 14, 2118, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2063: return new int[15] { 14, 2119, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2064: return new int[15] { 15, 2120, 16, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 };
//                case 2065: return new int[15] { 14, 2121, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2066: return new int[15] { 14, 2122, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2067: return new int[15] { 14, 2123, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2068: return new int[15] { 15, 2124, 16, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 2069: return new int[15] { 14, 2125, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2070: return new int[15] { 14, 2126, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2071: return new int[15] { 14, 2127, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2072: return new int[15] { 15, 2128, 16, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 2073: return new int[15] { 14, 2129, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2074: return new int[15] { 14, 2130, 17, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2075: return new int[15] { 14, 2131, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2076: return new int[15] { 15, 2132, 16, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2077: return new int[15] { 14, 2133, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2078: return new int[15] { 14, 2134, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 2079: return new int[15] { 14, 2135, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2080: return new int[15] { 15, 2136, 16, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2081: return new int[15] { 14, 2137, 17, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2082: return new int[15] { 14, 2138, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2083: return new int[15] { 15, 2139, 16, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2084: return new int[15] { 15, 2140, 16, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2085: return new int[15] { 14, 2141, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2086: return new int[15] { 14, 2142, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2087: return new int[15] { 15, 2143, 16, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2088: return new int[15] { 15, 2144, 16, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2089: return new int[15] { 14, 2145, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2090: return new int[15] { 14, 2146, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2091: return new int[15] { 15, 2147, 16, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 };
//                case 2092: return new int[15] { 15, 2148, 16, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2093: return new int[15] { 14, 2149, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2094: return new int[15] { 14, 2150, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2095: return new int[15] { 15, 2151, 16, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 2096: return new int[15] { 15, 2152, 16, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2097: return new int[15] { 14, 2153, 17, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2098: return new int[15] { 14, 2154, 16, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2099: return new int[15] { 15, 2155, 16, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 2100: return new int[15] { 15, 2156, 16, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2101: return new int[15] { 15, 2157, 16, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2102: return new int[15] { 15, 2158, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2103: return new int[15] { 16, 2159, 15, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2104: return new int[15] { 16, 2160, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2105: return new int[15] { 15, 2161, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 2106: return new int[15] { 15, 2162, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2107: return new int[15] { 16, 2163, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2108: return new int[15] { 16, 2164, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2109: return new int[15] { 15, 2165, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2110: return new int[15] { 16, 2166, 15, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2111: return new int[15] { 16, 2167, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2112: return new int[15] { 16, 2168, 15, 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 };
//                case 2113: return new int[15] { 15, 2169, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2114: return new int[15] { 16, 2170, 15, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2115: return new int[15] { 16, 2171, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2116: return new int[15] { 16, 2172, 15, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2117: return new int[15] { 15, 2173, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2118: return new int[15] { 16, 2174, 15, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 };
//                case 2119: return new int[15] { 16, 2175, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2120: return new int[15] { 16, 2176, 15, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2121: return new int[15] { 15, 2177, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2122: return new int[15] { 16, 2178, 15, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 2123: return new int[15] { 16, 2179, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2124: return new int[15] { 16, 2180, 15, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2125: return new int[15] { 15, 2181, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2126: return new int[15] { 16, 2182, 15, 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 };
//                case 2127: return new int[15] { 16, 2183, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2128: return new int[15] { 16, 2184, 15, 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2129: return new int[15] { 15, 2185, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2130: return new int[15] { 16, 2186, 15, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2131: return new int[15] { 16, 2187, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2132: return new int[15] { 16, 2188, 14, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 2133: return new int[15] { 15, 2189, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2134: return new int[15] { 16, 2190, 15, 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2135: return new int[15] { 16, 2191, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2136: return new int[15] { 16, 2192, 14, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 };
//                case 2137: return new int[15] { 15, 2193, 15, 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2138: return new int[15] { 16, 2194, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2139: return new int[15] { 16, 2195, 15, 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 };
//                case 2140: return new int[15] { 16, 2196, 14, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 };
//                case 2141: return new int[15] { 16, 2197, 15, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 };
//                case 2142: return new int[15] { 16, 2198, 15, 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 };
//                case 2143: return new int[15] { 16, 2199, 15, 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 };
//                case 2144: return new int[15] { 16, 2200, 14, 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 29 };
//                default:
//                    return null;
//            }
//        }
//    }
//}
