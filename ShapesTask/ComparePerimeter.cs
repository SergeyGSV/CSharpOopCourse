using System;
using System.Collections.Generic;

namespace Academits.Gudkov.ShapesTask
{
    class ComparePerimeter : IComparer<IShapes>
    {
        public int Compare(IShapes x, IShapes y)
        {
            if (x.GetPerimeter() > y.GetPerimeter())
                return 1;
            if (x.GetPerimeter() < y.GetPerimeter())
                return -1;
            else
                return 0;

            throw new NotImplementedException();
        }
    }
}