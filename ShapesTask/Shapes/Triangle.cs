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
            double[] arrayPointsX = new double[] { X1, X2, X3 };

            return arrayPointsX.Max() - arrayPointsX.Min();
        }

        public double GetHeight()
        {
            double[] arrayPointsY = new double[] { Y1, Y2, Y3 };

            return arrayPointsY.Max() - arrayPointsY.Min();
        }

        private double[] GetSidesLength()
        {
            double ab = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            double ac = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));
            double bc = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));

            return new double[] { ab, ac, bc };
        }

        public double GetPerimeter()
        {
            double[] sidesLength = GetSidesLength();

            return sidesLength[0] + sidesLength[1] + sidesLength[2];
        }

        public double GetArea()
        {
            double[] sidesLength = GetSidesLength();
            double halfPerimeter = (sidesLength[0] + sidesLength[1] + sidesLength[2]) / 2;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - sidesLength[0]) * (halfPerimeter - sidesLength[1]) * (halfPerimeter - sidesLength[2]));
        }

        public override string ToString()
        {
            return $"Треугольник: ({X1}; {Y1}), ({X2}; {Y2}), ({X3}; {Y3})";
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

            Triangle p = (Triangle)obj;

            return X1 == p.X1 && Y1 == p.Y1 && X2 == p.X2 && Y2 == p.Y2 && X3 == p.X3 && Y3 == p.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 17;

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