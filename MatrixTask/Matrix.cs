using System;
using System.Text;
using Academits.Gudkov.VectorTask;

namespace Academits.Gudkov.MatrixTask
{
    public class Matrix
    {
        private Vector[] vectors;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
            {
                throw new ArgumentOutOfRangeException($"Недопустимый аргумент: размерности матрицы должны быть больше нуля, переданы размерности {nameof(rowsCount)} = {rowsCount}, {nameof(columnsCount)} = {columnsCount}");
            }

            vectors = new Vector[rowsCount];

            for (int i = 0; i < vectors.Length; ++i)
            {
                vectors[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix vectorsMatrix)
        {
            vectors = new Vector[vectorsMatrix.vectors.Length];

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

            vectors = new Vector[vectorsArray.GetLength(0)];

            for (int i = 0; i < vectorsArray.GetLength(0); ++i)
            {
                Vector vector = new Vector(vectorsArray.GetLength(1));

                for (int j = 0, k = 0; j < vectorsArray.GetLength(1); ++j, ++k)
                {
                    vector.SetCoordinate(k, vectorsArray[i, j]);
                }

                vectors[i] = vector;
            }
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

            vectors = new Vector[vectorsArray.Length];

            for (int i = 0; i < vectors.Length; ++i)
            {
                Vector vector = new Vector(GetMaxVectorSize(vectorsArray));

                for (int j = 0; j < vectorsArray[i].GetSize(); ++j)
                {
                    vector.SetCoordinate(j, vectorsArray[i].GetCoordinate(j));
                }

                vectors[i] = vector;
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

            for (int i = 0; i < vectors.Length; ++i)
            {
                for (int j = 0; j < vectors[i].GetSize(); ++j)
                {
                    if (vectors[i].GetCoordinate(j) != matrix.vectors[i].GetCoordinate(j))
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

            foreach (Vector vector in vectors)
            {
                hash = prime * hash + vector.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{");

            for (int i = 0; i < vectors.Length; ++i)
            {
                stringBuilder.Append('{');

                for (int j = 0; j < vectors[i].GetSize(); ++j)
                {
                    stringBuilder.Append(vectors[i].GetCoordinate(j)).Append(", ");
                }

                stringBuilder.Remove(stringBuilder.Length - 2, 2).Append("}, ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}');

            return stringBuilder.ToString();
        }

        public int GetRowsCount()
        {
            return vectors.Length;
        }

        public int GetColumnsCount()
        {
            return vectors[0].GetSize();
        }

        private void CheckRowIndex(int index)
        {
            if (index < 0 || index >= vectors.Length)
            {
                throw new IndexOutOfRangeException($"Индекс выходит за допустимый диапазон. {nameof(index)} = {index}. Допустимый диапазон: 0 - {vectors.Length - 1}");
            }
        }

        private void CheckColumnIndex(int index)
        {
            if (index < 0 || index >= vectors[0].GetSize())
            {
                throw new IndexOutOfRangeException($"Индекс выходит за допустимый диапазон. {nameof(index)} = {index}. Допустимый диапазон: 0 - {vectors[0].GetSize() - 1}");
            }
        }

        public Vector GetRow(int rowIndex)
        {
            CheckRowIndex(rowIndex);

            return vectors[rowIndex];
        }

        public void SetRow(int rowIndex, Vector vector)
        {
            CheckRowIndex(rowIndex);

            if (vector.GetSize() != vectors.GetLength(1))
            {
                throw new IndexOutOfRangeException($"Размер вектора не равен размеру матрицы векторов, задать вектор невозможно. Размер вектора: {vector.GetSize()}. Размер матрицы векторов: {vectors.GetLength(0)} x {vectors.GetLength(1)}");
            }

            for (int i = 0; i < vector.GetSize(); ++i)
            {
                vectors[rowIndex].SetCoordinate(i, vector.GetCoordinate(i));
            }
        }

        public Vector GetColumn(int columnIndex)
        {
            CheckColumnIndex(columnIndex);

            Vector vector = new Vector(vectors.Length);

            for (int i = 0; i < vectors.Length; ++i)
            {
                vector.SetCoordinate(i, vectors[i].GetCoordinate(columnIndex));
            }

            return vector;
        }

        public void Transpose()
        {
            Matrix matrix = new Matrix(vectors[0].GetSize(), vectors.Length);

            for (int i = 0; i < matrix.vectors.Length; ++i)
            {
                matrix.vectors[i] = GetColumn(i);
            }

            vectors = matrix.vectors;
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < vectors.Length; ++i)
            {
                vectors[i].MultiplyByScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (vectors.Length != vectors[0].GetSize())
            {
                throw new InvalidOperationException($"Матрица векторов не квадратная, вычисление определителя невозможно. Размер матрицы: {vectors.Length} x {vectors[0].GetSize()}");
            }

            Matrix matrix = new Matrix(vectors);

            if (matrix.vectors.GetLength(0) < 2)
            {
                return matrix.vectors[0].GetCoordinate(0);
            }

            if (matrix.vectors[0].GetCoordinate(0) == 0)
            {
                int basisMinorIndex = matrix.GetNonZeroBasisMinorIndex();

                if (basisMinorIndex == -1)
                {
                    return 0;
                }

                matrix.SetBasisMinorInFirstRow(basisMinorIndex);
            }

            matrix.SetColumnZero();

            return matrix.vectors[0].GetCoordinate(0) * matrix.GetSubmatrix().GetDeterminant();
        }

        private int GetNonZeroBasisMinorIndex()
        {
            for (int i = 0; i < vectors.Length; ++i)
            {
                if (vectors[i].GetCoordinate(0) != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private void SetBasisMinorInFirstRow(int index)
        {
            for (int j = 0; j < vectors[0].GetSize(); ++j)
            {
                vectors[0].SetCoordinate(j, vectors[0].GetCoordinate(j) + vectors[index].GetCoordinate(j));
            }
        }

        private void SetColumnZero()
        {
            for (int i = 1; i < vectors.Length; ++i)
            {
                double itemCoefficient = -vectors[i].GetCoordinate(0) / vectors[0].GetCoordinate(0);

                for (int j = 0; j < vectors[0].GetSize(); ++j)
                {
                    vectors[i].SetCoordinate(j, vectors[i].GetCoordinate(j) + itemCoefficient * vectors[0].GetCoordinate(j));
                }
            }
        }

        private Matrix GetSubmatrix()
        {
            Matrix matrix = new Matrix(vectors.Length - 1, vectors[0].GetSize() - 1);

            for (int i = 0; i < matrix.vectors.Length; ++i)
            {
                for (int j = 0; j < matrix.vectors[0].GetSize(); ++j)
                {
                    matrix.vectors[i].SetCoordinate(j, vectors[i + 1].GetCoordinate(j + 1));
                }
            }

            return matrix;
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (vectors[0].GetSize() != vector.GetSize())
            {
                throw new ArgumentException($"Количество столбцов матрицы векторов и размер вектора не совпадают, умножение на вектор невозможно. Размер матрицы векторов: {vectors.Length} x {vectors[0].GetSize()}. Размер вектора: {vector.GetSize()}");
            }

            Vector multiplicationVector = new Vector(vector.GetSize());

            for (int i = 0; i < vectors.Length; ++i)
            {
                double sum = 0;

                for (int j = 0; j < vectors[0].GetSize(); ++j)
                {
                    sum += vectors[i].GetCoordinate(j) * vector.GetCoordinate(j);
                }

                multiplicationVector.SetCoordinate(i, sum);
            }

            return multiplicationVector;
        }

        private void CheckForDimensionsEquals(Matrix matrix)
        {
            if (vectors.Length != matrix.vectors.Length || vectors[0].GetSize() != matrix.vectors[0].GetSize())
            {
                throw new ArgumentException($"Размеры матриц векторов не совпадают, операция невозможна. Размеры матрицы1: {vectors.Length} x {vectors[0].GetSize()}. Размеры матрицы2: {matrix.vectors.Length} x {matrix.vectors[0].GetSize()}");
            }
        }

        public void Add(Matrix matrix)
        {
            CheckForDimensionsEquals(matrix);

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectors[0].GetSize(); ++j)
                {
                    vectors[i].SetCoordinate(j, vectors[i].GetCoordinate(j) + matrix.vectors[i].GetCoordinate(j));
                }
            }
        }

        public void Subtract(Matrix matrix)
        {
            CheckForDimensionsEquals(matrix);

            for (int i = 0; i < vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < vectors[0].GetSize(); ++j)
                {
                    vectors[i].SetCoordinate(j, vectors[i].GetCoordinate(j) - matrix.vectors[i].GetCoordinate(j));
                }
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
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
            if (matrix1.vectors[0].GetSize() != matrix2.vectors.Length)
            {
                throw new ArgumentException($"Матрицы векторов не согласованы, число столбцов первой матрицы не равно числу строк второй матрицы, произведение невозможно. Размеры {nameof(matrix1)}: {matrix1.vectors.Length} x {matrix1.vectors[0].GetSize()}. Размеры {nameof(matrix2)}: {matrix2.vectors.Length} x {matrix2.vectors[0].GetSize()}");
            }

            Matrix matrix = new Matrix(matrix1.vectors.Length, matrix2.vectors[0].GetSize());

            for (int i = 0; i < matrix2.vectors[0].GetSize(); ++i)
            {
                for (int j = 0; j < matrix1.vectors.Length; ++j)
                {
                    matrix.vectors[j].SetCoordinate(i, Vector.GetScalarMultiply(matrix1.GetRow(j), matrix2.GetColumn(i)));
                }
            }

            return matrix;
        }
    }
}