using System;
using System.Collections.Generic;

namespace Academits.Gudkov.ShapesTask
{
    class CompareArea : IComparer<IShapes>
    {
        public int Compare(IShapes x, IShapes y)
        {
            if (x.GetArea() > y.GetArea())
                return 1;
            if (x.GetArea() < y.GetArea())
                return -1;
            else
                return 0;

            throw new NotImplementedException();
        }
    }
}