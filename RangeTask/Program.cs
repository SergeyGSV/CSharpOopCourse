using System;
using System.Text;

namespace Academits.Gudkov.RangeTask
{
    internal class Program
    {
        private static void Print(Range range)
        {
            if (range is null)
            {
                Console.WriteLine($"[]");
            }
            else
            {
                Console.Write($"[{range}]");
            }
        }

        private static void Print(Range[] ranges)
        {
            if (ranges.Length == 0 || ranges[0] is null)
            {
                Console.WriteLine($"[]");
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (Range range in ranges)
                {
                    stringBuilder.Append(range.ToString()).Append(", ");
                }

                string line = stringBuilder.Remove(stringBuilder.Length - 2, 2).ToString();

                Console.Write($"[{line}]");
                Console.WriteLine();
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
                Console.WriteLine(range1.GetIntersection(range2));

                Console.WriteLine("Результат объединения");
                Print(range1.GetUnion(range2));
                Console.WriteLine();

                Console.WriteLine("Результат разности");
                Print(range1.GetDifference(range2));
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}

/*
       Range range1 = new Range(1, 10);
       Range range2 = new Range(2, 8);

       Console.WriteLine("Результат пересечения");
       //Console.WriteLine(range1.GetIntersection(range2));
       Print(range1.GetIntersection(range2));
       Console.WriteLine();

       Console.WriteLine("Результат объединения");
       Print(range1.GetUnion(range2));
       Console.WriteLine();

       Console.WriteLine("Результат разности");
       Print(range1.GetDifference(range2));

       Range range3 = new Range(1, 10);
       Range range4 = new Range(1, 10);

       Console.WriteLine("Результат разности");
       Print(range3.GetDifference(range4));

       Range range5 = new Range(10, 20);
       Range range6 = new Range(11, 21);

       Console.WriteLine("Результат разности");
       Print(range5.GetDifference(range6));
       */