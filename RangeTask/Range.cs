using System;
using System.Linq;

namespace Academits.Gudkov.RangeTask
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

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        // Task 2
        public Range GetIntersection(Range range)
        {
            if ((this.From < range.To && this.To > range.From) || (this.From == range.From && this.To == range.To))
            {
                return new Range(Math.Max(this.From, range.From), Math.Min(this.To, range.To));
            }

            return null;
        }

        public Range[] GetUnion(Range range)
        {
            if (this.From <= range.To && this.To >= range.From)
            {
                return new Range[] { new Range(Math.Min(this.From, range.From), Math.Max(this.To, range.To)) };
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
                return new Range[] { };
            }

            return new Range[] { this, range };
        }
    }
}