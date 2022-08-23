namespace Academits.Gudkov.ShapesTask.Shapes
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return $"Прямоугольник: ({Width}, {Height})";
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

            Rectangle p = (Rectangle)obj;

            return Width == p.Width && Height == p.Height;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 17;
            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Height.GetHashCode();

            return hash;
        }
    }
}