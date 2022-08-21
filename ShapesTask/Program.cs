using System;

namespace Academits.Gudkov.ShapesTask
{
    internal class Program
    {
        public static IShapes GetMaxArea(IShapes[] shapes)
        {
            Array.Sort(shapes, new CompareArea());

            return shapes[^1];
        }

        public static IShapes GetSecondMaxPerimeter(IShapes[] shapes)
        {
            Array.Sort(shapes, new ComparePerimeter());

            return shapes[^2];
        }

        public static bool CompareHashCode(IShapes shape1, IShapes shape2)
        {
            return shape1.GetHashCode() == shape2.GetHashCode();
        }

        static void Main()
        {
            // Курсовая 1. Задача 1. Часть 1
            IShapes triangle1 = new Triangle(new Point[] { new Point(122, 79), new Point(100, 89), new Point(90, 115) });
            IShapes triangle2 = new Triangle(new Point[] { new Point(34, 9), new Point(17, 14), new Point(17, 95) });
            IShapes triangle3 = new Triangle(new Point[] { new Point(17, 14), new Point(34, 9), new Point(17, 95) });
            IShapes triangle4 = new Triangle(new Point[] { new Point(17.0000000000000000000000000000000001, 14), new Point(34, 9), new Point(17, 95) });
            IShapes triangle5 = new Triangle(new Point[] { new Point(0, 0), new Point(0, 0), new Point(0, 0) });
            IShapes triangle6 = new Triangle(new Point[3]);

            IShapes circle1 = new Circle(18.24);
            IShapes circle2 = new Circle(17.15);
            IShapes circle3 = new Circle(0);


            IShapes rectangle1 = new Rectangle(12, 16);
            IShapes rectangle2 = new Rectangle(16, 12);
            IShapes rectangle3 = new Rectangle(0, 0);

            IShapes sguare1 = new Square(15);
            IShapes sguare2 = new Square(12);
            IShapes sguare3 = new Square(0);

            IShapes[] shapes = new IShapes[] { triangle1, triangle2, triangle3, triangle4, triangle5, triangle6, circle1, circle2, circle3, rectangle1, rectangle2, rectangle3, sguare1, sguare2, sguare3 };

            Console.WriteLine($"Результат сравнения треугольников по Equals: {triangle1.Equals(triangle2)}");
            Console.WriteLine($"Результат сравнения треугольников по Equals: {triangle2.Equals(triangle3)}");
            Console.WriteLine($"Результат сравнения треугольников по Equals: {triangle3.Equals(triangle4)}");
            Console.WriteLine($"Результат сравнения треугольников по Equals: {triangle4.Equals(triangle5)}");
            Console.WriteLine($"Результат сравнения треугольников по Equals: {triangle5.Equals(triangle6)}");

            Console.WriteLine($"Результат сравнения \"нулевых\" окружности и прямоугольника: Equals = {circle3.Equals(rectangle3)}, HashCode = {CompareHashCode(circle3, rectangle3)}");
            Console.WriteLine($"Результат сравнения \"нулевых\" окружности и квадрата по Equals: {circle3.Equals(sguare3)}, HashCode = {CompareHashCode(circle3, sguare3)}");
            Console.WriteLine($"Результат сравнения \"симметричных\" прямоугольников по Equals: {rectangle1.Equals(rectangle2)}, HashCode = {CompareHashCode(rectangle1, rectangle2)}");

            Console.WriteLine();

            foreach (IShapes shape in shapes)
            {
                Console.WriteLine("{0,10}  | {1:f2}", shape.GetType().Name, shape.GetHashCode());
            }

            Console.WriteLine();

            Console.WriteLine($"Максимальная площадь фигуры в массиве = {GetMaxArea(shapes)}");
            Console.WriteLine($"Второй по величине периметр в массиве = {GetSecondMaxPerimeter(shapes)}");

            /*
            foreach (IShapes shape in shapes)
            {
                Console.WriteLine("{0,10}  | {1:f2}", shape.GetType().Name, shape.GetPerimeter());
            }
            */

            Console.WriteLine();


        }
    }
}