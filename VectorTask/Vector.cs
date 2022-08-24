using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academits.Gudkov.VectorTask
{
    public class Vector
    {
        public double[] Points { get; private set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"Недопустимые аргументы: размерность вектора = {n}");
            }

            Points = new double[n];
        }

        public Vector(Vector vector)
        {
            Points = new double[vector.GetSize()];
            double[] sourseVectorPoints = vector.Points;

            for (int i = 0; i < Points.Length; ++i)
            {
                Points[i] = sourseVectorPoints[i];
            }
        }

        public Vector(double[] points)
        {
            if (points is null)
            {
                throw new ArgumentException("Недопустимые аргументы: массив = null");
            }

            if (points.Length == 0)
            {
                throw new ArgumentException($"Недопустимые аргументы: размер массива = 0");
            }

            Points = new double[points.Length];

            for (int i = 0; i < points.Length; ++i)
            {
                Points[i] = points[i];
            }
        }

        public Vector(int n, double[] points)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"Недопустимые аргументы: размерность вектора = {n}");
            }

            if (points is null)
            {
                throw new ArgumentException("Недопустимые аргументы: массив = null");
            }

            if (points.Length == 0)
            {
                throw new ArgumentException($"Недопустимые аргументы: размер массива = 0");
            }

            Points = new double[n];

            for (int i = 0; (i < n && i < points.Length); ++i)
            {
                Points[i] = points[i];
            }
        }

        public int GetSize()
        {
            return Points.Length;
        }

        public override string ToString()
        {
            StringBuilder vectorInfo = new StringBuilder("{");

            foreach (double point in Points)
            {
                vectorInfo.Append(point).Append(", ");
            }

            vectorInfo.Remove(vectorInfo.Length - 2, 2).Append('}');

            return vectorInfo.ToString();
        }
    }
}