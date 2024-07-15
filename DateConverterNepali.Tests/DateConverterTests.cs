using System;
using Xunit;
using DateConverterNepali;

namespace DateConverterNepali.Tests
{

    public class DateConverterTests
    {
        #region GetDateInBS Tests

        [Fact]
        public void GetDateInBS_ValidConversion_FromAD()
        {
            // Arrange
            int adYear = 2024;
            int adMonth = 7;
            int adDay = 12;

            // Act
            var bsDate = DateConverter.GetDateInBS(adYear, adMonth, adDay);

            // Assert
            Assert.NotNull(bsDate);
            Assert.True(Calendar.ValidNepaliDate(bsDate.getFormattedDate()));
            Assert.Equal("2081-03-28", bsDate.getFormattedDate()); // Adjust based on your expected BS date format
        }

        [Fact]
        public void GetDateInBS_ValidConversion_FromDateTime()
        {
            // Arrange
            var adDate = new DateTime(2024, 7, 15);

            // Act
            var bsDate = DateConverter.GetDateInBS(adDate);

            // Assert
            Assert.NotNull(bsDate);
            Assert.True(Calendar.ValidNepaliDate(bsDate.getFormattedDate()));
            Assert.Equal("2081-03-31", bsDate.getFormattedDate()); // Adjust based on your expected BS date format
        }

        [Fact]
        public void GetDateInBS_InvalidDate()
        {
            // Arrange
            int adYear = 2023; // Non-leap year
            int adMonth = 2;   // February
            int adDay = 29;    // Invalid day for this year

            // Act
            var bsDate = DateConverter.GetDateInBS(adYear, adMonth, adDay);

            // Assert
            Assert.NotNull(bsDate);
            Assert.False(!Calendar.ValidNepaliDate(bsDate.getFormattedDate()));
        }

        #endregion


        [Fact]
        public void TestGetDateInBS_ValidDate()
        {
            // Arrange
            DateTime dateToConvert = new DateTime(2024, 7, 11);

            // Act
            NepaliDate nepaliDate = DateConverter.GetDateInBS(dateToConvert, DateFormats.yMd);

            // Assert
            Assert.Equal(2081, nepaliDate.npYear);
            Assert.Equal(3, nepaliDate.npMonth);
            Assert.Equal(27, nepaliDate.npDay);
        }

        [Fact]
        public void TestGetDateInAD_ValidDate()
        {
            // Arrange
            int bsYear = 2081;
            int bsMonth = 3;
            int bsDay = 27;

            // Act
            DateTime convertedDate = DateConverter.GetDateInAD(bsYear, bsMonth, bsDay).getFormattedDate();

            // Assert
            Assert.Equal(new DateTime(2024, 7, 11), convertedDate);
        }

        [Theory]
        [InlineData(2024, true)] // Leap year
        [InlineData(2023, false)] // Not a leap year
        public void TestIsLeapYear(int year, bool expected)
        {
            // Act
            bool result = Calendar.IsLeapYear(year);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, "Sunday")]
        [InlineData(3, "Wednesday")]
        [InlineData(6, "Saturday")]
        public void TestGetDayOfWeek(int dayOfWeekNumber, string expected)
        {
            // Act
            string result = Calendar.GetDayOfWeek(dayOfWeekNumber);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "January")]
        [InlineData(12, "December")]
        public void TestGetEnglishMonth(int monthNumber, string expected)
        {
            // Act
            string result = Calendar.GetEnglishMonth(monthNumber);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "बैशाख")]
        [InlineData(12, "चैत्र")]
        public void TestGetNepaliMonthInNepaliFont(int monthNumber, string expected)
        {
            // Act
            string result = Calendar.GetNepaliMonthInNepaliFont(monthNumber);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2024, 2, 29, true)] // Valid leap year date
        [InlineData(2023, 2, 29, false)] // Invalid leap year date
        public void TestValidEnglishDate(int year, int month, int day, bool expected)
        {
            // Act
            bool result = Calendar.ValidEnglishDate(year, month, day);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
