using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Gudkov
{
    namespace RangeTask2
    {
        internal class Range
        {
            public double From { get; set; }

            public double To { get; set; }

            public Range(double from, double to)
            {
                From = from;
                To = to;
            }

            public Range()
            {
            }

            public Range GetIntersection(Range range)
            {
                double a1 = this.From;
                double a2 = this.To;
                double b1 = range.From;
                double b2 = range.To;

                if (a1 <= b2 && a2 >= b1)
                {
                    double c1 = (a1 > b1) ? a1 : b1;
                    double c2 = (a2 < b2) ? a2 : b2;

                    return new Range(c1, c2);
                }

                return null;
            }

            public Range[] GetUnion(Range range)
            {
                double a1 = this.From;
                double a2 = this.To;
                double b1 = range.From;
                double b2 = range.To;

                if (a1 <= b2 && a2 >= b1)
                {
                    double c1 = (a1 < b1) ? a1 : b1;
                    double c2 = (a2 > b2) ? a2 : b2;

                    return new Range[] { new Range(c1, c2) };
                }

                return new Range[] { this, range };
            }

            public Range[] GetDifference(Range range)
            {
                double a1 = this.From;
                double a2 = this.To;
                double b1 = range.From;
                double b2 = range.To;

                if (a1 < b2 && a2 > b1)
                {
                    if (a1 < b1)
                    {
                        return new Range[] { new Range(a1, b1) };
                    }

                    if (b2 < a2)
                    {
                        return new Range[] { new Range(b2, a2) };
                    }
                }

                if (a1 == b1 && a2 == b2)
                {
                    return new Range[] { null };
                }

                return new Range[] { this, range };
            }
        }
    }
}