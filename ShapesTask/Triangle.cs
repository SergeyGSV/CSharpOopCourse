using System;
using System.Linq;

namespace Academits.Gudkov.ShapesTask
{
    public class Triangle : IShapes
    {
        private Point[] trianglePoints;
        private double[] triangleSides;
        private double width;
        private double height;
        private double area;
        private double perimeter;
        private string status;
        private bool statusCode = false;

        public Triangle(Point[] points)
        {
            ArgumentsCheck(points);

            if (statusCode is true)
            {
                trianglePoints = points;
                width = CalcWidth();
                height = CalcHeight();
                triangleSides = CalcSides();
                perimeter = CalcPerimeter();
                area = CalcArea();
            }
        }

        void ArgumentsCheck(Point[] points)
        {
            double epsilon = 1e-10;

            if (points.Length != 3)
            {
                status = $"Задано неверное количество вершин, требуется 3, фактически {points.Length}";
                statusCode = false;
                //Console.WriteLine($"Задано неверное количество вершин, требуется 3, фактически {points.Length}");
            }
            else if (points == null || points[0] == null || points[1] == null || points[2] == null)
            {
                status = $"Координаты вершин треугольника не заданы! (null)";
                statusCode = false;
                //Console.WriteLine($"Координаты вершин треугольника не заданы!");
            }
            else if (Math.Abs((points[2].X - points[0].X) * (points[1].Y - points[0].Y) - (points[1].X - points[0].X) * (points[2].Y - points[0].Y)) <= epsilon)
            {
                status = $"Координаты вершин треугольника лежат на одной прямой!";
                statusCode = false;
                //Console.WriteLine($"Координаты вершин треугольника лежат на одной прямой!");
            }
            else
            {
                statusCode = true;
            }
        }

        double CalcWidth()
        {
            double[] xPointsArray = new double[] { trianglePoints[0].X, trianglePoints[1].X, trianglePoints[2].X };

            return xPointsArray.Max() - xPointsArray.Min();
        }

        double CalcHeight()
        {
            double[] yPointsArray = new double[] { trianglePoints[0].Y, trianglePoints[1].Y, trianglePoints[2].Y };

            return yPointsArray.Max() - yPointsArray.Min();
        }

        double[] CalcSides()
        {
            double ab = Math.Sqrt(Math.Pow(trianglePoints[1].X - trianglePoints[0].X, 2) + Math.Pow(trianglePoints[1].Y - trianglePoints[0].Y, 2));
            double ac = Math.Sqrt(Math.Pow(trianglePoints[2].X - trianglePoints[0].X, 2) + Math.Pow(trianglePoints[2].Y - trianglePoints[0].Y, 2));
            double bc = Math.Sqrt(Math.Pow(trianglePoints[2].X - trianglePoints[1].X, 2) + Math.Pow(trianglePoints[2].Y - trianglePoints[1].Y, 2));

            return new double[] { ab, ac, bc };
        }

        double CalcPerimeter()
        {
            return triangleSides[0] + triangleSides[1] + triangleSides[2];
        }

        double CalcArea()
        {
            double halfPerimeter = (triangleSides[0] + triangleSides[1] + triangleSides[2]) / 2;
            double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - triangleSides[0]) * (halfPerimeter - triangleSides[1]) * (halfPerimeter - triangleSides[2]));

            return triangleArea;
        }

        public string GetStatus()
        {
            //Console.WriteLine($"statusCode: {statusCode}, status: {status}");
            return $"statusCode: {statusCode}, status: {status}";
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetArea()
        {
            return area;
        }

        public double GetPerimeter()
        {
            return perimeter;
        }
    }
}