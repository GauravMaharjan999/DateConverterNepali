using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DateConverterNepali
{
    public class EnglishDate
    {
        private DateTime? _formattedDate;

        private int _engDaysInMonth;

        private int _engYear;

        private int _engMonth;

        private int _engDay;

        private string _dayName;

        private int _dayNumber;

        public int engDaysInMonth
        {
            get
            {
                return _engDaysInMonth;
            }
            set
            {
                _engDaysInMonth = value;
            }
        }

        public int engYear
        {
            get
            {
                return _engYear;
            }
            set
            {
                _engYear = value;
            }
        }

        public int engMonth
        {
            get
            {
                return _engMonth;
            }
            set
            {
                if (value > 12)
                {
                    throw new Exception("Month cannot be greater than 12.");
                }

                _engMonth = value;
            }
        }

        public int engDay
        {
            get
            {
                return _engDay;
            }
            set
            {
                if (value > 31)
                {
                    throw new Exception("English Date cannot be greater than 31.");
                }

                _engDay = value;
            }
        }

        public string dayName
        {
            get
            {
                return _dayName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Day name cannot be empty.");
                }

                _dayName = value;
            }
        }

        public int dayNumber
        {
            get
            {
                return _dayNumber;
            }
            set
            {
                if (value < 1 || value > 7)
                {
                    throw new Exception("Day number must range between 1 and 7.");
                }

                _dayNumber = value;
            }
        }
        public DateTime? formattedDate
        {
            get
            {
                return _formattedDate;
            }
        }


        public void setFormattedDate(int year, int month, int day, DateFormats format)
        {
            _formattedDate = new DateTime(year, month, day);

                string dateFormat;
                switch (format)
                {
                    case DateFormats.mDy:
                        dateFormat = "MM/dd/yyyy";
                        break;
                    case DateFormats.dMy:
                        dateFormat = "dd/MM/yyyy";
                        break;
                    case DateFormats.yMd:
                        dateFormat = "yyyy/MM/dd";
                        break;
                    default:
                        dateFormat = "MM/dd/yyyy"; // Default format
                        break;
                }

                string formattedDate = _formattedDate?.ToString(dateFormat, CultureInfo.InvariantCulture);

                // Parse the formatted date back to DateTime
                if (DateTime.TryParseExact(formattedDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    _formattedDate = parsedDate;
                }
                else
                {
                    throw new FormatException("Unable to parse the formatted date.");
                }
           
        }

        public DateTime getFormattedDate()
        {
            if (_formattedDate.HasValue)
            {
                return Convert.ToDateTime(_formattedDate);
            }

            if (engMonth == 0 || engYear == 0 || engDay == 0)
            {
                throw new Exception("Date value is not set.Please set the date value first.");
            }

            return new DateTime(engYear, engMonth, engDay);
        }
    }
}
