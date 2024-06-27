# DateConverterNepali
DateConverterNepali is a .NET library for converting dates between the Nepali (Bikram Sambat) calendar and the Gregorian calendar. It provides various utility methods for handling dates and times specific to the Nepali context.

## Installation

Install the package via NuGet:

```powershell```
Install-Package DateConverterNepali

#Usage

## Features
* Convert dates between Nepali (Bikram Sambat) and Gregorian calendars.
* Calculate time duration between two time spans.
* Retrieve month names by their Nepali month IDs.
* Fetch fiscal year details.
* Perform date operations specific to Nepali dates.

## Dependencies

## Customization and Support
For other customization feel free to contact me

## Email: gauravmaharjan000@gmail.com
LinkedIn: Gaurav Maharjan
License
This project is licensed under the MIT License.

## Sample code
``` C Sharp 

using static DateConverterNepali.DateConverter;  // Import the static class members


Console.WriteLine(GetDateInBS(DateTime.Now));  //convert AD to BS


// Get the equivalent date in Anno Domini (AD) format
Console.WriteLine(GetDateInAD("2081/03/31")); //convert BS to AD
Console.WriteLine(GetFiscalYear(DateTime.Now, DateConverterNepali.OprDateType.Nepali));
var yearList = GetYearListAd().ToList();

// Log the list to the console
Console.WriteLine("List of Years in AD:");
foreach (var year in yearList)
{
    Console.WriteLine(year);
}
```
This `README.md` file provides a comprehensive guide on how to install, configure, and use the Nepali Date Converter package, including example code for integrating the service into an ASP.NET Core application.

