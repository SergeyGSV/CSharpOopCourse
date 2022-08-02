using System;

namespace Academits.Gudkov
{
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
                    Console.WriteLine($"Интервал {range.From}:{range.To}");
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
                    Console.WriteLine($"Интервал {range[0].From}:{range[0].To}");
                }
                else
                {
                    Console.WriteLine($"Интервалы {range[0].From}:{range[0].To} и {range[1].From}:{range[1].To}");
                }
            }

            static void Main()
            {
                // Курсовая 1. Часть 2
                Range range1 = new Range();
                Range range2 = new Range();

                while (true)
                {
                    Console.WriteLine("Укажите границы диапазонов");
                    Console.WriteLine();

                    Console.Write("Начало первого диапазона: ");
                    range1.From = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Конец первого диапазона: ");
                    range1.To = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Начало второго диапазона: ");
                    range2.From = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Конец второго диапазона: ");
                    range2.To = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();

                    Console.WriteLine("Результат пересечения");
                    PrintObject(range1.GetIntersection(range2));
                    Console.WriteLine();

                    Console.WriteLine("Результат объединения");
                    PrintObject(range1.GetUnion(range2));
                    Console.WriteLine();

                    Console.WriteLine("Результат разности");
                    PrintObject(range1.GetDifference(range2));
                    Console.WriteLine("------------------------------------------------------");
                }
            }
        }
    }
}