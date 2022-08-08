using System;

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

        public override string ToString()
        {
            if (this is null)
            {
                return $"null";
            }

            return $"({this.From};{this.To})";
        }

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

            return new Range[] { new Range(this.From, this.To), new Range(range.From, range.To) };
        }

        public Range[] GetDifference(Range range)
        {
            if (this.From < range.To && this.To > range.From)
            {
                if (this.From >= range.From && this.To <= range.To)
                {
                    return new Range[] { };
                }

                if (this.From < range.From && this.To <= range.To)
                {
                    return new Range[] { new Range(this.From, range.From) };
                }

                if (this.From >= range.From && this.To > range.To)
                {
                    return new Range[] { new Range(range.To, this.To) };
                }

                if (this.From < range.From && this.To > range.To)
                {
                    return new Range[] { new Range(this.From, range.From), new Range(range.To, this.To) };
                }
            }

            return new Range[] { new Range(this.From, this.To), new Range(range.From, range.To) };
        }
    }
}