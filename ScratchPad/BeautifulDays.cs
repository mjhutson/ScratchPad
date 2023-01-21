using System;
using System.Linq;

namespace ScratchPad
{
    public class BeautifulDays
    {
        public int beautifulDays(int startIndex, int endIndex, int divisor)
        {
            var beautifulDays = 0;

            for (var day = startIndex; day <= endIndex; day++)
            {
                var dayValue = GetDayValue(day, ReversedDay(day), divisor);

                if (CheckIfDayIsBeautiful(dayValue))
                {
                    beautifulDays++;
                }
            }
            return beautifulDays;
        }

        private int ReversedDay(int day)
        {
            char[] dayString = day.ToString().ToCharArray();
            Console.WriteLine($"Original: {day}");
            var reversed = dayString.Reverse().ToArray();
            string reversedDayString = new string(reversed);
            Console.WriteLine($"Reversed: {reversedDayString}");

            return int.Parse(reversedDayString);
        }

        private double GetDayValue(int day, int reversedDay, int divisor)
        {

            Console.WriteLine($"Day: {day}");
            Console.WriteLine($"Reversed Day: {reversedDay}");
            double dayValue = ((double)day - (double)reversedDay) / (double)divisor;

            return dayValue;
        }

        private bool CheckIfDayIsBeautiful(double dayValue)
        {
            Console.WriteLine($"Day Value: {dayValue}");
            var result = dayValue % 1.0;
            if ( result == 0)
            {
                Console.WriteLine($"Day Value Mod 1 {result}");
                return true;
            }
            return false;
        }
    }
}
