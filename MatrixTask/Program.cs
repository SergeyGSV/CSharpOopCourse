using System;
using Academits.Gudkov.VectorTask;

namespace Academits.Gudkov.MatrixTask
{
    internal class Program
    {
        public static bool IsEqualHashCode(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.GetHashCode() == matrix2.GetHashCode();
        }

        public static void PrintComparisonResult(Matrix[] matrixArray)
        {
            if (matrixArray is null)
            {
                Console.WriteLine("Печать невозможна: ссылка на массив (matrixArray) = null");

                return;
            }
            else if (matrixArray.Length == 0)
            {
                Console.WriteLine("Печать невозможна: размер массива (matrixArray) = 0");

                return;
            }

            for (int i = 0; i < matrixArray.GetLength(0); ++i)
            {
                for (int j = i + 1; j < matrixArray.GetLength(0) - 1; ++j)
                {
                    Console.WriteLine($"Матрицы: {i + 1}-{j + 1} | Equals / HashCode : {matrixArray[i].Equals(matrixArray[j])} / {IsEqualHashCode(matrixArray[i], matrixArray[j])}");
                }
            }
        }
        public static void PrintHashCodes(Matrix[] matrixArray)
        {
            for (int i = 0; i < matrixArray.GetLength(0); ++i)
            {
                Console.WriteLine($"Матрица{i + 1}: {matrixArray[i].GetHashCode()}");
            }
        }

        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(5, 5);
            Matrix matrix2 = new Matrix(matrix1);

            double[,] vectorsArray1 =
            {
                { 0, 3, -1, 2, 6 },
                { 2, 1, 0, 0, 3 },
                { -2, -1, 0, 2, 5 },
                { -5, 7, 1, 1, 1 },
                { 2, 0, 2, -2, 1 }
            };

            Matrix matrix3 = new Matrix(vectorsArray1);

            Vector[] vectorsArray2 =
            {
                new Vector(new double[] { 1, 1, 1, 1, 1 }),
                new Vector(new double[] { 1, 1, 1, 1, 1 }),
                new Vector(new double[] { 1, 1, 1, 1, 1 }),
                new Vector(new double[] { 1, 1, 1, 1, 1 }),
                new Vector(new double[] { 1, 1, 1, 1, 1 })
            };

            Matrix matrix4 = new Matrix(vectorsArray2);

            Console.WriteLine(matrix1);
            Console.WriteLine(matrix2);
            Console.WriteLine(matrix3);
            Console.WriteLine(matrix4);

            Matrix[] matrixArray =
            {
                matrix1,
                matrix2,
                matrix3,
                matrix4
            };

            PrintComparisonResult(matrixArray);
            PrintHashCodes(matrixArray);

            Console.WriteLine($"Размер матрицы 1: {matrix1.GetStringCount()} x {matrix1.GetColumnCount()}");

            Console.WriteLine($"{matrix3.GetStringVector(2)} - вектор-строки матрицы 3");

            Console.WriteLine($"{matrix3.GetСolumnVector(2)} - вектор-столбца матрицы 3");

            Matrix matrix5 = new Matrix(matrix4);
            Vector vector = new Vector(matrix3.GetСolumnVector(2));

            Console.WriteLine(matrix5);
            matrix5.SetVector(2, vector);
            Console.WriteLine($"{matrix5} - задан вектор-строка {vector} по индексу 2");

            double[,] vectorsArray3 =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Matrix matrix6 = new Matrix(vectorsArray3);
            Console.WriteLine($"{matrix6} - исходная матрица");
            matrix6.TransposeMatrix();
            Console.WriteLine($"{matrix6} - транспонированная матрица");

            matrix4.MultiplyByScalar(2);
            Console.WriteLine($"{matrix4} - умножение на скаляр (2)");

            Console.WriteLine($"{matrix3.GetDeterminant():f2} - определитель матрицы");

            double[,] vectorsArray4 =
            {
                { 1 },
                { 1 },
                { 1 }
            };

            matrix4 = new Matrix(vectorsArray4);
            matrix4.MultiplyByStringVector(new Vector(new double[] { 2, 2, 2 }));
            Console.WriteLine($"{matrix4} - умножение на вектор-строку");

            double[,] vectorsArray5 =
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };

            matrix4 = new Matrix(vectorsArray5);
            matrix4.MultiplyByColumnVector(new Vector(new double[] { 2, 2, 2 }));
            Console.WriteLine($"{matrix4} - умножение на вектор-столбец");

            double[,] vectorsArray6 =
            {
                { 4, 4, 1 },
                { 4, 4, 1 },
                { 4, 4, 1 }
            };

            Matrix matrix7 = new Matrix(vectorsArray6);
            Matrix matrix8 = new Matrix(matrix7);
            matrix8.Add(matrix7);
            Console.WriteLine($"{matrix8} - сложение матриц");

            matrix8.Subtract(matrix7);
            Console.WriteLine($"{matrix8} - вычитание матриц");

            Matrix matrix9 = new Matrix(1, 1);

            matrix9 = Matrix.GetSum(matrix7, matrix8);
            Console.WriteLine($"{matrix9} - сложение матриц, статический метод");

            Matrix matrix10 = new Matrix(1, 1);

            matrix10 = Matrix.GetDifference(matrix9, matrix8);
            Console.WriteLine($"{matrix9} - вычитание матриц, статический метод");

            matrix10 = Matrix.GetMultiplyResult(matrix9, matrix8);
            Console.WriteLine($"{matrix10} - умножение матриц, статический метод");
        }
    }
}