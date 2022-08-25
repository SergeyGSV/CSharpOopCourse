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
        public double[,] MatrixPoints { get; set; }

        public Matrix(int n, int m) : base(0)
        {
            MatrixPoints = new double[n, m];
        }

        public Matrix(Matrix[,] vectorsMatrix) : base(0)
        {
            MatrixPoints = new double[vectorsMatrix.GetLength(0), vectorsMatrix.GetLength(1)];
        }

        public Matrix(double[,] vectorsArray) : base(0)
        {
        }

        public Matrix(Vector[] vector) : base(0)
        {
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