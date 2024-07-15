
# DateConverterNepali

DateConverterNepali is a .NET library that provides functionality to convert dates between the Nepali (Bikram Sambat) calendar and the Gregorian calendar, as well as validate dates and calculate time durations.

## Installation

You can install the package via NuGet:

```sh
Install-Package DateConverterNepali
```

## Usage

# Date Converter Class

This class contains static methods which can be used to convert dates.

### Methods

| Method       | Parameters                                                     | Description                                                | Returns|
|--------------|----------------------------------------------------------------|------------------------------------------------------------|----------------------------------------------------|
| `GetDateInBS`| `int year, int month, int day, DateFormats date_format = 0, string separator = "-"` | Converts a Gregorian (AD) date to Nepali (BS) date.        | NepaliDate Class|
| `GetDateInBS`| `DateTime dateInAD, DateFormats date_format = 0, string separator = "-"`            | Converts a Gregorian (AD) DateTime object to Nepali (BS) date. | NepaliDate Class|
| `GetDateInAD`| `int bsYear, int bsMonth, int bsDay`                           | Converts a Nepali (BS) date to Gregorian (AD) date.        | EnglishDate Class|
| `GetDateInAD`| `string dateInBS`                                              | Converts a Nepali (BS) date string to Gregorian (AD) date. | EnglishDate Class|


#### Return Object Properties

##### Nepali Date class
| Variable     | Description                              | Data Type |
|--------------|------------------------------------------|--------------------|
| `npYear`       | Converted Year                           | int|
| `npMonth`      | Converted Month                          |int|
| `npDay`        | Converted Day                            |int|
| `nepaliMonthInNepaliFont`        | Converted Month Name in Nepali Font Ex.(फाल्गुन)                       |string|
| `nepaliMonthInEnglishFont`        | Converted Month Name in English Font Ex. Falgun                           |string|
| `nepaliDayInNepaliFont`        | Converted Day  Ex. शुक्रबार                          |string|
| `dayName`  | Name of the month for the converted date Ex. Friday |string|
| `dayNumber`    | Week day number for the converted date Ex. 6 (For Friday)|int|
| `npDaysInMonth`| Number of Days in the Converted Month   |int|
| `formattedDate`    | Formatted date In Given Format . Default (yyyy-MM-dd)    |string|

##### English Date class
| Variable     | Description                              | Data Type                              |
|--------------|------------------------------------------|------------------------------------------|
| `engYear`       | Converted Year                           |int|
| `engMonth`      | Converted Month                          |int|
| `engDay`        | Converted Day                            |int|
| `dayName`        | Converted Day Name Ex. Friday                      |string|
| `dayNumber`        | Converted Day  Ex. शुक्रबार                          |int|
| `formattedDate`  | Formatted date In Given Format . Default (MM-dd-year) |DateTime|
| `engDaysInMonth`| Number of Days in the Converted Month   |int|


# Calendar

This class contains methods to validate dates and calculate time durations.

### Methods

| Method                          | Parameters                                                     | Description                                                          |
|---------------------------------|----------------------------------------------------------------|----------------------------------------------------------------------|
| `IsLeapYear`                    | `int year`                                                     | Returns a boolean indicating if the year is a leap year or not.      |
| `GetDayOfWeek`                  | `int weekDayNumber`                                            | Returns the name of the day of the week.                             |
| `GetEnglishMonth`               | `int monthNumber`                                              | Returns the name of the English month for the provided month number. |
| `GetNepaliMonthInNepaliFont`    | `int monthNumber`                                              | Returns the name of the Nepali month for the provided month number.  |
| `GetTimeDurationFromTwoTimeSpan`| `string FromTime, string ToTime`                               | Calculates the duration between two time spans and returns it as a formatted string. |
| `ValidEnglishDate`              | `int year, int month, int day`                                 | Returns a boolean indicating if the entered English date is valid or not. |
| `ValidEnglishDate`              | `DateTime date`                                                | Returns a boolean indicating if the DateTime object represents a valid English date. |
| `ValidNepaliDate`               | `int npYear, int npMonth, int npDay`                           | Returns a boolean indicating if the entered Nepali date is valid by converting it to an AD date. |
| `ValidNepaliDate`               | `string npDate, DateFormats dateFormats = 0`                   | Returns a boolean indicating if the entered Nepali date string is valid by converting it to an AD date. |



# TimeConverter Class
### Methods

| Method                                                        | Variable                    | Description                                                                                       | Data Type           |
|---------------------------------------------------------------|-----------------------------|---------------------------------------------------------------------------------------------------|---------------------|
| `ConvertToNepaliDateTime(DateTime englishDateTime)`           | `englishDateTime`           | The English date and time to convert.                                                             | `DateTime`          |
|                                                               | `nepaliYear`                | Year part of the converted Nepali date.                                                           | `int`               |
|                                                               | `nepaliMonth`               | Month part of the converted Nepali date.                                                          | `int`               |
|                                                               | `nepaliDay`                 | Day part of the converted Nepali date.                                                            | `int`               |
|                                                               | `hour`                      | Hour part of the converted time.                                                                  | `int`               |
|                                                               | `minute`                    | Minute part of the converted time.                                                                | `int`               |
|                                                               | `second`                    | Second part of the converted time.                                                                | `int`               |
| `ConvertUtcToNepaliTime(TimeSpan utcTime)`                    | `utcTime`                   | The UTC time to convert.                                                                          | `TimeSpan`          |
|                                                               | `nepaliTime`                | The corresponding Nepali time as a `TimeSpan`.                                                    | `TimeSpan`          |
| `ConvertNepaliTimeToUtc(TimeSpan nepaliTime)`                 | `nepaliTime`                | The Nepali time to convert.                                                                       | `TimeSpan`          |
|                                                               | `utcTime`                   | The corresponding UTC time as a `TimeSpan`.                                                       | `TimeSpan`          |

# FiscalYearHelper Class
### Methods

| Method                                                        | Variable                    | Description                                                                                       | Data Type           |
|---------------------------------------------------------------|-----------------------------|---------------------------------------------------------------------------------------------------|---------------------|
| `GetYear(DateTime dateInAD, OprDateType opr)`                 | `dateInAD`                  | The date in English calendar or equivalent in Nepali calendar.                                    | `DateTime`          |
|                                                               | `opr`                       | The type of calendar system, English or Nepali.                                                   | `OprDateType`       |
|                                                               | `year`                      | The year part of the date.                                                                        | `int`               |
| `GetDay(DateTime dateInAD, OprDateType opr)`                  | `dateInAD`                  | The date in English calendar or equivalent in Nepali calendar.                                    | `DateTime`          |
|                                                               | `opr`                       | The type of calendar system, English or Nepali.                                                   | `OprDateType`       |
|                                                               | `day`                       | The day part of the date.                                                                         | `int`               |
| `GetFiscalYear(DateTime date, OprDateType oprDateType)`       | `date`                      | The date for which to determine the fiscal year.                                                  | `DateTime`          |
|                                                               | `oprDateType`               | The type of calendar system, English or Nepali.                                                   | `OprDateType`       |
|                                                               | `fiscalYear`                | The fiscal year in the format "YYYY/YY".                                                          | `string`            |
| `GetYearListAd()`                                             | `years`                     | A list of years from the start year (2000) to the current year in the English calendar.           | `IEnumerable<int?>` |
| `GetFiscalYearByYear(string year)`                            | `year`                      | The fiscal year to retrieve details for.                                                          | `string`            |
|                                                               | `fiscalYear`                | The fiscal year details or null if not found.                                                     | `FiscalYear`        |
| `GetTimeDurationFromTwoTimeSpan(string FromTime, string ToTime)` | `FromTime`               | The start time in "HH:mm:ss" format.                                                              | `string`            |
|                                                               | `ToTime`                    | The end time in "HH:mm:ss" format.                                                                | `string`            |
|                                                               | `TotalWorkingTime`          | The duration between the two times formatted as "HH hrs mm min ss sec".                           | `string`            |

## Example Usage

## Examples

Here are some examples of how to use the DateConverterNepali library:



## Date Converter Class

### Convert Gregorian (AD) Date to Nepali (BS) Date

```csharp
var nepaliDate = DateConverter.GetDateInBS(2023, 7, 14, DateFormats.dMy, "-");
Console.WriteLine($"Nepali Date: {nepaliDate.FormattedDate}");
```

### Convert Gregorian (AD) DateTime to Nepali (BS) Date

```csharp
var nepaliDateFromDateTime = DateConverter.GetDateInBS(new DateTime(2023, 7, 14), DateFormats.yMd, "/");
Console.WriteLine($"Nepali Date from DateTime: {nepaliDateFromDateTime.FormattedDate}");
```

### Convert Nepali (BS) Date to Gregorian (AD) Date

```csharp
var englishDate = DateConverter.GetDateInAD(2080, 3, 1);
Console.WriteLine($"English Date: {englishDate.FormattedDate}");
```

### Convert Nepali (BS) Date String to Gregorian (AD) Date

```csharp
var englishDateFromString = DateConverter.GetDateInAD("2080/3/1");
Console.WriteLine($"English Date from String: {englishDateFromString.FormattedDate}");
```

## Fiscal Year Helper class
### ConvertToNepaliDateTime

```csharp
var nepaliDateTime = TimeConverter.ConvertToNepaliDateTime(new DateTime(2024, 7, 12, 15, 30, 0));
Console.WriteLine($"Nepali Date and Time: {nepaliDateTime.year}/{nepaliDateTime.month}/{nepaliDateTime.day} {nepaliDateTime.hour}:{nepaliDateTime.minute}:{nepaliDateTime.second}");
```

### ConvertUtcToNepaliTime

```csharp
var nepaliTime = TimeConverter.ConvertUtcToNepaliTime(new TimeSpan(10, 0, 0));
Console.WriteLine($"Nepali Time: {nepaliTime}");
```

### ConvertNepaliTimeToUtc

```csharp
var utcTime = TimeConverter.ConvertNepaliTimeToUtc(new TimeSpan(15, 45, 0));
Console.WriteLine($"UTC Time: {utcTime}");
```

### GetYear

```csharp
int year = FiscalYearHelper.GetYear(new DateTime(2024, 7, 14), OprDateType.English);
Console.WriteLine($"Year: {year}");
```

### GetDay

```csharp
int day = FiscalYearHelper.GetDay(new DateTime(2024, 7, 14), OprDateType.English);
Console.WriteLine($"Day: {day}");
```

### GetFiscalYear

```csharp
string fiscalYear = FiscalYearHelper.GetFiscalYear(new DateTime(2024, 7, 14), OprDateType.English);
Console.WriteLine($"Fiscal Year: {fiscalYear}");
```

### GetYearListAd

```csharp
var years = FiscalYearHelper.GetYearListAd();
foreach (var year in years)
{
    Console.WriteLine(year);
}
```

### GetFiscalYearByYear

```csharp
var fiscalYearDetails = FiscalYearHelper.GetFiscalYearByYear("2075");
Console.WriteLine($"Fiscal Year Details: {fiscalYearDetails}");
```

### GetTimeDurationFromTwoTimeSpan

```csharp
string duration = FiscalYearHelper.GetTimeDurationFromTwoTimeSpan("08:00:00", "17:00:00");
Console.WriteLine($"Duration: {duration}");
```






## Calender class


### IsLeapYear

```csharp
// Check if a year is a leap year
int yearToCheck = 2024;
bool isLeapYear = Calendar.IsLeapYear(yearToCheck);
Console.WriteLine($"{yearToCheck} is a leap year: {isLeapYear}");
// Output: 2024 is a leap year: True

```

### GetDayOfWeek

```csharp
// Get the name of the day of the week from its number
int dayOfWeekNumber = 3; // Thursday (0: Sunday, 1: Monday, ..., 6: Saturday)
string dayOfWeekName = Calendar.GetDayOfWeek(dayOfWeekNumber);
Console.WriteLine($"Day of the week: {dayOfWeekName}");
// Output: Day of the week: Wednesday
```


### GetEnglishMonth

```csharp
// Get the name of the English month for the provided month number
int monthNumber = 5;
string monthName = Calendar.GetEnglishMonth(monthNumber);
Console.WriteLine($"Month: {monthName}");
// Output: Month: May
```





### GetNepaliMonthInNepaliFont

```csharp
// Get the name of the Nepali month in Nepali font for the provided month number
int nepaliMonthNumber = 1;
string nepaliMonthName = Calendar.GetNepaliMonthInNepaliFont(nepaliMonthNumber);
Console.WriteLine($"Nepali Month: {nepaliMonthName}");
// Output: Nepali Month: बैशाख
```

### ValidEnglishDate


```csharp
// Validate an English date
int year = 2023, month = 2, day = 29; // Invalid for non-leap years
bool isValid = Calendar.ValidEnglishDate(year, month, day);
Console.WriteLine($"Date {year}-{month}-{day} is valid: {isValid}");
// Output: Date 2023-2-29 is valid: False
```

### ValidNepaliDate

```csharp
// Validate a Nepali date
int nepaliYear = 2079, nepaliMonth = 1, nepaliDay = 32; // Invalid date
bool isValidNepaliDate = Calendar.ValidNepaliDate(nepaliYear, nepaliMonth, nepaliDay);
Console.WriteLine($"Nepali Date {nepaliYear}-{nepaliMonth}-{nepaliDay} is valid: {isValidNepaliDate}");
// Output: Nepali Date 2079-1-32 is valid: False
```

## Examples

Additional examples and usage scenarios can be found in the [Examples](#additional-examples) section of this README.

## License

This project is licensed under the MIT License - see the LICENSE file for details.



## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
