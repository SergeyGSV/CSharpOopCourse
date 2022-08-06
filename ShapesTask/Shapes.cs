using System;
using System.Linq;

namespace Academits.Gudkov.ShapesTask
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

        private double[] GetSides()
        {
            double ab = Math.Sqrt(Math.Pow(Points[1].X - Points[0].X, 2) + Math.Pow(Points[1].Y - Points[0].Y, 2));
            double ac = Math.Sqrt(Math.Pow(Points[2].X - Points[0].X, 2) + Math.Pow(Points[2].Y - Points[0].Y, 2));
            double bc = Math.Sqrt(Math.Pow(Points[2].X - Points[1].X, 2) + Math.Pow(Points[2].Y - Points[1].Y, 2));

            return new double[] { ab, ac, bc };
        }

        public double GetWidth()
        {
            double[] xPointsArray = new double[] { this.Points[0].X, this.Points[1].X, this.Points[2].X };

            return xPointsArray.Max() - xPointsArray.Min();
        }

        public double GetHeight()
        {
            double[] yPointsArray = new double[] { this.Points[0].Y, this.Points[1].Y, this.Points[2].Y };

            return yPointsArray.Max() - yPointsArray.Min();
        }

        public double GetArea()
        {
            double[] sidesArray = this.GetSides();
            double halfPerimeter = (sidesArray[0] + sidesArray[1] + sidesArray[2]) / 2;
            double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - sidesArray[0]) * (halfPerimeter - sidesArray[1]) * (halfPerimeter - sidesArray[2]));

            return triangleArea;
        }

        public double GetPerimeter()
        {
            double[] sidesArray = this.GetSides();

            return sidesArray[0] + sidesArray[1] + sidesArray[2];
        }
    }
}