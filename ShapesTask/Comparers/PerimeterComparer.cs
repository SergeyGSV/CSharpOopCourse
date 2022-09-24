using System.Collections.Generic;
using Academits.Gudkov.ShapesTask.Shapes;

namespace Academits.Gudkov.ShapesTask.Comparer
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
        }
    }
}