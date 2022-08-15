using System;

namespace Academits.Gudkov.ShapesTask
{
    internal class Program
    {
        static void Main()
        {
            // Курсовая 1. Задача 1. Часть 1
            IShapes triangle1 = new Triangle(new Point[] { new Point(2, 4), new Point(1, 5), new Point(12, 41) });
            IShapes triangle2 = new Triangle(new Point[] { new Point(3, 8), new Point(2, 10), new Point(20, 10) });
            IShapes triangle3 = new Triangle(new Point[] { new Point(20, 9), new Point(6, 14), new Point(17, 5) });
            /*
            Console.WriteLine(triangle1.GetStatus());
            Console.WriteLine(triangle2.GetStatus());
            Console.WriteLine(triangle3.GetStatus());
            */
            IShapes circle1 = new Circle(18.24);
            IShapes circle2 = new Circle(32.17);
            IShapes circle3 = new Circle(10.56);
            /*
            Console.WriteLine(circle1.GetStatus());
            Console.WriteLine(circle2.GetStatus());
            Console.WriteLine(circle3.GetStatus());
            */
            IShapes rectangle1 = new Rectangle(12.04, 16.0);
            IShapes rectangle2 = new Rectangle(15.20, 10.0);
            IShapes rectangle3 = new Rectangle(17.35, 21.82);
            /*
            Console.WriteLine(rectangle1.GetStatus());
            Console.WriteLine(rectangle2.GetStatus());
            Console.WriteLine(rectangle3.GetStatus());
            */
            IShapes sguare1 = new Square(15);
            IShapes sguare2 = new Square(12);
            IShapes sguare3 = new Square(20);
            /*
            Console.WriteLine(sguare1.GetStatus());
            Console.WriteLine(sguare2.GetStatus());
            Console.WriteLine(sguare3.GetStatus());
            */
            IShapes[] shapes = new IShapes[] { triangle1, circle3, rectangle2, sguare1, circle2, circle1, triangle2, triangle3, circle1, sguare2 };

            foreach (IShapes shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name + " " + shape.GetArea());
            }

            Console.WriteLine();
            Console.WriteLine();

            Array.Sort(shapes);

            foreach (IShapes shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name + " " + shape.GetArea());
            }



            /*
            Console.WriteLine(triangle1.GetWidth());
            Console.WriteLine(triangle1.GetHeight());
            Console.WriteLine(triangle1.GetPerimeter());
            Console.WriteLine(triangle1.GetArea());

            Point[] point2 = new Point[2];
            IShapes triangle2 = new Triangle(point2);

            Console.WriteLine(triangle2.GetWidth());
            Console.WriteLine(triangle2.GetHeight());
            Console.WriteLine(triangle2.GetPerimeter());
            Console.WriteLine(triangle2.GetArea());

            Console.WriteLine(triangle1.GetStatus());
            Console.WriteLine(triangle2.GetStatus());
            */
        }
    }
}