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
using System.Globalization;
using System.Text;

namespace DateConverterNepali
{
    /// <summary>
    /// Represents a date in the Gregorian (English) calendar.
    /// </summary>
    public class EnglishDate
    {
        private DateTime? _formattedDate;

        private int _engDaysInMonth;

        private int _engYear;

        private int _engMonth;

        private int _engDay;

        private string _dayName;

        private int _dayNumber;

        /// <summary>
        /// Gets or sets the number of days in the month for the English date.
        /// </summary>
        public int engDaysInMonth
        {
            get { return _engDaysInMonth; }
            set { _engDaysInMonth = value; }
        }

        /// <summary>
        /// Gets or sets the year of the English date.
        /// </summary>
        public int engYear
        {
            get { return _engYear; }
            set { _engYear = value; }
        }

        /// <summary>
        /// Gets or sets the month of the English date.
        /// </summary>
        public int engMonth
        {
            get { return _engMonth; }
            set
            {
                if (value > 12)
                {
                    throw new Exception("Month cannot be greater than 12.");
                }

                _engMonth = value;
            }
        }

        /// <summary>
        /// Gets or sets the day of the English date.
        /// </summary>
        public int engDay
        {
            get { return _engDay; }
            set
            {
                if (value > 31)
                {
                    throw new Exception("English Date cannot be greater than 31.");
                }

                _engDay = value;
            }
        }

        /// <summary>
        /// Gets or sets the day name of the English date.
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
        /// Gets or sets the day number of the English date.
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
        /// Gets the formatted date in DateTime format.
        /// </summary>
        public DateTime? formattedDate
        {
            get { return _formattedDate; }
        }

        /// <summary>
        /// Sets the formatted date based on the provided year, month, day, and format.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        /// <param name="format">The format in which to set the date.</param>
        public void setFormattedDate(int year, int month, int day)
        {
            _formattedDate = new DateTime(year, month, day);

            
        }

        /// <summary>
        /// Gets the formatted date as DateTime.
        /// </summary>
        /// <returns>The formatted date as DateTime.</returns>
        public DateTime getFormattedDate()
        {
            if (_formattedDate.HasValue)
            {
                return Convert.ToDateTime(_formattedDate);
            }

            if (engMonth == 0 || engYear == 0 || engDay == 0)
            {
                throw new Exception("Date value is not set. Please set the date value first.");
            }

            return new DateTime(engYear, engMonth, engDay);
        }
    }
}

