using System;

namespace Academits.Gudkov.VectorTask
{
    internal class Program
    {
        static void Main()
        {
            double[] points = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            Vector vector1 = new Vector(1, points);

            Vector vector2 = new Vector(1, points);

            Console.WriteLine(ReferenceEquals(vector1.Points, vector2.Points));

            Console.WriteLine(vector1);
            Console.WriteLine(vector2);

        }
    }
}