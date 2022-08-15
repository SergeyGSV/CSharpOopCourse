using System;
using System.Linq;

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
                statusCode = true;
            }
        }

        public string GetStatus()
        {
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

        public double GetPerimeter()
        {
            return perimeter;
        }

        public double GetArea()
        {
            return area;
        }
    }
}