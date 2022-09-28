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
                Console.WriteLine($"Печать невозможна: ссылка на массив {nameof(matrixArray)} = null");

                return;
            }

            if (matrixArray.Length == 0)
            {
                Console.WriteLine($"Печать невозможна: размер массива {nameof(matrixArray)} = 0");

                return;
            }

            for (int i = 0; i < matrixArray.GetLength(0); ++i)
            {
                for (int j = i + 1; j < matrixArray.GetLength(0) - 1; ++j)
                {
                    bool isEquals = matrixArray[i].Equals(matrixArray[j]);
                    bool isEqualHashCode = IsEqualHashCode(matrixArray[i], matrixArray[j]);

                    Console.WriteLine("Матрицы: {0,2} - {1,2} | Equals / HashCode : {2,5} / {3,5}", i + 1, j + 1, isEquals, isEqualHashCode);
                }
            }
        }

        public static void PrintHashCodes(Matrix[] matrixArray)
        {
            for (int i = 0; i < matrixArray.GetLength(0); ++i)
            {
                Console.WriteLine("Матрица {0,2} : {1,11}", i + 1, matrixArray[i].GetHashCode());
            }
        }

        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(5, 5);
            Matrix matrix2 = new Matrix(matrix1);

            Console.WriteLine(matrix2);
            Console.WriteLine($"Размер матрицы 2: {matrix2.RowsCount} x {matrix2.ColumnsCount} {Environment.NewLine}");

            double[,] vectorsArray1 =
           {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            };

            Matrix matrix3 = new Matrix(vectorsArray1);

            Console.WriteLine($"{matrix3} - исходная матрица {nameof(matrix3)}");

            Console.WriteLine($"{matrix3.GetRow(1)} - вектор-строки матрицы {nameof(matrix3)}");
            Console.WriteLine($"{matrix3.GetColumn(1)} - вектор-столбца матрицы {nameof(matrix3)} {Environment.NewLine}");

            Vector[] vectorsArray2 =
            {
                new Vector(new double[] { 1, 1, 1, 1, 1 }),
                new Vector(new double[] { 1, 1, 1, 1, 1 }),
                new Vector(new double[] { 1, 1, 1 }),
                new Vector(new double[] { 1, 1, 1, 1, 1 }),
                new Vector(new double[] { 1, 1, 1, 1, 1 })
            };

            Matrix matrix4 = new Matrix(vectorsArray2);
            Vector vector1 = new Vector(new double[] { 0, 0, 0, 0, 0 });

            Console.WriteLine($"{matrix4} - исходная матрица {nameof(matrix4)}");

            matrix4.SetRow(2, vector1);

            Console.WriteLine($"{matrix4} - задан вектор-строка {nameof(vector1)}: {vector1} по индексу 2 матрицы {nameof(matrix4)} {Environment.NewLine}");

            double[,] vectorsArray3 =
{
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Matrix matrix5 = new Matrix(vectorsArray3);

            Console.WriteLine($"{matrix5} - исходная матрица {nameof(matrix5)}");

            matrix5.Transpose();

            Console.WriteLine($"{matrix5} - транспонированная матрица {nameof(matrix5)}");

            matrix5.MultiplyByScalar(2);

            Console.WriteLine($"{matrix5} - результат умножения матрицы {nameof(matrix5)} на скаляр (2) {Environment.NewLine}");

            double[,] vectorsArray4 =
            {
                { 0, 3, -1, 2, 6 },
                { 2, 1, 0, 0, 3 },
                { -2, -1, 0, 2, 5 },
                { -5, 7, 1, 1, 1 },
                { 2, 0, 2, -2, 1 }
            };

            double[,] vectorsArray5 =
            {
                { 0, 1, -2 },
                { -1, 2, 3 },
                { 2, 3, 4 }
            };

            Matrix matrix6 = new Matrix(vectorsArray4);

            Console.WriteLine($"{matrix6} - исходная матрица {nameof(matrix6)}");

            Console.WriteLine($"{matrix6.GetDeterminant():f2} - определитель матрицы {nameof(matrix6)} {Environment.NewLine}");

            double[,] vectorsArray6 =
{
                { 1 },
                { 1 },
                { 1 }
            };

            Matrix matrix7 = new Matrix(vectorsArray6);
            Vector vector2 = new Vector(new double[] { 2, 2, 2 });

            double[,] vectorsArray7 =
{
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };

            Matrix matrix8 = new Matrix(vectorsArray7);
            Vector vector3 = new Vector(new double[] { 2, 2, 2 });

            Console.WriteLine($"{matrix8} - исходная матрица {nameof(matrix8)}");

            matrix8.MultiplyByVector(vector3);

            Console.WriteLine($"{matrix8} - умножение матрицы {nameof(matrix8)} на вектор-столбец {nameof(vector3)}: {vector3} {Environment.NewLine}");

            double[,] vectorsArray8 =
            {
                { 4, 4, 1 },
                { 4, 4, 1 },
                { 4, 4, 1 }
            };

            double[,] vectorsArray9 =
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };

            Matrix matrix9 = new Matrix(vectorsArray8);
            Matrix matrix10 = new Matrix(vectorsArray9);

            Console.WriteLine($"{matrix9} - исходная матрица {nameof(matrix9)}");
            Console.WriteLine($"{matrix10} - исходная матрица {nameof(matrix10)}");

            matrix9.Add(matrix10);

            Console.WriteLine($"{matrix9} - результат сложения - {nameof(matrix9)} {Environment.NewLine}");

            Console.WriteLine($"{matrix9} - исходная матрица {nameof(matrix9)}");
            Console.WriteLine($"{matrix10} - исходная матрица {nameof(matrix10)}");

            matrix9.Subtract(matrix10);

            Console.WriteLine($"{matrix9} - результат вычитания - {nameof(matrix9)} {Environment.NewLine}");

            double[,] vectorsArray10 =
           {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };

            double[,] vectorsArray11 =
{
                { 4, 4, 4 },
                { 4, 4, 4 },
                { 4, 4, 4 }
            };

            Matrix matrix11 = new Matrix(vectorsArray10);
            Matrix matrix12 = new Matrix(vectorsArray11);

            Matrix matrix13 = new Matrix(1, 2);

            Console.WriteLine($"{matrix11} - исходная матрица {nameof(matrix11)}");
            Console.WriteLine($"{matrix12} - исходная матрица {nameof(matrix12)}");

            matrix13 = Matrix.GetSum(matrix11, matrix12);

            Console.WriteLine($"{matrix13} - результат сложения, статический метод - {nameof(matrix13)} {Environment.NewLine}");

            Console.WriteLine($"{matrix13} - исходная матрица {nameof(matrix13)}");
            Console.WriteLine($"{matrix11} - исходная матрица {nameof(matrix11)}");

            matrix13 = Matrix.GetDifference(matrix13, matrix11);

            Console.WriteLine($"{matrix13} - результат вычитания, статический метод - {nameof(matrix13)} {Environment.NewLine}");

            Console.WriteLine($"{matrix11} - исходная матрица {nameof(matrix11)}");
            Console.WriteLine($"{matrix12} - исходная матрица {nameof(matrix12)}");

            matrix13 = Matrix.GetMultiply(matrix11, matrix12);

            Console.WriteLine($"{matrix13} - результат умножения, статический метод - {nameof(matrix13)} {Environment.NewLine}");

            Matrix[] matrixArray =
            {
                matrix1,
                matrix2,
                matrix3,
                matrix4,
                matrix5,
                matrix6,
                matrix7,
                matrix8,
                matrix9,
                matrix10,
                matrix11,
                matrix12,
                matrix13
            };

            PrintComparisonResult(matrixArray);

            Console.WriteLine();

            PrintHashCodes(matrixArray);
        }
    }
}