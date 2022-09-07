using System;

namespace Academits.Gudkov.VectorTask
{
    internal class Program
    {
        public static bool IsEqualHashCode(Vector vector1, Vector vector2)
        {
            return vector1.GetHashCode() == vector2.GetHashCode();
        }

        public static void PrintComparisonResult(Vector[] vectorsArray)
        {
            if (vectorsArray is null)
            {
                Console.WriteLine("Печать невозможна: ссылка на массив (vectorsArray) = null");

                return;
            }
            else if (vectorsArray.Length == 0)
            {
                Console.WriteLine("Печать невозможна: размер массива (vectorsArray) = 0");

                return;
            }

            for (int i = 0; i < vectorsArray.Length; ++i)
            {
                for (int j = i + 1; j < vectorsArray.Length - 1; ++j)
                {
                    Console.WriteLine($"Векторы: {i + 1}-{j + 1} | Equals / HashCode : {vectorsArray[i].Equals(vectorsArray[j])} / {IsEqualHashCode(vectorsArray[i], vectorsArray[j])}");
                }
            }
        }

        public static void PrintHashCodes(Vector[] vectorsArray)
        {
            for (int i = 0; i < vectorsArray.Length; ++i)
            {
                Console.WriteLine($"Вектор{i + 1}: {vectorsArray[i].GetHashCode()}");
            }
        }

        public static void Print(Vector[] vectorsArray)
        {
            for (int i = 0; i < vectorsArray.Length; ++i)
            {
                Console.WriteLine($"Вектор{i + 1}: {vectorsArray[i]}");
            }
        }

        static void Main()
        {
            Vector vector1 = new Vector(5);
            Vector vector2 = new Vector(vector1);

            double[] coordinatesArray1 = { 1, 1, 1 };
            Vector vector3 = new Vector(coordinatesArray1);

            double[] coordinatesArray2 = { 1, 2, 3, 4, 5, 6 };
            Vector vector4 = new Vector(14, coordinatesArray2);

            Vector vector5 = new Vector(1);
            Vector vector6 = new Vector(10);

            Vector[] vectorsArray =
            {
                vector1,
                vector2,
                vector3,
                vector4,
                vector5,
                vector6
            };

            Print(vectorsArray);
            Console.WriteLine();

            Console.WriteLine(vector3);
            Console.WriteLine(vector4);
            vector3.Add(vector4);
            Console.WriteLine($"{vector3} - (Сложение) {Environment.NewLine}");

            Console.WriteLine(vector3);
            Console.WriteLine(vector4);
            vector3.Subtract(vector4);
            Console.WriteLine($"{vector3} - (Вычитание) {Environment.NewLine}");

            Console.WriteLine(vector4);
            vector4.MultiplyByScalar(2);
            Console.WriteLine($"{vector4} - (Умножение на 2) {Environment.NewLine}");

            Console.WriteLine(vector3);
            vector3.Reverse();
            Console.WriteLine($"{vector3} - (Реверс) {Environment.NewLine}");

            Console.WriteLine(vector1);
            double coordinate1 = vector1.GetCoordinate(2);

            vector1.SetCoordinate(2, 1);

            double coordinate2 = vector1.GetCoordinate(2);
            Console.WriteLine($"{vector1} - (Замена координаты ({coordinate1} -> {coordinate2}) {Environment.NewLine}");

            Console.WriteLine($"Размерность и длина вектора3: {vector3.GetSize()} / {vector3.GetLength()} {Environment.NewLine}");

            Console.WriteLine($"{vector3}");
            Console.WriteLine($"{vector4}");
            vector5 = Vector.GetSum(vector3, vector4);
            Console.WriteLine($"{vector5} - (Сложение векторов, статический метод)");

            Console.WriteLine($"исходный: {vector3}");
            Console.WriteLine($"исходный: {vector4} {Environment.NewLine}");

            Console.WriteLine($"{vector5}");
            Console.WriteLine($"{vector1}");
            vector6 = Vector.GetDifference(vector5, vector1);
            Console.WriteLine($"{vector6} - (Вычитание векторов, статический метод)");

            Console.WriteLine($"исходный: {vector5}");
            Console.WriteLine($"исходный: {vector1} {Environment.NewLine}");

            Console.WriteLine($"{vector1}");
            Console.WriteLine($"{vector3}");
            Console.WriteLine($"{Vector.GetScalarMultiplyResult(vector1, vector3)} - (Умножение векторов, статический метод)");

            Console.WriteLine($"исходный: {vector1}");
            Console.WriteLine($"исходный: {vector3} {Environment.NewLine}");

            Console.WriteLine("Текущие значения векторов:");
            Print(vectorsArray);

            Console.WriteLine();

            Console.WriteLine("Текущие значения HashCode:");
            PrintHashCodes(vectorsArray);

            Console.WriteLine();

            Console.WriteLine("Проверка на эквивалентность:");
            PrintComparisonResult(vectorsArray);
        }
    }
}