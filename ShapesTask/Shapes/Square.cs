namespace Academits.Gudkov.ShapesTask.Shapes
{
    public class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetPerimeter()
        {
            return 4 * SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public override string ToString()
        {
            return $"Квадрат: ширина {SideLength}.";
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

            Square square = (Square)obj;

            return SideLength == square.SideLength;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 1;
            hash = prime * hash + SideLength.GetHashCode();

            return hash;
        }
    }
}