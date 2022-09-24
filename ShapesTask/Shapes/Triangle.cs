using System;
using System.Linq;

namespace Academits.Gudkov.ShapesTask.Shapes
{
    public class Triangle : IShape
    {
        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        public double X3 { get; set; }

        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            double[] pointsXArray = new double[] { X1, X2, X3 };

            return pointsXArray.Max() - pointsXArray.Min();
        }

        public double GetHeight()
        {
            double[] pointsYArray = new double[] { Y1, Y2, Y3 };

            return pointsYArray.Max() - pointsYArray.Min();
        }

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double GetPerimeter()
        {
            return GetSideLength(X1, Y1, X2, Y2) + GetSideLength(X1, Y1, X3, Y3) + GetSideLength(X2, Y2, X3, Y3);
        }

        public double GetArea()
        {
            double sideLength1 = GetSideLength(X1, Y1, X2, Y2);
            double sideLength2 = GetSideLength(X1, Y1, X3, Y3);
            double sideLength3 = GetSideLength(X2, Y2, X3, Y3);

            double halfPerimeter = (sideLength1 + sideLength2 + sideLength3) / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - sideLength1) * (halfPerimeter - sideLength2) * (halfPerimeter - sideLength3));
        }

        public override string ToString()
        {
            return $"Треугольник: координаты ({X1}; {Y1}), ({X2}; {Y2}), ({X3}; {Y3}).";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return X1 == triangle.X1 && Y1 == triangle.Y1 && X2 == triangle.X2 && Y2 == triangle.Y2 && X3 == triangle.X3 && Y3 == triangle.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}