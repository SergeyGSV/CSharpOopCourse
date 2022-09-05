using System;
using Academits.Gudkov.VectorTask;

namespace Academits.Gudkov.MatrixTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Matrix matrix1 = new Matrix(4, 10);

            /*Console.WriteLine(matrix1.Vectors.GetLength(0));
            Console.WriteLine(matrix1.Vectors.GetLength(1));

            for (int i = 0; i < matrix1.Vectors.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix1.Vectors.GetLength(1); ++j)
                {
                    matrix1.Vectors[i, j] = 1;
                }
            }
            
            Matrix matrix2 = new Matrix(matrix1);

            double[,] vectorsArray1 = new double[,]
            {
                {2,2,2,2,2 },
                {2,2,2,2,2 }
            };

            Matrix matrix3 = new Matrix(vectorsArray1);
            */
            /*Vector vector1 = new Vector(new double[] { 0, 3, -1, 2, 6 });
            Vector vector2 = new Vector(new double[] { 2, 1, 0, 0, 3 });
            Vector vector3 = new Vector(new double[] { -2, -1, 0, 2, 5 });
            Vector vector4 = new Vector(new double[] { -5, 7, 1, 1, 1 });
            Vector vector5 = new Vector(new double[] { 2, 0, 2, -2, 1 });

            Vector[] vectorsArray2 = new Vector[]
            {
                vector1,
                vector2,
                vector3,
                vector4,
                vector5
            };

            Matrix matrix4 = new Matrix(vectorsArray2);

            Console.WriteLine(matrix4.GetDeterminant());

            matrix4.TransposeMatrix();

            Console.WriteLine(matrix4.GetDeterminant());


            Vector vector6 = new Vector(new double[] { 1, 1, 1, 1, 1 });
            Vector vector7 = new Vector(new double[] { 1, 1, 1, 1, 1 });
            Vector vector8 = new Vector(new double[] { 1, 1, 1, 1, 1 });
            Vector vector9 = new Vector(new double[] { 1, 1, 1, 1, 1 });
            Vector vector10 = new Vector(new double[] { 1, 1, 1, 1, 1 });
            Vector vector11 = new Vector(new double[] { 2, 2, 2, 2, 2 });

            Vector[] vectorsArray3 = new Vector[]
            {
                vector6,
                vector7,
                vector8,
                vector9,
                vector10
            };

            Matrix matrix5 = new Matrix(vectorsArray3);

            Console.WriteLine(matrix5.GetDeterminant());

            matrix5.TransposeMatrix();

            Console.WriteLine(matrix5.GetDeterminant());

            matrix5.MultiplyByColumnVector(vector11);

            Console.WriteLine(matrix5);
            */

            Vector[] vectorsArray4 = new Vector[]
            {
                new Vector(new double[] { 1, 2, 2 }),
                new Vector(new double[] { 3, 1, 1 }),
            };

            Vector[] vectorsArray5 = new Vector[]
            {
                new Vector(new double[] { 4, 2 }),
                new Vector(new double[] { 3, 1 }),
                new Vector(new double[] { 1, 5 }),
            };

            Matrix matrix6 = new Matrix(vectorsArray4);
            Matrix matrix7 = new Matrix(vectorsArray5);

            Console.WriteLine(Matrix.GetMatrixMultiply(matrix6, matrix7));

            /*
            Console.WriteLine(vectorsArray2.Length);

            Console.WriteLine(matrix4);
           

            Console.WriteLine(matrix4.GetStringVector(2));
           

            matrix4.SetVector(2, vector2);

            Console.WriteLine(matrix4);

            //Console.WriteLine(matrix4.GetСolumnVector(0));

            matrix4.TransposeMatrix();

            Console.WriteLine(matrix4);

            matrix4.MultiplyByScalar(2);

            Console.WriteLine(matrix4);*/

        }
    }
}
