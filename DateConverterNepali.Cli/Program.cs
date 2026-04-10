using System;
using DateConverterNepali;

namespace DateConverterNepali.Cli
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var converted = DateConverter.GetDateInAD(2083, 8, 30);

            if (converted.engYear == 0)
            {
                Console.WriteLine("2083-08-30 is invalid in the current DateArray table.");
                return;
            }

            Console.WriteLine($"2083-08-30 -> {converted.getFormattedDate():yyyy-MM-dd}");
        }
    }
}