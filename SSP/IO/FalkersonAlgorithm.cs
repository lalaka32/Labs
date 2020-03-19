using System;
using System.Collections.Generic;

namespace IO
{
    //считаем для всей матрицы, заканчиваем когда все строки использывались
    public class FalkersonAlgorithm : IFalkersonAlgorithm
    {
        public int?[,] SearchPaths(int?[,] matrixIncedencii, int beginNodeIndex)
        {
            ChangeToZeros(matrixIncedencii);
            
            InitializeBeginStep(matrixIncedencii, beginNodeIndex);

            for (var i = 1; i < matrixIncedencii.GetLength(1); i++)
            {
                var rowsForIncrement = GetRowsIndexesOfValue(matrixIncedencii, i);

                if (rowsForIncrement.Count == 0)
                {
                    break;
                }

                IncrementRowsExceptMax(matrixIncedencii, rowsForIncrement);

                SyncColumns(matrixIncedencii);
            }

            return matrixIncedencii;
        }

        private void IncrementRowsExceptMax(int?[,] matrixIncedencii, List<int> rowsForIncrement)
        {
            for (var i = 0; i < matrixIncedencii.GetLength(1); i++)
            {
                var maxValue = 0;
                var maxValueIndex = 0;
                for (var j = 0; j < rowsForIncrement.Count; j++)
                {
                    if (matrixIncedencii[rowsForIncrement[j], i].HasValue && matrixIncedencii[rowsForIncrement[j], i].Value > maxValue)
                    {
                        maxValue = matrixIncedencii[rowsForIncrement[j], i].Value;
                    }
                }

                for (var j = 0; j < rowsForIncrement.Count; j++)
                {
                    if (matrixIncedencii[rowsForIncrement[j], i].HasValue)
                    {
                        matrixIncedencii[rowsForIncrement[j], i] = maxValue + 1;
                    }
                }
            }
        }

        private List<int> GetRowsIndexesOfValue(int?[,] matrixIncedencii, int number)
        {
            var indexes = new List<int>();
            for (var i = 0; i < matrixIncedencii.GetLength(0); i++)
            {
                for (var j = 0; j < matrixIncedencii.GetLength(1); j++)
                {
                    if (matrixIncedencii[i, j].HasValue && matrixIncedencii[i, j].Value == number)
                    {
                        indexes.Add(j);
                    }
                }
            }

            return indexes;
        }

        private void ChangeToZeros(int?[,] matrixIncedencii)
        {
            for (var i = 0; i < matrixIncedencii.GetLength(0); i++)
            {
                for (var j = 0; j < matrixIncedencii.GetLength(1); j++)
                {
                    if (matrixIncedencii[i, j] == 1)
                    {
                        matrixIncedencii[i, j] = 0;
                    }
                    else
                    {
                        matrixIncedencii[i, j] = null;
                    }
                }
            }

        }

        private void InitializeBeginStep(int?[,] matrixIncedencii, int beginNodeIndex)
        {
            for (var j = 0; j < matrixIncedencii.GetLength(1); j++)
            {
                if (matrixIncedencii[beginNodeIndex, j].HasValue)
                {
                    matrixIncedencii[beginNodeIndex, j]++;
                }
            }
            SyncColumns(matrixIncedencii);
        }

        private void SyncColumns(int?[,] matrixIncedencii)
        {
            for (var i = 0; i < matrixIncedencii.GetLength(1); i++)
            {
                var maxValue = 0;
                for (var j = 0; j < matrixIncedencii.GetLength(0); j++)
                {
                    if (matrixIncedencii[j, i].HasValue && matrixIncedencii[j, i].Value > maxValue)
                    {
                        maxValue = matrixIncedencii[j, i].Value;
                    }
                }

                for (var j = 0; j < matrixIncedencii.GetLength(0); j++)
                {
                    if (matrixIncedencii[j, i].HasValue)
                    {
                        matrixIncedencii[j, i] = maxValue;
                    }
                }
            }
        }
    }
}