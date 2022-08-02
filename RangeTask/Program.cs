using System;

namespace Academits.Gudkov
{
    namespace RangeTask1
    {
        internal class Program
        {
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
            }
        }
    }
}