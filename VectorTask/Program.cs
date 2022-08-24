using System;

namespace Academits.Gudkov.VectorTask
{
    internal class Program
    {
        static void Main()
        {
            double[] points1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            Vector vector1 = new Vector(11, points1);
            Vector vector2 = new Vector(15, points1);

            Console.WriteLine(ReferenceEquals(vector1.Points, vector2.Points));

            Console.WriteLine(vector1);
            Console.WriteLine(vector2);

            double[] points2 = new double[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110 };

            vector2 = new Vector(points2);
            Console.WriteLine(vector2);

            Console.WriteLine(vector2.GetPoint(2));

            Console.WriteLine(vector2.GetLenght());

            vector2.SetPoint(2, 14);

            Console.WriteLine(vector2.GetPoint(2));

            Console.WriteLine(vector2.GetLenght());


            Console.WriteLine(vector2);
            vector2.ReverseVector();
            Console.WriteLine(vector2);

            double[] points3 = new double[] { 1, 1, 1, 1, 1, 1, 1 };
            double[] points4 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            vector1 = new Vector(points4);
            vector2 = new Vector(points3);
            Console.WriteLine(ReferenceEquals(vector1.Points, vector2.Points));

            Console.WriteLine(vector1);
            Console.WriteLine(vector2);

            vector1.SubtractVector(vector2);
            //vector1.AddVector(vector2);

            Console.WriteLine(vector1);

            vector1.MultiplyVectorByScalar(-1);

            Console.WriteLine(vector1);

            Console.WriteLine(0 * (-1));


        }
    }
}