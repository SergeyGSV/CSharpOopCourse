using System;
using System.Text;
using Academits.Gudkov.VectorTask;

namespace Academits.Gudkov.MatrixTask
{
    public class Matrix
    {
        private Vector[] vectors;

        public int RowsCount
        {
            get
            {
                return vectors.Length;
            }
        }

        public int ColumnsCount
        {
            get
            {
                return vectors[0].GetSize();
            }
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
            {
                throw new ArgumentOutOfRangeException($"Ошибка: Размеры матрицы векторов должны быть больше нуля. Переданы размеры {nameof(rowsCount)} = {rowsCount}, {nameof(columnsCount)} = {columnsCount}");
            }

            vectors = new Vector[rowsCount];

            for (int i = 0; i < RowsCount; ++i)
            {
                vectors[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix vectorsMatrix)
        {
            if (vectorsMatrix is null)
            {
                throw new ArgumentNullException($"Ошибка: Ссылка на матрицу векторов {nameof(vectorsMatrix)} = null");
            }

            vectors = new Vector[vectorsMatrix.vectors.Length];

            Array.Copy(vectorsMatrix.vectors, vectors, RowsCount);
        }

        public Matrix(double[,] vectorsCoordinatesArray)
        {
            if (vectorsCoordinatesArray is null)
            {
                throw new ArgumentNullException($"Ошибка: Ссылка на массив {nameof(vectorsCoordinatesArray)} = null");
            }

            if (vectorsCoordinatesArray.Length == 0)
            {
                throw new ArgumentException($"Ошибка: Размеры массива координат векторов должны быть больше нуля. Передан массив {nameof(vectorsCoordinatesArray)} с размерами: {vectorsCoordinatesArray.GetLength(0)} x {vectorsCoordinatesArray.GetLength(1)}");
            }

            vectors = new Vector[vectorsCoordinatesArray.GetLength(0)];

            for (int i = 0; i < vectorsCoordinatesArray.GetLength(0); ++i)
            {
                Vector vector = new Vector(vectorsCoordinatesArray.GetLength(1));

                for (int j = 0, k = 0; j < vectorsCoordinatesArray.GetLength(1); ++j, ++k)
                {
                    vector.SetCoordinate(k, vectorsCoordinatesArray[i, j]);
                }

                vectors[i] = vector;
            }
        }

        public Matrix(Vector[] vectorsArray)
        {
            if (vectorsArray is null)
            {
                throw new ArgumentNullException($"Ошибка: ссылка на массив векторов {nameof(vectorsArray)} = null");
            }

            if (vectorsArray.Length == 0)
            {
                throw new ArgumentException($"Ошибка: Размер массива векторов должен быть больше нуля. Передан массив {nameof(vectorsArray)} размером: {vectorsArray.Length}");
            }

            vectors = new Vector[vectorsArray.Length];

            for (int i = 0; i < RowsCount; ++i)
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
            int maxSize = 0;

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

            if (RowsCount != matrix.RowsCount || ColumnsCount != matrix.ColumnsCount)
            {
                return false;
            }

            for (int i = 0; i < RowsCount; ++i)
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

            for (int i = 0; i < RowsCount; ++i)
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

        private void CheckRowIndex(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= RowsCount)
            {
                throw new IndexOutOfRangeException($"Ошибка: Индекс строки выходит за допустимый диапазон матрицы векторов. Передан {nameof(rowIndex)} = {rowIndex}. Допустимый диапазон: 0 - {RowsCount - 1}. Текущие размеры матрицы: {RowsCount} x {ColumnsCount}");
            }
        }

        private void CheckColumnIndex(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= ColumnsCount)
            {
                throw new IndexOutOfRangeException($"Ошибка: Индекс столбца выходит за допустимый диапазон матрицы векторов. Передан {nameof(columnIndex)} = {columnIndex}. Допустимый диапазон: 0 - {ColumnsCount - 1}. Текущие размеры матрицы: {RowsCount} x {ColumnsCount}");
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

            if (vector.GetSize() != ColumnsCount)
            {
                throw new IndexOutOfRangeException($"Ошибка: Размерность вектора должна быть равна количеству столбцов матрицы векторов. Передан вектор {nameof(vector)} с размерностью: {vector.GetSize()}. Передана матрица с размерами: {RowsCount} x {ColumnsCount}");
            }

            for (int i = 0; i < vector.GetSize(); ++i)
            {
                vectors[rowIndex].SetCoordinate(i, vector.GetCoordinate(i));
            }
        }

        public Vector GetColumn(int columnIndex)
        {
            CheckColumnIndex(columnIndex);

            Vector vector = new Vector(RowsCount);

            for (int i = 0; i < RowsCount; ++i)
            {
                vector.SetCoordinate(i, vectors[i].GetCoordinate(columnIndex));
            }

            return vector;
        }

        public void Transpose()
        {
            Vector[] vectorsArray = new Vector[ColumnsCount];

            for (int i = 0; i < vectorsArray.Length; ++i)
            {
                vectorsArray[i] = GetColumn(i);
            }

            vectors = vectorsArray;
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < RowsCount; ++i)
            {
                vectors[i].MultiplyByScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (RowsCount != ColumnsCount)
            {
                throw new InvalidOperationException($"Ошибка: Матрица векторов должна быть квадратной. Передана матрица с размерами: {RowsCount} x {ColumnsCount}");
            }

            Matrix matrix = new Matrix(vectors);

            if (matrix.RowsCount == 1)
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
            for (int i = 0; i < RowsCount; ++i)
            {
                if (vectors[i].GetCoordinate(0) != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private void SetBasisMinorInFirstRow(int basisMinorIndex)
        {
            for (int j = 0; j < ColumnsCount; ++j)
            {
                vectors[0].SetCoordinate(j, vectors[0].GetCoordinate(j) + vectors[basisMinorIndex].GetCoordinate(j));
            }
        }

        private void SetColumnZero()
        {
            for (int i = 1; i < RowsCount; ++i)
            {
                double itemCoefficient = -vectors[i].GetCoordinate(0) / vectors[0].GetCoordinate(0);

                for (int j = 0; j < ColumnsCount; ++j)
                {
                    vectors[i].SetCoordinate(j, vectors[i].GetCoordinate(j) + itemCoefficient * vectors[0].GetCoordinate(j));
                }
            }
        }

        private Matrix GetSubmatrix()
        {
            Matrix matrix = new Matrix(RowsCount - 1, ColumnsCount - 1);

            for (int i = 0; i < matrix.RowsCount; ++i)
            {
                for (int j = 0; j < matrix.ColumnsCount; ++j)
                {
                    matrix.vectors[i].SetCoordinate(j, vectors[i + 1].GetCoordinate(j + 1));
                }
            }

            return matrix;
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (ColumnsCount != vector.GetSize())
            {
                throw new ArgumentException($"Ошибка: Количество столбцов матрицы векторов должно совпадать с размерностью вектора. Передана матрица с размерами: {RowsCount} x {ColumnsCount}. Передана размерность вектора {nameof(vector)}: {vector.GetSize()}");
            }

            Vector multiplicationVector = new Vector(vector.GetSize());

            for (int i = 0; i < RowsCount; ++i)
            {
                double sum = 0;

                for (int j = 0; j < ColumnsCount; ++j)
                {
                    sum += vectors[i].GetCoordinate(j) * vector.GetCoordinate(j);
                }

                multiplicationVector.SetCoordinate(i, sum);
            }

            return multiplicationVector;
        }

        private void CheckForDimensionsEquals(Matrix matrix)
        {
            if (RowsCount != matrix.RowsCount || ColumnsCount != matrix.ColumnsCount)
            {
                throw new ArgumentException($"Ошибка: Размеры матриц векторов должны совпадать. Передана матрица1 с размерами: {RowsCount} x {ColumnsCount}. Передана матрица2 ({nameof(matrix)}) с размерами: {matrix.RowsCount} x {matrix.ColumnsCount}");
            }
        }

        public void Add(Matrix matrix)
        {
            CheckForDimensionsEquals(matrix);

            for (int i = 0; i < RowsCount; ++i)
            {
                for (int j = 0; j < ColumnsCount; ++j)
                {
                    vectors[i].SetCoordinate(j, vectors[i].GetCoordinate(j) + matrix.vectors[i].GetCoordinate(j));
                }
            }
        }

        public void Subtract(Matrix matrix)
        {
            CheckForDimensionsEquals(matrix);

            for (int i = 0; i < RowsCount; ++i)
            {
                for (int j = 0; j < ColumnsCount; ++j)
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
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"Ошибка: Матрицы векторов должны быть согласованы, число столбцов первой матрицы должно быть равно числу строк второй матрицы. Переданы матрицы с размерами: {nameof(matrix1)}: {matrix1.RowsCount} x {matrix1.ColumnsCount}, {nameof(matrix2)}: {matrix2.RowsCount} x {matrix2.ColumnsCount}");
            }

            Matrix matrix = new Matrix(matrix1.RowsCount, matrix2.ColumnsCount);

            for (int i = 0; i < matrix2.ColumnsCount; ++i)
            {
                for (int j = 0; j < matrix1.RowsCount; ++j)
                {
                    matrix.vectors[j].SetCoordinate(i, Vector.GetScalarMultiply(matrix1.GetRow(j), matrix2.GetColumn(i)));
                }
            }

            return matrix;
        }
    }
}