using System;

namespace Academits.Gudkov.ShapesTask
{
    public class Square : IShapes
    {
        private double width;
        private double height;
        private double perimeter;
        private double area;
        private string status;
        private bool statusCode = false;

        public Square(double sideLength)
        {
            ArgumentsCheck(sideLength);

            if (statusCode is true)
            {
                width = sideLength;
                height = sideLength;
                perimeter = sideLength * 4;
                area = sideLength * sideLength;
            }
        }

        void ArgumentsCheck(double sideLength)
        {
            if (sideLength <= 0)
            {
                status = $"Длина должна быть больше нуля, переданная фактически: {sideLength}";
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Square p = (Square)obj;

            return width == p.width && height == p.height && perimeter == p.perimeter && area == p.area;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 17;
            hash = prime * hash + width.GetHashCode();
                        
            return hash;
        }
    }
}