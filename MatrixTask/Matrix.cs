using System;
using System.Text;
using Academits.Gudkov.VectorTask;

namespace Academits.Gudkov.MatrixTask
{
    public class Matrix
    {
        //private double[,] vectors;
        private Vector[,] vectors;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
            {
                throw new ArgumentOutOfRangeException($"Недопустимый аргумент: размерности матрицы должны быть больше нуля, переданы размерности {nameof(rowsCount)} = {rowsCount}, {nameof(columnsCount)} = {columnsCount}");
            }

            vectors = new Vector[rowsCount, columnsCount];
        }

        public Matrix(Matrix vectorsMatrix)
        {
            vectors = new Vector[vectorsMatrix.vectors.GetLength(0), vectorsMatrix.vectors.GetLength(1)];

            Array.Copy(vectorsMatrix.vectors, vectors, vectors.Length);
        }

        public Matrix(double[,] vectorsArray)
        {
            if (vectorsArray is null)
            {
                throw new ArgumentNullException($"Недопустимый аргумент: ссылка на массив ({nameof(vectorsArray)}) = null");
            }

            if (vectorsArray.Length == 0)
            {
                throw new ArgumentException($"Недопустимый аргумент: размеры массива должны быть больше нуля, передан массив {nameof(vectorsArray)} размером: {vectorsArray.GetLength(0)} x {vectorsArray.GetLength(1)}");
            }

            vectors = new Vector[vectorsArray.GetLength(0), vectorsArray.GetLength(1)];

            Array.Copy(vectorsArray, vectors, vectors.Length);
        }

        public Matrix(Vector[] vectorsArray)
        {
            if (vectorsArray is null)
            {
                throw new ArgumentNullException($"Недопустимый аргумент: ссылка на вектор ({nameof(vectorsArray)}) = null");
            }

            if (vectorsArray.Length == 0)
            {
                throw new ArgumentException($"Недопустимый аргумент: размерность вектора должна быть больше нуля, передан вектор {nameof(vectorsArray)} размером: {vectorsArray.Length}");
            }

            vectors = new Vector[vectorsArray.Length, GetMaxVectorSize(vectorsArray)];

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectorsArray[i].GetSize(); ++j)
                {
                    vectors[i, j] = vectorsArray[i].GetCoordinate(j);
                }
            }
        }

        private static int GetMaxVectorSize(Vector[] vectorsArray)
        {
            int maxSize = 0; // Добавить проверки - начальное значение maxSize лучше сделать 0, чтобы для пустого массива функция вернула 0

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

        public int GetRowsCount()
        {
            return vectors.GetLength(0);
        }

        public int GetColumnsCount()
        {
            return vectors.GetLength(1);
        }

        private void CheckIndexInValidRange(int index, int rangeType)
        {
            if (index < 0 || index >= vectors.GetLength(rangeType))
            {
                throw new IndexOutOfRangeException($"Индекс выходит за допустимый диапазон, получить вектор невозможно. {nameof(index)} = {index}). Диапазон матрицы векторов: 0 - {vectors.GetLength(rangeType) - 1}");
            }
        }

        public Vector GetRow(int rowIndex)
        {
            CheckIndexInValidRange(rowIndex, 0);

            Vector vector = new Vector(vectors.GetLength(1));

            for (int i = 0; i < vectors.GetLength(1); ++i)
            {
                vector.SetCoordinate(i, vectors[rowIndex, i]);
            }

            return vector;
        }

        public void SetRow(int rowIndex, Vector vector)
        {
            CheckIndexInValidRange(rowIndex, 0);

            if (vector.GetSize() != vectors.GetLength(1))
            {
                throw new IndexOutOfRangeException($"Размер вектора не равен размеру матрицы векторов, задать вектор невозможно. Размер вектора: {vector.GetSize()}. Размер матрицы векторов: {vectors.GetLength(0)} x {vectors.GetLength(1)}");
            }

            for (int i = 0; i < vector.GetSize(); ++i)
            {
                vectors[rowIndex, i] = vector.GetCoordinate(i);
            }
        }

        public Vector GetColumn(int columnIndex)
        {
            CheckIndexInValidRange(columnIndex, 1);

            Vector vector = new Vector(vectors.GetLength(0));

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                vector.SetCoordinate(i, vectors[i, columnIndex]);
            }

            return vector;
        }

        public void Transpose()
        {
            double[,] transposedMatrix = new double[vectors.GetLength(1), vectors.GetLength(0)];

            for (int i = 0; i < vectors.GetLength(1); ++i)
            {
                for (int j = 0; j < vectors.GetLength(0); ++j)
                {
                    transposedMatrix[i, j] = vectors[j, i];
                }
            }

            vectors = transposedMatrix;
        }

        public void MultiplyByScalar(double scalar)
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
            if (vectors.GetLength(0) != vectors.GetLength(1))
            {
                throw new InvalidOperationException($"Матрица векторов не квадратная, вычисление определителя невозможно. Размер матрицы: {vectors.GetLength(0)} x {vectors.GetLength(1)}");
            }

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

                matrix.SetBasisMinorInFirstRow(basisMinorIndex);
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

        private void SetBasisMinorInFirstRow(int index)
        {
            for (int j = 0; j < vectors.GetLength(1); ++j)
            {
                vectors[0, j] += vectors[index, j];
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

        public Vector MultiplyByVector(Vector vector)
        {
            if (vectors.GetLength(1) != vector.GetSize())
            {
                throw new ArgumentException($"Количество столбцов матрицы векторов и размер вектора не совпадают, умножение на вектор невозможно. Размер матрицы векторов: {vectors.GetLength(0)} x {vectors.GetLength(1)}. Размер вектора: {vector.GetSize()}");
            }

            Vector multiplicationVector = new Vector(vector.GetSize());

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                double sum = 0;

                for (int j = 0; j < vectors.GetLength(1); ++j)
                {
                    sum += vectors[i, j] * vector.GetCoordinate(j);
                }

                multiplicationVector.SetCoordinate(i, sum);
            }

            return multiplicationVector;
        }

        private void CheckForDimensionsEquals(Matrix matrix)
        {
            if (vectors.GetLength(0) != matrix.vectors.GetLength(0) || vectors.GetLength(1) != matrix.vectors.GetLength(1))
            {
                throw new ArgumentException($"Размеры матриц векторов не совпадают, операция невозможна. Размеры матрицы1: {vectors.GetLength(0)} x {vectors.GetLength(1)}. Размеры матрицы2: {matrix.vectors.GetLength(0)} x {matrix.vectors.GetLength(1)}");
            }
        }

        public void Add(Matrix matrix)
        {
            CheckForDimensionsEquals(matrix);

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
            CheckForDimensionsEquals(matrix);

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
            matrix1.CheckForDimensionsEquals(matrix2);

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

        public static Matrix GetSum1(Matrix matrix1, Matrix matrix2)
        {
            matrix1.CheckForDimensionsEquals(matrix2);

            Matrix sumMatrix = new Matrix(matrix1);

            sumMatrix.Add(matrix2);

            return sumMatrix;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            matrix1.CheckForDimensionsEquals(matrix2);

            Matrix differenceMatrix = new Matrix(matrix1);

            differenceMatrix.Subtract(matrix2);

            return differenceMatrix;
        }

        public static Matrix GetMultiply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.vectors.GetLength(1) != matrix2.vectors.GetLength(0))
            {
                throw new ArgumentException($"Матрицы векторов не согласованы, число столбцов первой матрицы не равно числу строк второй матрицы, произведение невозможно. Размеры {nameof(matrix1)}: {matrix1.vectors.GetLength(0)} x {matrix1.vectors.GetLength(1)}. Размеры {nameof(matrix2)}: {matrix2.vectors.GetLength(0)} x {matrix2.vectors.GetLength(1)}");
            }

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
    }
}