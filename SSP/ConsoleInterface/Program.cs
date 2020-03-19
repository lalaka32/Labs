using System;
using System.Collections.Generic;
using IO;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[,] matrixIncedencii = {
                {1, 1, 0, 0, 0, 0, 0},
                {1, 0, 1, 0, 0, 0, 0},
                {0, 1, 0, 1, 1, 0, 0},
                {0, 0, 0, 1, 0, 1, 0},
                {0, 0, 1, 0, 0, 1, 1},
                {0, 0, 0, 0, 1, 0, 1}
            };
            int beginNodeIndex = 0;

            IFalkersonAlgorithm _falkersonAlgorithm = new FalkersonAlgorithm();
            int?[,] answerMatrix = _falkersonAlgorithm.SearchPaths(matrixIncedencii, beginNodeIndex);

            for (int i = 0; i < answerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < answerMatrix.GetLength(1); j++)
                    Console.Write(String.Format("{0,3}", answerMatrix[i, j]));
                Console.WriteLine();
            }
            List<int> Path = new List<int>();

            FindPath(answerMatrix, beginNodeIndex, 5);
            foreach (var item in Path)
            {
                Console.Write(item + " ");
            }


            List<int> FindPath(int?[,] matrix, int startNodeIndex, int endNodeIndex)
            {

                int i = endNodeIndex;

                do
                {
                    Path.Add(i+1);
                    int minInRow = int.MaxValue;
                    int indexMinInRow = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {

                        if (matrix[i, j] < minInRow)
                        {
                            minInRow = matrix[i, j].GetValueOrDefault();
                            indexMinInRow = j;
                        }
                    }

                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        if (matrix[k, indexMinInRow].HasValue && k != i)
                        {
                            i = k;
                            break;
                        }
                    }
                }
                while (i != startNodeIndex);
                Path.Add(1);
                Path.Reverse();

                return Path;
            }

            Console.ReadLine();
        }
    }
}