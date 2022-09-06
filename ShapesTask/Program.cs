using System;
using Academits.Gudkov.ShapesTask.Comparer;
using Academits.Gudkov.ShapesTask.Shapes;

namespace Academits.Gudkov.ShapesTask
{
    internal class Program
    {
        public static IShape GetMaxAreaShape(IShape[] shapes)
        {
            if (shapes.Length == 0)
            {
                throw new ArgumentException("Массив не может быть пуст");
            }

            Array.Sort(shapes, new AreaComparer());

            return shapes[^1];
        }

        public static IShape GetSecondMaxPerimeterShape(IShape[] shapes)
        {
            if (shapes.Length < 2)
            {
                throw new ArgumentException("Массив должен содержать минимум две фигуры");
            }

            Array.Sort(shapes, new PerimeterComparer());

            return shapes[^2];
        }

        public static bool IsEqualHashCode(IShape shape1, IShape shape2)
        {
            return shape1.GetHashCode() == shape2.GetHashCode();
        }

        static void Main()
        {
            IShape[] shapes =
            {
                new Triangle(122, 79, 100, 89, 90, 115),
                new Triangle(34, 9, 17, 14, 17, 95),
                new Triangle(17, 14, 34, 9, 17, 95),
                new Triangle(17, 14, 34, 9, 17, 95.00000000000001),
                new Triangle(0, 0, 0, 0, 0, 0),
                new Circle(18.24),
                new Circle(17.15),
                new Circle(0),
                new Rectangle(12, 16),
                new Rectangle(16, 12),
                new Rectangle(0, 0),
                new Square(15),
                new Square(12),
                new Square(0)
            };

            for (int i = 0; i < shapes.Length - 1; ++i)
            {
                Console.WriteLine("(Equals/HashCode): {0,5} / {1,5} | {2} / {3}", shapes[i].Equals(shapes[i + 1]), IsEqualHashCode(shapes[i], shapes[i + 1]), shapes[i], shapes[i + 1]);
            }

            Console.WriteLine();
            IShape maxAreaShape = GetMaxAreaShape(shapes);

            Console.WriteLine($"Максимальная площадь фигуры в массиве: {maxAreaShape} / {maxAreaShape.GetArea()}");
            Console.WriteLine();

            foreach (IShape shape in shapes)
            {
                Console.WriteLine("{0,10:f2} | {1,10}", shape.GetArea(), shape);
            }

            Console.WriteLine();
            IShape secondMaxPerimeterShape = GetSecondMaxPerimeterShape(shapes);

            Console.WriteLine($"Второй по величине периметр в массиве: {secondMaxPerimeterShape} / {secondMaxPerimeterShape.GetPerimeter()}");
            Console.WriteLine();

            foreach (IShape shape in shapes)
            {
                Console.WriteLine("{0,10:f2} | {1,10}", shape.GetPerimeter(), shape);
            }
        }
    }
}