using System;

namespace Academits.Gudkov.ShapesTask
{
    internal class Program
    {
        static void Main()
        {
            // Курсовая 1. Задача 1. Часть 1
            IShapes triangle1 = new Triangle(new Point[] { new Point(2, 4), new Point(1, 5), new Point(12, 41) });

            Console.WriteLine(triangle1.GetWidth());

            Console.WriteLine(triangle1.GetHeight());

            Console.WriteLine(triangle1.GetPerimeter());

            Console.WriteLine(triangle1.GetArea());

            Point[] point2 = new Point[3];
            IShapes triangle2 = new Triangle(point2);

            Console.WriteLine(triangle2.GetWidth());

            Console.WriteLine(triangle2.GetHeight());

            Console.WriteLine(triangle2.GetPerimeter());

            Console.WriteLine(triangle2.GetArea());
        }
    }
}