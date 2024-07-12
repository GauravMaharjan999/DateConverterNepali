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
