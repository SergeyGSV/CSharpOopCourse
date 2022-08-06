using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Gudkov
{
    namespace ShapesTask
    {
        public interface IShapes
        {
            double GetWidth();
            double GetHeight();
            double GetArea();
            double GetPerimeter();
        }

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        public class Triangle : IShapes
        {
            public Point[] Points { get; set; }

            public Triangle(Point[] points)
            {
                Points = points;
            }
            public double GetWidth()
            {
                return 1;
            }
            public double GetHeight()
            {
                return 2;
            }
            public double GetArea()
            {
                // double halfPerimeter = (ab + ac + bc) / 2;
                // double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - ab) * (halfPerimeter - ac) * (halfPerimeter - bc));

                double halfPerimeter = (this.GetSides()[0] + this.GetSides()[1] + this.GetSides()[2]) / 2;

                double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - this.GetSides()[0]) * (halfPerimeter - this.GetSides()[1]) * (halfPerimeter - this.GetSides()[2]));

                return triangleArea;
            }
            private double[] GetSides()
            {
                double ab = Math.Sqrt(Math.Pow(Points[1].X - Points[0].X, 2) + Math.Pow(Points[1].Y - Points[0].Y, 2));
                double ac = Math.Sqrt(Math.Pow(Points[2].X - Points[0].X, 2) + Math.Pow(Points[2].Y - Points[0].Y, 2));
                double bc = Math.Sqrt(Math.Pow(Points[2].X - Points[1].X, 2) + Math.Pow(Points[2].Y - Points[1].Y, 2));

                return new double[] { ab, ac, bc };
            }
            public double GetPerimeter()
            {
                return this.GetSides()[0] + this.GetSides()[1] + this.GetSides()[2];
            }
        }
    }
}