using System;
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

        public double GetLength()
        {
            return To - From;
        }

        public Range GetIntersection(Range range)
        {
            double a1 = this.From;
            double a2 = this.To;
            double b1 = range.From;
            double b2 = range.To;
            Console.WriteLine(a1 + " " + a2 + " " + b1 + " " + b2);

            if (a1 <= b2 && a2 >= b1)
            {
                double x1 = (a1 > b1) ? a1 : b1;
                double x2 = (a2 < b2) ? a2 : b2;
                Range intersectionRange = new Range(x1, x2);


                Console.WriteLine(x1 + " " + x2);
                return intersectionRange;
            }

            return null;
        }

        public Range[] GetUnion(Range range)
        {
            double a1 = this.From;
            double a2 = this.To;
            double b1 = range.From;
            double b2 = range.To;
            Console.WriteLine(a1 + " " + a2 + " " + b1 + " " + b2);

            if (a1 <= b2 && a2 >= b1)
            {
                double x1 = (a1 < b1) ? a1 : b1;
                double x2 = (a2 > b2) ? a2 : b2;
                Range unionRange = new Range(x1, x2);

                Console.WriteLine(x1 + " " + x2);
                return unionRange;
            }

            Range[] unionRangeArray = new Range[] {this, range};
                       
            return unionRangeArray;
        }

        public Range[] GetDifference(Range range)
        {
            double a1 = this.From;
            double a2 = this.To;
            double b1 = range.From;
            double b2 = range.To;
            Console.WriteLine(a1 + " " + a2 + " " + b1 + " " + b2);

            if (a1 <= b2 && a2 >= b1)
            {
                double x1 = (a1 < b1) ? a1 : b1;
                double x2 = (a2 > b2) ? a2 : b2;
                Range unionRange = new Range(x1, x2);

                Console.WriteLine(x1 + " " + x2);
                return unionRange;
            }

            Range[] unionRangeArray = new Range[] { this, range };

            return unionRangeArray;
        }

        private bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public string IsNull(Range range)
        {
            if (range is null)
            {
                return "null";
            }
            else
            {
                return "Новый интервал {From}:{To}";
                //Console.WriteLine($"Новый интервал {range.From}:{range.To}");
            }
        }

        public void PrintObject(string line)
        {
            Console.WriteLine(line);
        }

        public void PrintObject(Range range)
        {
            this.From = From;
            this.To = To;

            if (range is null)
            {
                Console.WriteLine($"null");
            }
            else
            {
                Console.WriteLine($"Новый интервал {From}:{To}");
                //Console.WriteLine($"Новый интервал {range.From}:{range.To}");
            }
        }

    }
}
