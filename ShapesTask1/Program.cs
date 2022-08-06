using System;

namespace Academits.Gudkov
{
    namespace ShapesTask
    {
        internal class Program
        {
            static void Main()
            {
                // Курсовая 1. Задача 1. Часть 1

                IShapes triangle = new Triangle(new Point[] { new Point(2, 4), new Point(1, 5), new Point(12, 41) });

                Console.WriteLine(triangle.GetPerimeter());

                Console.WriteLine(triangle.GetArea());
            }
        }
    }
}