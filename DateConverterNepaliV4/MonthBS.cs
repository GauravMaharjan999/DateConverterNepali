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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateConverterNepali
{
    /// <summary>
    /// Represents a month in the Bikram Sambat (BS) calendar.
    /// </summary>
    public class MonthBS
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string MonthCode { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string MonthNameLocLang { get; set; }
    }

    /// <summary>
    /// Provides methods to retrieve months in the Bikram Sambat (BS) calendar.
    /// </summary>
    public static class MonthBSProvider
    {
        /// <summary>
        /// Retrieves a list of months in the Bikram Sambat (BS) calendar.
        /// </summary>
        /// <returns>A list of MonthBS objects representing months in the BS calendar.</returns>
        public static List<MonthBS> GetMonths()
        {
            List<MonthBS> months = new List<MonthBS>
            {
                new MonthBS { Id = 1, MonthCode = "01", Name = "Baisakh" },
                new MonthBS { Id = 2, MonthCode = "02", Name = "Jestha" },
                new MonthBS { Id = 3, MonthCode = "03", Name = "Ashad" },
                new MonthBS { Id = 4, MonthCode = "04", Name = "Shrawan" },
                new MonthBS { Id = 5, MonthCode = "05", Name = "Bhadra" },
                new MonthBS { Id = 6, MonthCode = "06", Name = "Ashwin" },
                new MonthBS { Id = 7, MonthCode = "07", Name = "Kartik" },
                new MonthBS { Id = 8, MonthCode = "08", Name = "Mangshir" },
                new MonthBS { Id = 9, MonthCode = "09", Name = "Poush" },
                new MonthBS { Id = 10, MonthCode = "10", Name = "Magh" },
                new MonthBS { Id = 11, MonthCode = "11", Name = "Falgun" },
                new MonthBS { Id = 12, MonthCode = "12", Name = "Chaitra" }
            };
            return months;
        }
    }

    /// <summary>
    /// Provides methods to retrieve Nepali day names.
    /// </summary>
    public static class NepaliDayProvider
    {
        private static readonly string[] NepaliDays =
        {
            "आइतबार", // Sunday
            "सोमबार", // Monday
            "मंगलबार", // Tuesday
            "बुधबार", // Wednesday
            "बिहीबार", // Thursday
            "शुक्रबार", // Friday
            "शनिबार"  // Saturday
        };

        /// <summary>
        /// Retrieves the Nepali day name corresponding to the given day number.
        /// </summary>
        /// <param name="dayNumber">The day number (0 for Sunday, 1 for Monday, etc.).</param>
        /// <returns>The Nepali day name.</returns>
        /// <exception cref="ArgumentException">Thrown if the day number is out of valid range (0-6).</exception>
        public static string GetNepaliFontDayName(int dayNumber)
        {
            if (dayNumber < 0 || dayNumber > 6)
            {
                throw new ArgumentException("Invalid day number. Day number must be between 0 (Sunday) and 6 (Saturday).");
            }
            return NepaliDays[dayNumber];
        }
    }
}

