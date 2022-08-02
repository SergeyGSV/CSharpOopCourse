using System;


namespace RangeTask2
{
    internal class Program
    {
        private static void PrintObject(Range range)
        {
            if (range is null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine($"Значение интервала {range.From}:{range.To}");
            }
        }

        private static void PrintObject(Range[] range)
        {
            if (range[0] is null)
            {
                Console.WriteLine("null");
            }
            else if (range.Length == 1)
            {
                Console.WriteLine($"Значение интервала {range[0].From}:{range[0].To}");
            }
            else
            {
                Console.WriteLine($"Значение интервала {range[0].From}:{range[0].To} и {range[1].From}:{range[1].To}");
            }
        }

        static void Main()
        {
            // Курсовая 1. Часть 2

            Range range1 = new(21, 25);

            Range range2 = new(25, 34);

            // Range intersectionRange = new();            
            // intersectionRange = range1.GetIntersection(range2);

            PrintObject(range1.GetIntersection(range2));
            Console.WriteLine();

            PrintObject(range1.GetUnion(range2));
            Console.WriteLine();

            PrintObject(range1.GetDifference(range2));
            Console.WriteLine();
        }
    }
}