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
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}