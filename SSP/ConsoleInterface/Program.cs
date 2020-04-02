using System;
using System.Collections.Generic;
using System.Numerics;
using IO;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[,] matrixIncedencii =
            {
                {1, 1, 0, 0, 0, 0, 0},
                {1, 0, 1, 0, 0, 0, 0},
                {0, 1, 0, 1, 1, 0, 0},
                {0, 0, 0, 1, 0, 1, 0},
                {0, 0, 1, 0, 0, 1, 1},
                {0, 0, 0, 0, 1, 0, 1}
            };

            //var A = SetNotNull((int?[,]) matrixIncedencii.Clone());

            IFalkersonAlgorithm algorithm = new FalkersonAlgorithm();
            var answerMatrix = algorithm.SearchPathsForStartNode(matrixIncedencii, 0);

            PrintMatrix(answerMatrix);

            var path = algorithm.FindPathToNode(5);
            PrintList(path);
            IMatrixOperations _ops = new MatrixOperations();
            var A = ReadMatrix();
            var D = _ops.Subtraction(_ops.Multiply(_ops.Transpose(A), A),
                _ops.MultiplyNumber(_ops.IdentityMatrix(A.GetLength(0) + 1), 2));
            Console.WriteLine();
            PrintMatrix(D);

            Console.ReadLine();
        }

        private static void PrintList(List<int> path)
        {
            foreach (var item in path)
            {
                Console.Write(item + " ");
            }
        }

        static void PrintMatrix(int?[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(String.Format("{0,3}", matrix[i, j]));
                Console.WriteLine();
            }
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(String.Format("{0,3}", matrix[i, j]));
                Console.WriteLine();
            }
        }

        static int[,] ReadMatrix()
        {
            Console.WriteLine("Enter sizes");
            var sizes = Console.ReadLine();
            var sizesSplited = sizes.Split(" ");
            var width = Convert.ToInt32(sizesSplited[0]);
            var height = Convert.ToInt32(sizesSplited[1]);
            int[,] mat = new int[width, height];
            Console.WriteLine("Enter values");

            for (var i = 0; i < mat.GetLength(0); i++)
            {
                var values = Console.ReadLine();
                var splited = values.Split(" ");
                for (var j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = Convert.ToInt32(splited[j]);
                }

                Console.WriteLine();
            }

            return mat;
        }
        
        static int[,] SetNotNull(int?[,] matrix)
        {
            int[,] mat = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    mat[i, j] = matrix[i, j].GetValueOrDefault();
                }
            }

            return mat;
        }
    }
}