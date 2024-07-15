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
using System.Text;

namespace DateConverterNepali
{
    public class FiscalYear
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public int DateType { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "{0} must be at least {2} characters and at max {1} characters long", MinimumLength = 1)]
        public string Year { get; set; }
        [Required]
        public int FromMonth { get; set; }
        [Required]
        public int ToMonth { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime? StartDateAD { get; set; }
        public DateTime? EndDateAD { get; set; }
    }
    public static class FiscalYearProvider
    {
        public static List<FiscalYear> GetFiscalYears()
        {
            List<FiscalYear> fiscalYears = new List<FiscalYear>
            {
                new FiscalYear
                {
                    Id = 1,
                    DateType = 2,
                    Year = "2066/67",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2066/04/01",
                    EndDate = "2067/03/32",
                    StartDateAD = new DateTime(2009, 7, 16),
                    EndDateAD = new DateTime(2010, 7, 16)
                },
                new FiscalYear
                {
                    Id = 2,
                    DateType = 2,
                    Year = "2067/68",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2067/04/01",
                    EndDate = "2068/03/32",
                    StartDateAD = new DateTime(2010, 7, 17),
                    EndDateAD = new DateTime(2011, 7, 16)
                },
                new FiscalYear
                {
                    Id = 3,
                    DateType = 2,
                    Year = "2068/69",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2068/04/01",
                    EndDate = "2069/03/31",
                    StartDateAD = new DateTime(2011, 7, 17),
                    EndDateAD = new DateTime(2012, 7, 15)
                },
                new FiscalYear
                {
                    Id = 4,
                    DateType = 2,
                    Year = "2069/70",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2069/04/01",
                    EndDate = "2070/03/31",
                    StartDateAD = new DateTime(2012, 7, 16),
                    EndDateAD = new DateTime(2013, 7, 15)
                },
                new FiscalYear
                {
                    Id = 5,
                    DateType = 2,
                    Year = "2070/71",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2070/04/01",
                    EndDate = "2071/03/32",
                    StartDateAD = new DateTime(2013, 7, 16),
                    EndDateAD = new DateTime(2014, 7, 16)
                },
                new FiscalYear
                {
                    Id = 6,
                    DateType = 2,
                    Year = "2071/72",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2071/04/01",
                    EndDate = "2072/03/31",
                    StartDateAD = new DateTime(2014, 7, 16),
                    EndDateAD = new DateTime(2015, 7, 16)
                },
                new FiscalYear
                {
                    Id = 7,
                    DateType = 2,
                    Year = "2072/73",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2072/04/01",
                    EndDate = "2073/03/31",
                    StartDateAD = new DateTime(2015, 7, 16),
                    EndDateAD = new DateTime(2016, 7, 16)
                },
                new FiscalYear
                {
                    Id = 8,
                    DateType = 2,
                    Year = "2073/74",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2073/04/01",
                    EndDate = "2074/03/31",
                    StartDateAD = new DateTime(2016, 7, 16),
                    EndDateAD = new DateTime(2017, 7, 16)
                },
                new FiscalYear
                {
                    Id = 9,
                    DateType = 2,
                    Year = "2074/75",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2074/04/01",
                    EndDate = "2075/03/32",
                    StartDateAD = new DateTime(2017, 7, 16),
                    EndDateAD = new DateTime(2018, 7, 16)
                },
                new FiscalYear
                {
                    Id = 10,
                    DateType = 2,
                    Year = "2075/76",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2075/04/01",
                    EndDate = "2076/03/31",
                    StartDateAD = new DateTime(2018, 7, 17),
                    EndDateAD = new DateTime(2019, 7, 16)
                },
                new FiscalYear
                {
                    Id = 11,
                    DateType = 2,
                    Year = "2076/77",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2076/04/01",
                    EndDate = "2077/03/31",
                    StartDateAD = new DateTime(2019, 7, 17),
                    EndDateAD = new DateTime(2020, 7, 15)
                },
                new FiscalYear
                {
                    Id = 12,
                    DateType = 2,
                    Year = "2077/78",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2077/04/01",
                    EndDate = "2078/03/31",
                    StartDateAD = new DateTime(2020, 7, 16),
                    EndDateAD = new DateTime(2021, 7, 15)
                },
                new FiscalYear
                {
                    Id = 13,
                    DateType = 2,
                    Year = "2078/79",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2078/04/01",
                    EndDate = "2079/03/32",
                    StartDateAD = new DateTime(2021, 7, 16),
                    EndDateAD = new DateTime(2022, 7, 16)
                },
                new FiscalYear
                {
                    Id = 14,
                    DateType = 2,
                    Year = "2079/80",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2079/04/01",
                    EndDate = "2080/03/31",
                    StartDateAD = new DateTime(2022, 7, 17),
                    EndDateAD = new DateTime(2023, 7, 16)
                },
                new FiscalYear
                {
                    Id = 15,
                    DateType = 2,
                    Year = "2080/81",
                    FromMonth = 4,
                    ToMonth = 3,
                    StartDate = "2080/04/01",
                    EndDate = "2081/03/31",
                    StartDateAD = new DateTime(2023, 7, 17),
                    EndDateAD = new DateTime(2024, 7, 15)
                }
            };

            return fiscalYears;

        }
    }
}

