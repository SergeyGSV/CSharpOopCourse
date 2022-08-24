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
                throw new ArgumentException($"Недопустимый аргумент: размерность вектора = {n}");
            }

            Points = new double[n];
        }

        public Vector(Vector vector)
        {
            Points = new double[vector.Points.Length];

            for (int i = 0; i < Points.Length; ++i)
            {
                Points[i] = vector.Points[i];
            }
        }

        public Vector(double[] points)
        {
            if (points is null)
            {
                throw new ArgumentException("Недопустимый аргумент: массив = null");
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
                throw new ArgumentException($"Недопустимый аргумент: размерность вектора = {n}");
            }

            if (points is null)
            {
                throw new ArgumentException("Недопустимый аргумент: массив = null");
            }

            if (points.Length == 0)
            {
                throw new ArgumentException($"Недопустимый аргумент: размер массива = 0");
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

        public void AddVector(Vector vector)
        {
            if (Points.Length < vector.Points.Length)
            {
                double[] temp = new double[vector.Points.Length];

                for (int i = 0; i < Points.Length; ++i)
                {
                    temp[i] = Points[i];
                }

                Points = temp;
            }

            for (int i = 0; i < vector.Points.Length; ++i)
            {
                Points[i] += vector.Points[i];
            }
        }

        public void SubtractVector(Vector vector)
        {
            if (Points.Length < vector.Points.Length)
            {
                double[] temp = new double[vector.Points.Length];

                for (int i = 0; i < Points.Length; ++i)
                {
                    temp[i] = Points[i];
                }

                Points = temp;
            }

            for (int i = 0; i < vector.Points.Length; ++i)
            {
                Points[i] -= vector.Points[i];
            }
        }

        public void MultiplyVectorByScalar(double scalar)
        {
            for (int i = 0; i < Points.Length; ++i)
            {
                Points[i] *= scalar;
            }
        }

        public void ReverseVector()
        {
            for (int i = 0; i < Points.Length; ++i)
            {
                Points[i] = -1 * Points[i];
            }
        }

        public double GetLenght()
        {
            double pointsSquaresSum = 0;

            for (int i = 0; i < Points.Length; ++i)
            {
                pointsSquaresSum += Points[i] * Points[i];
            }

            return Math.Sqrt(pointsSquaresSum);
        }

        public double GetPoint(int i)
        {
            if (i < 0 || i > Points.Length)
            {
                throw new ArgumentException($"Индекс компонента {i} выходит за пределы вектора размерностью {Points.Length}");
            }

            return Points[i];
        }

        public void SetPoint(int i, double newPoint)
        {
            if (i < 0 || i > Points.Length)
            {
                throw new ArgumentException($"Индекс компонента {i} выходит за пределы вектора размерностью {Points.Length}");
            }

            Points[i] = newPoint;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            Vector p = (Vector)obj;

            if (Points.Length != p.Points.Length)
            {
                return false;
            }

            for (int i = 0; i < Points.Length; ++i)
            {
                if (Points[i] != p.Points[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 17;

            for (int i = 0; i < Points.Length; ++i)
            {
                hash = prime * hash + Points[i].GetHashCode();
            }

            return hash;
        }

        public static Vector GetVectorsSum(Vector vector1, Vector vector2)
        {
            Vector summaryVector = new Vector(vector1);
            summaryVector.AddVector(vector2);

            return summaryVector;
        }

        public static Vector GetVectorsDifference(Vector vector1, Vector vector2)
        {
            Vector differenceVector = new Vector(vector1);
            differenceVector.SubtractVector(vector2);

            return differenceVector;
        }

        public static double GetVectorsScalarMultiply(Vector vector1, Vector vector2)
        {
            Vector vector1Temp = vector1;
            Vector vector2Temp = vector2;
            int n = vector1.Points.Length;

            if (vector1.Points.Length < vector2.Points.Length)
            {
                vector1Temp = new Vector(vector2.Points.Length);
                vector1Temp.AddVector(vector1);
                vector2Temp = vector2;
                n = vector2.Points.Length;
            }

            if (vector1.Points.Length > vector2.Points.Length)
            {
                vector2Temp = new Vector(vector1.Points.Length);
                vector2Temp.AddVector(vector2);
                vector1Temp = vector1;
                n = vector1.Points.Length;
            }

            double scalarMultiplySum = 0;

            for (int i = 0; i < n; ++i)
            {
                scalarMultiplySum += vector1Temp.Points[i] * vector2Temp.Points[i];
            }

            return scalarMultiplySum;
        }
    }
}