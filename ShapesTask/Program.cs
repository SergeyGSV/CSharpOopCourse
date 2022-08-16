using System;

namespace Academits.Gudkov.ShapesTask
{
    internal class Program
    {
        public static IShapes GetMaxShapeArea(IShapes[] shapes)
        {
            Array.Sort(shapes);

            return shapes[shapes.Length - 1];
        }

        static void Main()
        {
            // Курсовая 1. Задача 1. Часть 1
            IShapes triangle1 = new Triangle(new Point[] { new Point(122, 79), new Point(100, 89), new Point(90, 115) });
            IShapes triangle2 = new Triangle(new Point[] { new Point(95, 83), new Point(107, 70), new Point(98, 100) });
            IShapes triangle3 = new Triangle(new Point[] { new Point(34, 9), new Point(17, 14), new Point(17, 95) });

            IShapes circle1 = new Circle(18.24);
            IShapes circle2 = new Circle(15.17);
            IShapes circle3 = new Circle(10.56);

            IShapes rectangle1 = new Rectangle(12.04, 16.0);
            IShapes rectangle2 = new Rectangle(15.20, 10.0);
            IShapes rectangle3 = new Rectangle(17.35, 21.82);

            IShapes sguare1 = new Square(15);
            IShapes sguare2 = new Square(12);
            IShapes sguare3 = new Square(20);

            IShapes[] shapes = new IShapes[] { triangle1, triangle2, triangle3, circle1, circle2, circle3, rectangle1, rectangle2, rectangle3, sguare1, sguare2, sguare3 };

            Console.WriteLine("Максимальная площадь фигуры в массиве равна: {0:f2}", GetMaxShapeArea(shapes).GetArea());
            Console.WriteLine();

            foreach (IShapes shape in shapes)
            {
                Console.WriteLine("{0,10}  | {1:f2}", shape.GetType().Name, shape.GetArea());
            }

            /*
            Point[] point2 = new Point[2];
            IShapes triangle2 = new Triangle(point2);
            */
        }
    }
}