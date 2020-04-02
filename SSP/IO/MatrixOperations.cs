using System;

namespace IO
{
    public class MatrixOperations : IMatrixOperations
    {
        public int[,] Multiply(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
            {
                throw new Exception(
                    "Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            var matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixB.GetLength(1); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.GetLength(1); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }

        public int[,] MultiplyNumber(int[,] first, int second)
        {
            int[,] mat = new int[first.GetLength(0), first.GetLength(1)];
            for (int i = 0; i < first.GetLength(0); i++)
            {
                for (int j = 0; j < first.GetLength(1); j++)
                {
                    mat[i, j] = first[i, j] * second;
                }
            }

            return mat;
        }

        public int[,] Subtraction(int[,] first, int[,] second)
        {
            int[,] res = new int[first.GetLength(0), first.GetLength(1)];
            for (int row = 0; row < first.GetLength(0); row++)
            {
                for (int col = 0; col < first.GetLength(1); col++)
                {
                    res[row, col] = first[row, col] + second[row, col];
                }
            }
            return res;
        }

        public int[,] Transpose(int[,] first)
        {
            int[,] trans = new int[first.GetLength(1), first.GetLength(0)];
            for (int i = 1; i < first.GetLength(0); i++)
            {
                for (int j = 0; j <  first.GetLength(1); j++)
                {
                    trans[j, i] = first[i, j];
                }
            }

            return trans;
        }

        public int[,] IdentityMatrix(int size)
        {
            var E = new int[size, size];

            for (int i = 0; i < E.GetLength(0); i++)
            {
                E[i, i] = 1;
            }

            return E;
        }
    }
}