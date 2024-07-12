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
        public void setFormattedDate(int year, int month, int day, DateFormats date_format)
        {
            string formattedDate = "";
            string text = month.ToString();
            string text2 = day.ToString();
            if (month < 10)
            {
                text = "0" + month;
            }

            if (day < 10)
            {
                text2 = "0" + day;
            }

            switch (date_format)
            {
                case DateFormats.mDy:
                    formattedDate = text.ToString() + "-" + text2.ToString() + "-" + year;
                    break;
                case DateFormats.dMy:
                    formattedDate = text2.ToString() + "-" + text.ToString() + "-" + year;
                    break;
                case DateFormats.yMd:
                    formattedDate = year + "-" + text.ToString() + "-" + text2.ToString();
                    break;
                default:
                    formattedDate = String.Format("{0}/{1}/{2}", year, text, text2);
                    break;
            }

            _formattedDate = formattedDate;
        }

        /// <summary>
        /// Gets the formatted date as a string.
        /// </summary>
        /// <returns>The formatted date as a string.</returns>
        public string getFormattedDate()
        {
            if (_formattedDate != null)
            {
                return _formattedDate;
            }

            return npMonth + "-" + npDay + "-" + npYear;
        }
    }

    /// <summary>
    /// Enumeration of date formats for NepaliDate class.
    /// </summary>
    public enum DateFormats
    {
        /// <summary>
        /// Month-Day-Year format (MM-dd-yyyy).
        /// </summary>
        mDy,

        /// <summary>
        /// Day-Month-Year format (dd-MM-yyyy).
        /// </summary>
        dMy,

        /// <summary>
        /// Year-Month-Day format (yyyy-MM-dd).
        /// </summary>
        yMd
    }
}
