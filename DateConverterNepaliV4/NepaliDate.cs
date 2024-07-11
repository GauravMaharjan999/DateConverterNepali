using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateConverterNepali
{
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


        public int npYear
        {
            get
            {
                return _npYear;
            }
            set
            {
                _npYear = value;
            }
        }

        public int npMonth
        {
            get
            {
                return _npMonth;
            }
            set
            {
                if (value > 12)
                {
                    throw new Exception("Month cannot be greater than 12.");
                }

                _npMonth = value;
            }
        }

        public int npDay
        {
            get
            {
                return _npDay;
            }
            set
            {
                if (value > 32)
                {
                    throw new Exception("Nepali Date cannot be greater than 32.");
                }

                _npDay = value;
            }
        }
        public string nepaliMonthInNepaliFont
        {
            get
            {
                return _nepaliMonthInNepaliFont;
            }
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
        public string nepaliMonthInEnglishFont
        {
            get
            {
                return _nepaliMonthInEnglishFont;
            }
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

        public string nepaliDayInNepaliFont
        {
            get
            {
                return _nepaliDayInNepaliFont;
            }
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

        public int npDaysInMonth
        {
            get
            {
                return _npDaysInMonth;
            }
            set
            {
                _npDaysInMonth = value;
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
        public string formattedDate
        {
            get {
                return _formattedDate;
            }
        }

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

        public string getFormattedDate()
        {
            if (_formattedDate != null)
            {
                return _formattedDate;
            }

            return npMonth + "-" + npDay + "-" + npYear;
        }
    }
    public enum DateFormats
    {
        
        mDy,
        dMy,
        yMd
    }
}
