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

        private double[] GetSidesLengths()
        {
            double abLength = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            double acLength = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));
            double bcLength = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));

            return new double[] { abLength, acLength, bcLength };
        }

        public double GetPerimeter()
        {
            double[] sidesLengths = GetSidesLengths();

            return sidesLengths[0] + sidesLengths[1] + sidesLengths[2];
        }

        public double GetArea()
        {
            double[] sidesLengths = GetSidesLengths();
            double halfPerimeter = (sidesLengths[0] + sidesLengths[1] + sidesLengths[2]) / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - sidesLengths[0]) * (halfPerimeter - sidesLengths[1]) * (halfPerimeter - sidesLengths[2]));
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