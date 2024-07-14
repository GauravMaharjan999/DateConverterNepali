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
    public class MonthAD
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string MonthCode { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
      
    }
    //public static class MonthADProvider
    //{
    //    public static List<MonthAD> GetMonths()
    //    {
    //        List<MonthAD> months = new List<MonthAD>
    //        {
    //            new MonthAD { Id = 1, MonthCode = "1", Name = "January" },
    //            new MonthAD { Id = 2, MonthCode = "2", Name = "February" },
    //            new MonthAD { Id = 3, MonthCode = "3", Name = "March" },
    //            new MonthAD { Id = 4, MonthCode = "4", Name = "April" },
    //            new MonthAD { Id = 5, MonthCode = "5", Name = "May" },
    //            new MonthAD { Id = 6, MonthCode = "6", Name = "June" },
    //            new MonthAD { Id = 7, MonthCode = "7", Name = "July" },
    //            new MonthAD { Id = 8, MonthCode = "8", Name = "August" },
    //            new MonthAD { Id = 9, MonthCode = "9", Name = "September" },
    //            new MonthAD { Id = 10, MonthCode = "10", Name = "October" },
    //            new MonthAD { Id = 11, MonthCode = "11", Name = "November" },
    //            new MonthAD { Id = 12, MonthCode = "12", Name = "December" }
    //        };

    //        return months;
    //    }
    //}
}

