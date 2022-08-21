using System;

namespace Academits.Gudkov.ShapesTask
{
    public class Circle : IShapes
    {
        private double width;
        private double height;
        private double perimeter;
        private double area;
        private string status;
        private bool statusCode = false;

        public Circle(double circleRadius)
        {
            ArgumentsCheck(circleRadius);

            if (statusCode is true)
            {
                width = circleRadius * 2;
                height = width;
                perimeter = 2 * Math.PI * circleRadius;
                area = Math.PI * Math.Pow(circleRadius, 2);
            }
        }

        void ArgumentsCheck(double circleRadius)
        {
            if (circleRadius <= 0)
            {
                status = $"Радиус окружности должен быть больше нуля, переданный фактически: {circleRadius}";
                statusCode = false;
            }
            else
            {
                status = $"{GetType().Name}";
                statusCode = true;
            }
        }

        public string GetStatus()
        {
            return $"statusCode: {statusCode}, status: {status}";
        }

        public double GetWidth()
        {
            return width * 2;
        }

        public double GetHeight()
        {
            return height * 2;
        }

        public double GetPerimeter()
        {
            return perimeter;
        }

        public double GetArea()
        {
            return area;
        }

        public override string ToString()
        {
            return $"Тип: {GetType().Name} {Environment.NewLine}" +
                   $"Ширина: {GetWidth()} {Environment.NewLine}" +
                   $"Высота: {GetHeight()} {Environment.NewLine}" +
                   $"Периметр: {GetPerimeter():f2} {Environment.NewLine}" +
                   $"Площадь: {GetArea():f2} {Environment.NewLine}";
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

            return width == p.width && height == p.height && perimeter == p.perimeter && area == p.area;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 17;
            hash = prime * hash + height.GetHashCode();
            hash = prime * hash + GetType().GetHashCode();

            return hash;
        }
    }
}