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
            if (vectorsArray is null || vectorsArray.Length == 0)
            {
                Console.WriteLine("Передан неправильный массив");

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

            double[] points1 = new double[] { 1, 1, 1 };
            Vector vector3 = new Vector(points1);

            double[] points2 = new double[] { 1, 1, 1, 1, 1, 1 };
            Vector vector4 = new Vector(points2);

            Vector vector5 = new Vector(1);
            Vector vector6 = new Vector(10);

            Vector[] vectorsArray = new Vector[]
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
            vector3.AddVector(vector4);
            Console.WriteLine($"{vector3} - (Сложение) {Environment.NewLine}");

            Console.WriteLine(vector3);
            Console.WriteLine(vector4);
            vector3.SubtractVector(vector4);
            Console.WriteLine($"{vector3} - (Вычитание) {Environment.NewLine}");

            Console.WriteLine(vector4);
            vector4.MultiplyVectorByScalar(2);
            Console.WriteLine($"{vector4} - (Умножение на 2) {Environment.NewLine}");

            Console.WriteLine(vector3);
            vector3.ReverseVector();
            Console.WriteLine($"{vector3} - (Реверс) {Environment.NewLine}");

            Console.WriteLine(vector1);
            vector1.SetPoint(2, 1);
            Console.WriteLine($"{vector1} - (Замена по индексу ({vector1.GetPoint(2)} -> 1) {Environment.NewLine}");

            Console.WriteLine($"Размерность и длина вектора3: {vector3.GetSize()} / {vector3.GetLenght()} {Environment.NewLine}");

            Console.WriteLine($"{vector3}");
            Console.WriteLine($"{vector4}");
            vector5 = Vector.GetVectorsSum(vector3, vector4);
            Console.WriteLine($"{vector5} - (Сложение векторов, статический метод)");

            Console.WriteLine($"исходный: {vector3}");
            Console.WriteLine($"исходный: {vector4} {Environment.NewLine}");

            Console.WriteLine($"{vector5}");
            Console.WriteLine($"{vector1}");
            vector6 = Vector.GetVectorsDifference(vector5, vector1);
            Console.WriteLine($"{vector6} - (Вычитание векторов, статический метод)");

            Console.WriteLine($"исходный: {vector5}");
            Console.WriteLine($"исходный: {vector1} {Environment.NewLine}");

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