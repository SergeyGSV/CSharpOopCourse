using System;

namespace Academits.Gudkov.ShapesTask.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return $"Окружность: {Radius}";
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

            Circle p = (Circle)obj;

            return Radius == p.Radius;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 17;
            hash = prime * hash + Radius.GetHashCode();

            return hash;
        }
    }
}