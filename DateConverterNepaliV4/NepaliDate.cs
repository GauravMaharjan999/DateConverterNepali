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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateConverterNepali
{
    /// <summary>
    /// The NepaliDate class provides properties and methods for managing Nepali date operations,
    /// including setting and retrieving dates in different formats.
    /// </summary>
    public class NepaliDate
    {
        private string _formattedDate;

        private int _npDaysInMonth;

        private int _npYear;

        private int _npMonth;

        private int _npDay;

        private string _dayName;

        private int _dayNumber;
        private string _nepaliMonthInNepaliFont;
        private string _nepaliMonthInEnglishFont;
        private string _nepaliDayInNepaliFont;

        /// <summary>
        /// Gets or sets the year of the Nepali date.
        /// </summary>
        public int npYear
        {
            get { return _npYear; }
            set { _npYear = value; }
        }

        /// <summary>
        /// Gets or sets the month of the Nepali date.
        /// </summary>
        public int npMonth
        {
            get { return _npMonth; }
            set
            {
                if (value > 12)
                {
                    throw new Exception("Month cannot be greater than 12.");
                }

                _npMonth = value;
            }
        }

        /// <summary>
        /// Gets or sets the day of the Nepali date.
        /// </summary>
        public int npDay
        {
            get { return _npDay; }
            set
            {
                if (value > 32)
                {
                    throw new Exception("Nepali Date cannot be greater than 32.");
                }

                _npDay = value;
            }
        }

        /// <summary>
        /// Gets or sets the month name in Nepali font.
        /// </summary>
        public string nepaliMonthInNepaliFont
        {
            get { return _nepaliMonthInNepaliFont; }
            set
            {
                switch (int.Parse(value))
                {
                    case 1: _nepaliMonthInNepaliFont = "बैशाख"; break;
                    case 2: _nepaliMonthInNepaliFont = "जेठ"; break;
                    case 3: _nepaliMonthInNepaliFont = "असार"; break;
                    case 4: _nepaliMonthInNepaliFont = "साउन"; break;
                    case 5: _nepaliMonthInNepaliFont = "भदौ"; break;
                    case 6: _nepaliMonthInNepaliFont = "असोज"; break;
                    case 7: _nepaliMonthInNepaliFont = "कार्तिक"; break;
                    case 8: _nepaliMonthInNepaliFont = "मंसिर"; break;
                    case 9: _nepaliMonthInNepaliFont = "पुष"; break;
                    case 10: _nepaliMonthInNepaliFont = "माघ"; break;
                    case 11: _nepaliMonthInNepaliFont = "फाल्गुन"; break;
                    case 12: _nepaliMonthInNepaliFont = "चैत्र"; break;
                    default: throw new ArgumentException("Invalid month number. Month number must be between 1 and 12.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the month name in English font.
        /// </summary>
        public string nepaliMonthInEnglishFont
        {
            get { return _nepaliMonthInEnglishFont; }
            set
            {
                var month = MonthBSProvider.GetMonths().FirstOrDefault(x => x.Id == int.Parse(value));
                if (month != null)
                {
                    _nepaliMonthInEnglishFont = month.Name;
                }
                else
                {
                    throw new ArgumentException("Invalid month number. Month number must be between 1 and 12.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the day name in Nepali font.
        /// </summary>
        public string nepaliDayInNepaliFont
        {
            get { return _nepaliDayInNepaliFont; }
            set
            {
                int dayNumber;
                if (int.TryParse(value, out dayNumber))
                {
                    _nepaliDayInNepaliFont = NepaliDayProvider.GetNepaliFontDayName(dayNumber);
                }
                else
                {
                    throw new ArgumentException("Invalid input. Input must be a number between 0 and 6.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of days in the month for the Nepali date.
        /// </summary>
        public int npDaysInMonth
        {
            get { return _npDaysInMonth; }
            set { _npDaysInMonth = value; }
        }

        /// <summary>
        /// Gets or sets the day name of the Nepali date.
        /// </summary>
        public string dayName
        {
            get { return _dayName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Day name cannot be empty.");
                }

                _dayName = value;
            }
        }

        /// <summary>
        /// Gets or sets the day number of the Nepali date.
        /// </summary>
        public int dayNumber
        {
            get { return _dayNumber; }
            set
            {
                if (value < 1 || value > 7)
                {
                    throw new Exception("Day number must range between 1 and 7.");
                }

                _dayNumber = value;
            }
        }

        /// <summary>
        /// Gets the formatted date as a string.
        /// </summary>
        public string formattedDate
        {
            get { return _formattedDate; }
        }

        /// <summary>
        /// Sets the formatted date based on the provided year, month, day, and format.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        /// <param name="date_format">The format in which to set the date.</param>
        public void setFormattedDate(int year, int month, int day, DateFormats date_format=0, string seperator = "-")
        {
            string formattedDate = "";
            string strMonth = month.ToString();
            string strDay = day.ToString();
            if (month < 10)
            {
                strMonth = "0" + month;
            }

            if (day < 10)
            {
                strDay = "0" + day;
            }

            switch (date_format)
            {
                case DateFormats.mDy:
                    formattedDate = strMonth.ToString() + seperator + strDay.ToString() + seperator + year;
                    break;
                case DateFormats.dMy:
                    formattedDate = strDay.ToString() + seperator + strMonth.ToString() + seperator + year;
                    break;
                case DateFormats.yMd:
                    formattedDate = year + seperator + strMonth.ToString() + seperator + strDay.ToString();
                    break;
                default:
                    formattedDate = String.Format("{0}{3}{1}{3}{2}", year, strMonth, strDay,seperator);
                    break;
            }

            _formattedDate = formattedDate;
        }

        /// <summary>
        /// Gets the formatted date as a string.
        /// </summary>
        /// <returns>The formatted date as a string.</returns>
        public string getFormattedDate(string seperator = "-")
        {
            if (_formattedDate != null)
            {
                return _formattedDate;
            }

            //return npMonth + "-" + npDay + "-" + npYear;
            return npYear  + seperator + npMonth + seperator + npDay;
        }
    }

    /// <summary>
    /// Enumeration of date formats for NepaliDate class.
    /// </summary>
    public enum DateFormats
    {
        /// <summary>
        /// Year-Month-Day format (yyyy-MM-dd).
        /// </summary>
        yMd,
        /// <summary>
        /// Month-Day-Year format (MM-dd-yyyy).
        /// </summary>
        mDy,

        /// <summary>
        /// Day-Month-Year format (dd-MM-yyyy).
        /// </summary>
        dMy,


    }
}

