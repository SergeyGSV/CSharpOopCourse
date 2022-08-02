﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                double x1 = (a1 > b1) ? a1 : b1;
                double x2 = (a2 < b2) ? a2 : b2;

                return new Range(x1, x2);
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
                double x1 = (a1 < b1) ? a1 : b1;
                double x2 = (a2 > b2) ? a2 : b2;

                return new Range[] { new Range(x1, x2) };
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

        public void PrintObject(Range range)
        {
            if (range is null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine($"Значение интервала {From}:{To}");
            }
        }
    }
}