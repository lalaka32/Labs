using System;
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
            IFalkersonAlgorithm _falkersonAlgorithm = new FalkersonAlgorithm();
            int?[,] answerMatrix = _falkersonAlgorithm.SearchPaths(matrixIncedencii, 1);

            for (int i = 0; i < answerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < answerMatrix.GetLength(1); j++)
                    Console.Write(String.Format("{0,3}", answerMatrix[i, j]));
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}