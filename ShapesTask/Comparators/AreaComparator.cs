using System.Collections.Generic;
using Academits.Gudkov.ShapesTask.Shapes;

namespace Academits.Gudkov.ShapesTask.Comparators
{
    class AreaComparator : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetArea() > shape2.GetArea())
            {
                return 1;
            }

            if (shape1.GetArea() < shape2.GetArea())
            {
                return -1;
            }

            return 0;
        }
    }
}