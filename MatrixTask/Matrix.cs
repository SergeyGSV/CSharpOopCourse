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
                throw new ArgumentOutOfRangeException($"Ошибка: Размеры матрицы векторов должны быть больше нуля. Переданы размеры {nameof(rowsCount)} = {rowsCount}, {nameof(columnsCount)} = {columnsCount}");
            }

            vectors = new Vector[rowsCount];

            for (int i = 0; i < GetRowsCount(); ++i)
            {
                vectors[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix vectorsMatrix)
        {
            vectors = new Vector[vectorsMatrix.vectors.Length];

            Array.Copy(vectorsMatrix.vectors, vectors, GetRowsCount());
        }

        public Matrix(double[,] vectorsCoordinatesArray)
        {
            if (vectorsCoordinatesArray is null)
            {
                throw new ArgumentNullException($"Ошибка: Ссылка на массив ({nameof(vectorsCoordinatesArray)}) = null");
            }

            if (vectorsCoordinatesArray.Length == 0)
            {
                throw new ArgumentException($"Ошибка: Размеры массива координат векторов должны быть больше нуля. Переданы размеры массива ({nameof(vectorsCoordinatesArray)}): {vectorsCoordinatesArray.GetLength(0)} x {vectorsCoordinatesArray.GetLength(1)}");
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
                throw new ArgumentNullException($"Ошибка: ссылка на массив векторов ({nameof(vectorsArray)}) = null");
            }

            if (vectorsArray.Length == 0)
            {
                throw new ArgumentException($"Ошибка: Размер массива векторов должен быть больше нуля. Передан размер массива ({nameof(vectorsArray)}): {vectorsArray.Length}");
            }

            vectors = new Vector[vectorsArray.Length];

            for (int i = 0; i < GetRowsCount(); ++i)
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

            if (GetRowsCount() != matrix.GetRowsCount())
            {
                return false;
            }

            for (int i = 0; i < GetRowsCount(); ++i)
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

            for (int i = 0; i < GetRowsCount(); ++i)
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
            if (index < 0 || index >= GetRowsCount())
            {
                throw new IndexOutOfRangeException($"Ошибка: Индекс строки выходит за допустимый диапазон матрицы векторов. Передан {nameof(index)} = {index}. Допустимый диапазон: 0 - {GetRowsCount() - 1}. Текущие размеры матрицы: {GetRowsCount()} x {GetColumnsCount()}");
            }
        }

        private void CheckColumnIndex(int index)
        {
            if (index < 0 || index >= GetColumnsCount())
            {
                throw new IndexOutOfRangeException($"Ошибка: Индекс столбца выходит за допустимый диапазон матрицы векторов. Передан {nameof(index)} = {index}. Допустимый диапазон: 0 - {GetColumnsCount() - 1}. Текущие размеры матрицы: {GetRowsCount()} x {GetColumnsCount()}");
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

            if (vector.GetSize() != GetColumnsCount())
            {
                throw new IndexOutOfRangeException($"Ошибка: Размерность вектора должна быть равна количеству столбцов матрицы векторов. Передана размерность вектора ({nameof(vector)}): {vector.GetSize()}. Переданы размеры матрицы: {GetRowsCount()} x {GetColumnsCount()}");
            }

            for (int i = 0; i < vector.GetSize(); ++i)
            {
                vectors[rowIndex].SetCoordinate(i, vector.GetCoordinate(i));
            }
        }

        public Vector GetColumn(int columnIndex)
        {
            CheckColumnIndex(columnIndex);

            Vector vector = new Vector(GetRowsCount());

            for (int i = 0; i < GetRowsCount(); ++i)
            {
                vector.SetCoordinate(i, vectors[i].GetCoordinate(columnIndex));
            }

            return vector;
        }

        public void Transpose()
        {
            Matrix matrix = new Matrix(GetColumnsCount(), GetRowsCount());

            for (int i = 0; i < matrix.GetRowsCount(); ++i)
            {
                matrix.vectors[i] = GetColumn(i);
            }

            vectors = matrix.vectors;
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < GetRowsCount(); ++i)
            {
                vectors[i].MultiplyByScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (GetRowsCount() != GetColumnsCount())
            {
                throw new InvalidOperationException($"Ошибка: Матрица векторов должна быть квадратной. Переданы размеры матрицы: {GetRowsCount()} x {GetColumnsCount()}");
            }

            Matrix matrix = new Matrix(vectors);

            if (matrix.GetRowsCount() < 2)
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
            for (int i = 0; i < GetRowsCount(); ++i)
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
            for (int j = 0; j < GetColumnsCount(); ++j)
            {
                vectors[0].SetCoordinate(j, vectors[0].GetCoordinate(j) + vectors[index].GetCoordinate(j));
            }
        }

        private void SetColumnZero()
        {
            for (int i = 1; i < GetRowsCount(); ++i)
            {
                double itemCoefficient = -vectors[i].GetCoordinate(0) / vectors[0].GetCoordinate(0);

                for (int j = 0; j < GetColumnsCount(); ++j)
                {
                    vectors[i].SetCoordinate(j, vectors[i].GetCoordinate(j) + itemCoefficient * vectors[0].GetCoordinate(j));
                }
            }
        }

        private Matrix GetSubmatrix()
        {
            Matrix matrix = new Matrix(GetRowsCount() - 1, GetColumnsCount() - 1);

            for (int i = 0; i < matrix.GetRowsCount(); ++i)
            {
                for (int j = 0; j < matrix.GetColumnsCount(); ++j)
                {
                    matrix.vectors[i].SetCoordinate(j, vectors[i + 1].GetCoordinate(j + 1));
                }
            }

            return matrix;
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (GetColumnsCount() != vector.GetSize())
            {
                throw new ArgumentException($"Ошибка: Количество столбцов матрицы векторов должно совпадать с размерностью вектора. Переданы размеры матрицы: {GetRowsCount()} x {GetColumnsCount()}. Передана размерность вектора ({nameof(vector)}): {vector.GetSize()}");
            }

            Vector multiplicationVector = new Vector(vector.GetSize());

            for (int i = 0; i < GetRowsCount(); ++i)
            {
                double sum = 0;

                for (int j = 0; j < GetColumnsCount(); ++j)
                {
                    sum += vectors[i].GetCoordinate(j) * vector.GetCoordinate(j);
                }

                multiplicationVector.SetCoordinate(i, sum);
            }

            return multiplicationVector;
        }

        private void CheckForDimensionsEquals(Matrix matrix)
        {
            if (GetRowsCount() != matrix.GetRowsCount() || GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException($"Ошибка: Размеры матриц векторов должны совпадать. Переданы размеры матрицы1: {GetRowsCount()} x {GetColumnsCount()}. Переданы размеры матрицы2 ({nameof(matrix)}): {matrix.GetRowsCount()} x {matrix.GetColumnsCount()}");
            }
        }

        public void Add(Matrix matrix)
        {
            CheckForDimensionsEquals(matrix);

            for (int i = 0; i < GetRowsCount(); ++i)
            {
                for (int j = 0; j < GetColumnsCount(); ++j)
                {
                    vectors[i].SetCoordinate(j, vectors[i].GetCoordinate(j) + matrix.vectors[i].GetCoordinate(j));
                }
            }
        }

        public void Subtract(Matrix matrix)
        {
            CheckForDimensionsEquals(matrix);

            for (int i = 0; i < GetRowsCount(); ++i)
            {
                for (int j = 0; j < GetColumnsCount(); ++j)
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
            if (matrix1.GetColumnsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException($"Ошибка: Матрицы векторов должны быть согласованы, число столбцов первой матрицы должно быть равно числу строк второй матрицы. Переданы размеры: {nameof(matrix1)}: {matrix1.GetRowsCount()} x {matrix1.GetColumnsCount()}, {nameof(matrix2)}: {matrix2.GetRowsCount()} x {matrix2.GetColumnsCount()}");
            }

            Matrix matrix = new Matrix(matrix1.GetRowsCount(), matrix2.GetColumnsCount());

            for (int i = 0; i < matrix2.GetColumnsCount(); ++i)
            {
                for (int j = 0; j < matrix1.GetRowsCount(); ++j)
                {
                    matrix.vectors[j].SetCoordinate(i, Vector.GetScalarMultiply(matrix1.GetRow(j), matrix2.GetColumn(i)));
                }
            }

            return matrix;
        }
    }
}