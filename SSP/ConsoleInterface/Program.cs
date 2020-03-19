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

            List<int> Path = FindPath(answerMatrix, beginNodeIndex, 5);
            Console.ReadLine();
        }
        private List<int> FindPath(int?[,] matrix, int beginNodeIndex, int endNodeIndex)
        {
            List<List<int>> Paths = new List<List<int>>();

                Paths = FindInRow(matrix, Paths, beginNodeIndex);

            return Path;
        }
        int count = 0;
        private List<int> FindInRow(int?[,] matrix, List<List<int>> Paths, int currentRow)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {

                if (matrix[currentRow, i] != null)
                {
                    count++;
                    Paths.Add(new List<int>());
                    Paths[count].Add(currentRow);
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (j != currentRow && matrix[j, i].HasValue)
                        {

                            FindInRow(matrix, Path, j);
                        }
                    }
                }
            }
        }

    }
}
}