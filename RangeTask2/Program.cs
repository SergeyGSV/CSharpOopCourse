using System;

namespace RangeTask2
{
    internal class Program
    {

        static void Main()
        {
            // Курсовая 1. Часть 2

            Range range1 = new (21, 24);

            Range range2 = new (25, 34);

            Range intersectionRange = new ();

            intersectionRange = range1.GetIntersection(range2);

            PrintObject(intersectionRange);

            //Console.WriteLine(intersectionRange.From);

            Range[] unionRangeArray = new Range[10];

            unionRangeArray = range1.GetUnion(range2);

             
        }
    }
}
