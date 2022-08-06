using System;

namespace Academits.Gudkov.RangeTask
{
    internal class Program
    {
        private static void Print(Range range)
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

        private static void Print(Range[] range)
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
            // Курсовая 1. Часть 1
            Console.Write("Укажите начало диапазона: ");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.Write("Укажите конец диапазона: ");
            double to = Convert.ToDouble(Console.ReadLine());

            Range range = new Range(from, to);

            Console.WriteLine($"Длина указанного диапазона = {range.GetLength()}");

            Console.Write("Укажите число для проверки: ");

            if (range.IsInside(Convert.ToDouble(Console.ReadLine())))
            {
                Console.WriteLine("Число лежит в указанном диапазоне");
            }
            else
            {
                Console.WriteLine("Число лежит за пределами указанного диапазона");
            }

            range.From = 12;
            range.To = 100;

            Console.WriteLine($"Установлены новые значения диапазона: From = {range.From}, To = {range.To}");

            // Task 2
            // Курсовая 1. Часть 2
            while (true)
            {
                Console.WriteLine("Укажите границы диапазонов");
                Console.WriteLine();

                Console.Write("Начало первого диапазона: ");
                double rangeFrom = Convert.ToDouble(Console.ReadLine());

                Console.Write("Конец первого диапазона: ");
                double rangeTo = Convert.ToDouble(Console.ReadLine());
                Range range1 = new Range(rangeFrom, rangeTo);
                Console.WriteLine();


                Console.Write("Начало второго диапазона: ");
                rangeFrom = Convert.ToDouble(Console.ReadLine());

                Console.Write("Конец второго диапазона: ");
                rangeTo = Convert.ToDouble(Console.ReadLine());
                Range range2 = new Range(rangeFrom, rangeTo);
                Console.WriteLine();

                Console.WriteLine("Результат пересечения");
                Print(range1.GetIntersection(range2));
                Console.WriteLine();

                Console.WriteLine("Результат объединения");
                Print(range1.GetUnion(range2));
                Console.WriteLine();

                Console.WriteLine("Результат разности");
                Print(range1.GetDifference(range2));
                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
}