using System;
using IO;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[,] matrixIncedencii = {
                {1, 1, 0, 0, 0, 0, 0}
            };
            IFalkersonAlgorithm _falkersonAlgorithm = new FalkersonAlgorithm();
            _falkersonAlgorithm.SearchPaths(matrixIncedencii, 1);
        }
    }
}