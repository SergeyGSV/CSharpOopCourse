using System;

namespace Academits.Gudkov.ShapesTask
{
    public class Rectangle : IShapes
    {
        private double width;
        private double height;
        private double perimeter;
        private double area;
        private string status;
        private bool statusCode = false;

        public Rectangle(double sideLength1, double sideLength2)
        {
            ArgumentsCheck(sideLength1, sideLength1);

            if (statusCode is true)
            {
                width = sideLength1;
                height = sideLength2;
                perimeter = sideLength1 * 2 + sideLength2 * 2;
                area = sideLength1 * sideLength2;
            }
        }

        void ArgumentsCheck(double sideLength1, double sideLength2)
        {
            if (sideLength1 <= 0 || sideLength2 <= 0)
            {
                status = $"Длина каждой стороны должна быть больше нуля, переданные фактически: {sideLength1}, {sideLength2}";
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

        public override string ToString()
        {
            return $"Тип: {GetType().Name} {Environment.NewLine}" +
                   $"Ширина: {GetWidth()} {Environment.NewLine}" +
                   $"Высота: {GetHeight()} {Environment.NewLine}" +
                   $"Периметр: {GetPerimeter():f2} {Environment.NewLine}" +
                   $"Площадь: {GetArea():f2} {Environment.NewLine}";
        }
    }
}