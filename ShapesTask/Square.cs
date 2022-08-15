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