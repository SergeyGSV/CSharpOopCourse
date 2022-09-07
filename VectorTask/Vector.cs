using System;
using System.Text;

namespace Academits.Gudkov.VectorTask
{
    public class Vector
    {
        private double[] coordinates;

        public Vector(int vectorSize)
        {
            if (vectorSize <= 0)
            {
                throw new ArgumentException($"Недопустимый аргумент: размерность вектора (vectorSize) = {vectorSize}");
            }

            coordinates = new double[vectorSize];
        }

        public Vector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException("Недопустимый аргумент: ссылка на массив (vector) = null");
            }

            coordinates = new double[vector.coordinates.Length];

            vector.coordinates.CopyTo(coordinates, 0);
        }

        public Vector(double[] coordinatesArray)
        {
            if (coordinatesArray is null)
            {
                throw new ArgumentNullException("Недопустимый аргумент: ссылка на массив (coordinatesArray) = null");
            }

            if (coordinatesArray.Length == 0)
            {
                throw new ArgumentException("Недопустимый аргумент: размер массива (coordinatesArray) = 0");
            }

            coordinates = new double[coordinatesArray.Length];

            coordinatesArray.CopyTo(coordinates, 0);
        }

        public Vector(int vectorSize, double[] coordinatesArray)
        {
            if (vectorSize <= 0)
            {
                throw new ArgumentException($"Недопустимый аргумент: размерность вектора (vectorSize) = {vectorSize}");
            }

            if (coordinatesArray is null)
            {
                throw new ArgumentNullException("Недопустимый аргумент: ссылка на массив (coordinatesArray) = null");
            }

            coordinates = new double[vectorSize];

            int elementsRange = (vectorSize < coordinatesArray.Length) ? vectorSize : coordinatesArray.Length;

            Array.Copy(coordinatesArray, coordinates, elementsRange);
        }

        public int GetSize()
        {
            return coordinates.Length;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{");

            foreach (double coordinate in coordinates)
            {
                stringBuilder.Append(coordinate).Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}');

            return stringBuilder.ToString();
        }

        public void Add(Vector vector)
        {
            if (coordinates.Length < vector.coordinates.Length)
            {
                Array.Resize(ref coordinates, vector.coordinates.Length);
            }

            for (int i = 0; i < vector.coordinates.Length; ++i)
            {
                coordinates[i] += vector.coordinates[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (coordinates.Length < vector.coordinates.Length)
            {
                Array.Resize(ref coordinates, vector.coordinates.Length);
            }

            for (int i = 0; i < vector.coordinates.Length; ++i)
            {
                coordinates[i] -= vector.coordinates[i];
            }
        }

        public virtual void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < coordinates.Length; ++i)
            {
                coordinates[i] *= scalar;
            }
        }

        public void Reverse()
        {
            this.MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double coordinatesSquaresSum = 0;

            foreach (double coordinate in coordinates)
            {
                coordinatesSquaresSum += coordinate * coordinate;
            }

            return Math.Sqrt(coordinatesSquaresSum);
        }

        public double GetCoordinate(int coordinateIndex)
        {
            if (coordinateIndex < 0 || coordinateIndex >= coordinates.Length)
            {
                throw new IndexOutOfRangeException($"Индекс координаты вектора (coordinateIndex = {coordinateIndex}) выходит за допустимые границы вектора ({0} : {coordinates.Length - 1})");
            }

            return coordinates[coordinateIndex];
        }

        public void SetCoordinate(int coordinateIndex, double coordinate)
        {
            if (coordinateIndex < 0 || coordinateIndex >= coordinates.Length)
            {
                throw new IndexOutOfRangeException($"Индекс координаты вектора (coordinateIndex = {coordinateIndex}) выходит за допустимые границы вектора ({0} : {coordinates.Length - 1})");
            }

            coordinates[coordinateIndex] = coordinate;
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

            Vector vector = (Vector)obj;

            if (coordinates.Length != vector.coordinates.Length)
            {
                return false;
            }

            for (int i = 0; i < coordinates.Length; ++i)
            {
                if (coordinates[i] != vector.coordinates[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 1;

            foreach (double coordinate in coordinates)
            {
                hash = prime * hash + coordinate.GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector summaryVector = new Vector(vector1);

            summaryVector.Add(vector2);

            return summaryVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector differenceVector = new Vector(vector1);

            differenceVector.Subtract(vector2);

            return differenceVector;
        }

        public static double GetScalarMultiplyResult(Vector vector1, Vector vector2)
        {
            int minVectorSize = (vector1.coordinates.Length < vector2.coordinates.Length) ? vector1.coordinates.Length : vector2.coordinates.Length;

            double scalarMultiplyResult = 0;

            for (int i = 0; i < minVectorSize; ++i)
            {
                scalarMultiplyResult += vector1.coordinates[i] * vector2.coordinates[i];
            }

            return scalarMultiplyResult;
        }
    }
}