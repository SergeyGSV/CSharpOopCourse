using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academits.Gudkov.VectorTask;

namespace Academits.Gudkov.MatrixTask
{
    public class Matrix : Vector
    {
        public double[,] Vectors { get; private set; }

        public Matrix(int n, int m) : base(1)
        {
            Vectors = new double[n, m];
        }

        public Matrix(Matrix vectorsMatrix) : base(1)
        {
            Vectors = new double[vectorsMatrix.Vectors.GetLength(0), vectorsMatrix.Vectors.GetLength(1)];

            for (int i = 0; i < Vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < Vectors.GetLength(1); ++j)
                {
                    Vectors[i, j] = vectorsMatrix.Vectors[i, j];
                }
            }
        }

        public Matrix(double[,] vectorsArray) : base(1)
        {
            Vectors = new double[vectorsArray.GetLength(0), vectorsArray.GetLength(1)];

            for (int i = 0; i < Vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < Vectors.GetLength(1); ++j)
                {
                    Vectors[i, j] = vectorsArray[i, j];
                }
            }
        }

        public Matrix(Vector[] vectorsArray) : base(1)
        {
            Vectors = new double[vectorsArray.GetLength(0), GetVectorMaxSize(vectorsArray)];

            for (int i = 0; i < Vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectorsArray[i].GetSize(); ++j)
                {
                    Vectors[i, j] = vectorsArray[i].GetPoint(j);
                }
            }
        }

        private int GetVectorMaxSize(Vector[] vectorsArray)
        {
            int maxSize = 0;

            for (int i = 0; i < vectorsArray.Length; ++i)
            {
                if (vectorsArray[i].GetSize() > maxSize)
                {
                    maxSize = vectorsArray[i].GetSize();
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

            if (Vectors.Length != matrix.Vectors.Length)
            {
                return false;
            }

            for (int i = 0; i < Vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < Vectors.GetLength(1); ++j)
                {
                    if (Vectors[i, j] != matrix.Vectors[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder matrixInfo = new StringBuilder("{");

            for (int i = 0; i < Vectors.GetLength(0); ++i)
            {
                matrixInfo.Append('{');

                for (int j = 0; j < Vectors.GetLength(1); ++j)
                {
                    matrixInfo.Append(Vectors[i, j]).Append(", ");
                }

                matrixInfo.Remove(matrixInfo.Length - 2, 2).Append("}, ");
            }

            matrixInfo.Remove(matrixInfo.Length - 2, 2).Append('}');

            return matrixInfo.ToString();
        }

        public int GetSize(int x)
        {
            return Vectors.GetLength(x);
        }

        public Vector GetStringVector(int index)
        {
            Vector vector = new Vector(Vectors.GetLength(1));

            for (int i = 0; i < Vectors.GetLength(1); ++i)
            {
                vector.SetPoint(i, Vectors[index, i]);
            }

            return vector;
        }

        public void SetVector(int index, Vector vector)
        {
            for (int i = 0; i < vector.GetSize(); ++i)
            {
                Vectors[index, i] = vector.GetPoint(i);
            }
        }

        public Vector GetСolumnVector(int index)
        {
            Vector vector = new Vector(Vectors.GetLength(0));

            for (int i = 0; i < Vectors.GetLength(0); ++i)
            {
                vector.SetPoint(i, Vectors[i, index]);
            }

            return vector;
        }

        public void TransposeMatrix()
        {
            Matrix matrix = new Matrix(Vectors.GetLength(1), Vectors.GetLength(0));

            for (int i = 0; i < Vectors.GetLength(1); ++i)
            {
                for (int j = 0; j < Vectors.GetLength(0); ++j)
                {
                    matrix.Vectors[i, j] = Vectors[j, i];
                }
            }

            Vectors = matrix.Vectors;
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < Vectors.GetLength(1); ++j)
                {
                    Vectors[i, j] *= scalar;
                }
            }
        }

        public double GetDeterminant()
        {
            Matrix matrix = new Matrix(Vectors);

            if (matrix.Vectors.GetLength(0) < 2)
            {
                return matrix.Vectors[0, 0];
            }

            if (matrix.Vectors[0, 0] == 0)
            {
                int basisMinorIndex = matrix.GetNonZeroBasisMinorIndex();

                if (basisMinorIndex == -1)
                {
                    return 0;
                }

                matrix.SetBasisMinorInFirstLine(basisMinorIndex);
            }

            matrix.SetColumnZero();

            return matrix.Vectors[0, 0] * matrix.GetSubmatrix().GetDeterminant();
        }

        private int GetNonZeroBasisMinorIndex()
        {
            for (int i = 0; i < Vectors.GetLength(0); ++i)
            {
                if (Vectors[i, 0] != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private void SetBasisMinorInFirstLine(int i)
        {
            for (int j = 0; j < Vectors.GetLength(1); ++j)
            {
                Vectors[0, j] += Vectors[i, j];
            }
        }

        private void SetColumnZero()
        {
            for (int i = 1; i < Vectors.GetLength(0); ++i)
            {
                double itemCoefficient = -Vectors[i, 0] / (Vectors[0, 0]);

                for (int j = 0; j < Vectors.GetLength(1); ++j)
                {
                    Vectors[i, j] += itemCoefficient * Vectors[0, j];
                }
            }
        }

        private Matrix GetSubmatrix()
        {
            Matrix matrix = new Matrix(Vectors.GetLength(0) - 1, Vectors.GetLength(1) - 1);

            for (int i = 0; i < matrix.Vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.Vectors.GetLength(1); ++j)
                {
                    matrix.Vectors[i, j] = Vectors[i + 1, j + 1];
                }
            }

            return matrix;
        }

        public void MultiplyByStringVector(Vector vector)
        {
            if (Vectors.GetLength(0) == vector.Points.Length && Vectors.GetLength(1) == 1)
            {
                Matrix matrix = new Matrix(vector.Points.Length, vector.Points.Length);

                for (int i = 0; i < matrix.Vectors.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrix.Vectors.GetLength(1); ++j)
                    {
                        matrix.Vectors[i, j] = Vectors[i, j] * vector.Points[j];
                    }
                }

                Vectors = matrix.Vectors;
            }
            else
            {
                Console.WriteLine($"Ошибка входных данных. Размер матрицы:{Vectors.GetLength(0)}x{Vectors.GetLength(1)}, размер вектора-строки: {vector.Points.Length}");
            }
        }

        public void MultiplyByColumnVector(Vector vector)
        {
            if (Vectors.GetLength(1) == vector.Points.Length)
            {
                Matrix matrix = new Matrix(vector.Points.Length, 1);

                for (int i = 0; i < Vectors.GetLength(0); ++i)
                {
                    for (int j = 0; j < Vectors.GetLength(1); ++j)
                    {
                        matrix.Vectors[i, 0] += Vectors[i, j] * vector.Points[j];
                    }
                }

                Vectors = matrix.Vectors;
            }
            else
            {
                Console.WriteLine($"Ошибка входных данных. Размер матрицы:{Vectors.GetLength(0)}x{Vectors.GetLength(1)}, размер вектора-столбца: {vector.Points.Length}"); ;
            }

        }

    }
}

/*
 
 */