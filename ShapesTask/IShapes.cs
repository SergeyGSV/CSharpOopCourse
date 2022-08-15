using System;

namespace Academits.Gudkov.ShapesTask
{
    public interface IShapes : IComparable<IShapes>
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
        string GetStatus();
    }
}