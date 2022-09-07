using System;
using System.Text;
using Academits.Gudkov.VectorTask;

namespace Academits.Gudkov.MatrixTask
{
    public class Matrix : Vector
    {
        private double[,] vectors;

        public Matrix(int vectorCount, int vectorSize) : base(1)
        {
            vectors = new double[vectorCount, vectorSize];
        }

        public Matrix(Matrix vectorsMatrix) : base(1)
        {
            vectors = new double[vectorsMatrix.vectors.GetLength(0), vectorsMatrix.vectors.GetLength(1)];

            Array.Copy(vectorsMatrix.vectors, vectors, vectors.Length);
        }

        public Matrix(double[,] vectorsArray) : base(1)
        {
            vectors = new double[vectorsArray.GetLength(0), vectorsArray.GetLength(1)];

            Array.Copy(vectorsArray, vectors, vectors.Length);
        }

        public Matrix(Vector[] vectorsArray) : base(1)
        {
            vectors = new double[vectorsArray.GetLength(0), GetVectorMaxSize(vectorsArray)];

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectorsArray[i].GetSize(); ++j)
                {
                    vectors[i, j] = vectorsArray[i].GetCoordinate(j);
                }
            }
        }

        private int GetVectorMaxSize(Vector[] vectorsArray)
        {
            int maxSize = 1;

            foreach (Vector vector in vectorsArray)
            {
                if (vector.GetSize() > maxSize)
                {
                    maxSize = vector.GetSize();
                }
            }

            return maxSize;
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

            Matrix matrix = (Matrix)obj;

            if (vectors.Length != matrix.vectors.Length)
            {
                return false;
            }

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectors.GetLength(1); ++j)
                {
                    if (vectors[i, j] != matrix.vectors[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 23;
            int hash = 1;

            foreach (double vector in vectors)
            {
                hash = prime * hash + vector.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{");

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                stringBuilder.Append('{');

                for (int j = 0; j < vectors.GetLength(1); ++j)
                {
                    stringBuilder.Append(vectors[i, j]).Append(", ");
                }

                stringBuilder.Remove(stringBuilder.Length - 2, 2).Append("}, ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}');

            return stringBuilder.ToString();
        }

        public int GetVectorCount()
        {
            return vectors.GetLength(0);
        }

        public int GetVectorSize()
        {
            return vectors.GetLength(1);
        }

        public Vector GetStringVector(int stringIndex)
        {
            double[] vector = new double[vectors.GetLength(1)];

            Array.Copy(vectors, stringIndex, vector, 0, vector.Length);

            return new Vector(vector);
        }

        public void SetVector(int stringIndex, Vector vector)
        {
            for (int i = 0; i < vector.GetSize(); ++i)
            {
                vectors[stringIndex, i] = vector.GetCoordinate(i);
            }
        }

        public Vector GetСolumnVector(int columnIndex)
        {
            Vector vector = new Vector(vectors.GetLength(0));

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                vector.SetCoordinate(i, vectors[i, columnIndex]);
            }

            return vector;
        }

        public void TransposeMatrix()
        {
            Matrix matrix = new Matrix(vectors.GetLength(1), vectors.GetLength(0));

            for (int i = 0; i < vectors.GetLength(1); ++i)
            {
                for (int j = 0; j < vectors.GetLength(0); ++j)
                {
                    matrix.vectors[i, j] = vectors[j, i];
                }
            }

            vectors = matrix.vectors;
        }

        public override void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectors.GetLength(1); ++j)
                {
                    vectors[i, j] *= scalar;
                }
            }
        }

        public double GetDeterminant()
        {
            Matrix matrix = new Matrix(vectors);

            if (matrix.vectors.GetLength(0) < 2)
            {
                return matrix.vectors[0, 0];
            }

            if (matrix.vectors[0, 0] == 0)
            {
                int basisMinorIndex = matrix.GetNonZeroBasisMinorIndex();

                if (basisMinorIndex == -1)
                {
                    return 0;
                }

                matrix.SetBasisMinorInFirstLine(basisMinorIndex);
            }

            matrix.SetColumnZero();

            return matrix.vectors[0, 0] * matrix.GetSubmatrix().GetDeterminant();
        }

        private int GetNonZeroBasisMinorIndex()
        {
            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                if (vectors[i, 0] != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private void SetBasisMinorInFirstLine(int i)
        {
            for (int j = 0; j < vectors.GetLength(1); ++j)
            {
                vectors[0, j] += vectors[i, j];
            }
        }

        private void SetColumnZero()
        {
            for (int i = 1; i < vectors.GetLength(0); ++i)
            {
                double itemCoefficient = -vectors[i, 0] / vectors[0, 0];

                for (int j = 0; j < vectors.GetLength(1); ++j)
                {
                    vectors[i, j] += itemCoefficient * vectors[0, j];
                }
            }
        }

        private Matrix GetSubmatrix()
        {
            Matrix matrix = new Matrix(vectors.GetLength(0) - 1, vectors.GetLength(1) - 1);

            for (int i = 0; i < matrix.vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.vectors.GetLength(1); ++j)
                {
                    matrix.vectors[i, j] = vectors[i + 1, j + 1];
                }
            }

            return matrix;
        }

        public void MultiplyByStringVector(Vector vector)
        {
            if (vectors.GetLength(0) == vector.GetSize() && vectors.GetLength(1) == 1)
            {
                Matrix matrix = new Matrix(vector.GetSize(), vector.GetSize());

                for (int i = 0; i < matrix.vectors.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrix.vectors.GetLength(1); ++j)
                    {
                        matrix.vectors[i, j] = vectors[i, j] * vector.GetCoordinate(j);
                    }
                }

                vectors = matrix.vectors;
            }
            else
            {
                Console.WriteLine($"Ошибка входных данных. Размер матрицы: {vectors.GetLength(0)} x {vectors.GetLength(1)}, размер вектора-строки: {vector.GetSize()}");
            }
        }

        public void MultiplyByColumnVector(Vector vector)
        {
            if (vectors.GetLength(1) == vector.GetSize())
            {
                Matrix matrix = new Matrix(vector.GetSize(), 1);

                for (int i = 0; i < vectors.GetLength(0); ++i)
                {
                    for (int j = 0; j < vectors.GetLength(1); ++j)
                    {
                        matrix.vectors[i, 0] += vectors[i, j] * vector.GetCoordinate(j);
                    }
                }

                vectors = matrix.vectors;
            }
            else
            {
                Console.WriteLine($"Ошибка входных данных. Размер матрицы: {vectors.GetLength(0)} x {vectors.GetLength(1)}, размер вектора-столбца: {vector.GetSize()}"); ;
            }
        }

        public void Add(Matrix matrix)
        {
            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectors.GetLength(1); ++j)
                {
                    vectors[i, j] += matrix.vectors[i, j];
                }
            }
        }

        public void Subtract(Matrix matrix)
        {
            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectors.GetLength(1); ++j)
                {
                    vectors[i, j] -= matrix.vectors[i, j];
                }
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix = new Matrix(matrix1.vectors.GetLength(0), matrix1.vectors.GetLength(1));

            for (int i = 0; i < matrix.vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.vectors.GetLength(1); ++j)
                {
                    matrix.vectors[i, j] = matrix1.vectors[i, j] + matrix2.vectors[i, j];
                }
            }

            return matrix;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrix = new Matrix(matrix1.vectors.GetLength(0), matrix1.vectors.GetLength(1));

            for (int i = 0; i < matrix.vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.vectors.GetLength(1); ++j)
                {
                    matrix.vectors[i, j] = matrix1.vectors[i, j] - matrix2.vectors[i, j];
                }
            }

            return matrix;
        }

        public static Matrix GetMultiplyResult(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.vectors.GetLength(1) == matrix2.vectors.GetLength(0))
            {
                Matrix matrix = new Matrix(matrix1.vectors.GetLength(0), matrix2.vectors.GetLength(1));

                for (int i = 0; i < matrix1.vectors.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrix2.vectors.GetLength(1); ++j)
                    {
                        for (int k = 0; k < matrix2.vectors.GetLength(0); ++k)
                        {
                            matrix.vectors[i, j] += matrix1.vectors[i, k] * matrix2.vectors[k, j];
                        }
                    }
                }

                return matrix;
            }

            throw new ArgumentException($"Недопустимый аргумент: матрицы не согласованы. matrix1: = {{{matrix1.vectors.GetLength(0)} ,{matrix1.vectors.GetLength(1)}}}, matrix2: = {{{matrix2.vectors.GetLength(0)} ,{matrix2.vectors.GetLength(1)}}}");
        }
    }
}