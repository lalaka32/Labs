using System;
using System.Collections.Generic;

namespace IO
{
    public class FalkersonAlgorithm : IFalkersonAlgorithm
    {
        private int _beginNodeIndex;
        private int?[,] _matrix;

        public int?[,] SearchPathsForStartNode(int?[,] matrixIncedencii, int beginNodeIndex)
        {
            _matrix = matrixIncedencii;
            _beginNodeIndex = beginNodeIndex;
            ChangeToZeros(matrixIncedencii);

            InitializeBeginStep(matrixIncedencii, beginNodeIndex);

            for (var i = 1; i < matrixIncedencii.GetLength(1); i++)
            {
                var rowsForIncrement = GetRowsIndexesOfValue(matrixIncedencii, i);

                if (rowsForIncrement.Count == 0)
                {
                    break;
                }

                SetMaxWhenZeros(matrixIncedencii, rowsForIncrement, i);

                SyncColumns(matrixIncedencii);
            }

            return matrixIncedencii;
        }

        public List<int> FindPathToNode(int endNodeIndex)
        {
            var path = new List<int>();

            var currentNodeIndex = endNodeIndex;

            do
            {
                path.Add(currentNodeIndex);
                var minInRow = int.MaxValue;
                var indexMinInRow = 0;
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[currentNodeIndex, j] < minInRow)
                    {
                        minInRow = _matrix[currentNodeIndex, j].GetValueOrDefault();
                        indexMinInRow = j;
                    }
                }

                for (var k = 0; k < _matrix.GetLength(0); k++)
                {
                    if (_matrix[k, indexMinInRow].HasValue && k != currentNodeIndex)
                    {
                        currentNodeIndex = k;
                        break;
                    }
                }
            } while (currentNodeIndex != _beginNodeIndex);

            path.Add(_beginNodeIndex);
            path.Reverse();

            return path;
        }

        private void SetMaxWhenZeros(int?[,] matrixIncedencii, List<int> rowsForIncrement, int max)
        {
            for (var i = 0; i < matrixIncedencii.GetLength(1); i++)
            {
                for (var j = 0; j < rowsForIncrement.Count; j++)
                {
                    if (matrixIncedencii[rowsForIncrement[j], i].HasValue &&
                        matrixIncedencii[rowsForIncrement[j], i].Value == 0)
                    {
                        matrixIncedencii[rowsForIncrement[j], i] = max + 1;
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
                    if (matrixIncedencii[i, j].HasValue && matrixIncedencii[i, j].Value == number
                                                        && !indexes.Contains(i))
                    {
                        indexes.Add(i);
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
                var maxValueOfColumn = 0;
                for (var j = 0; j < matrixIncedencii.GetLength(0); j++)
                {
                    if (matrixIncedencii[j, i].HasValue && matrixIncedencii[j, i].Value > maxValueOfColumn)
                    {
                        maxValueOfColumn = matrixIncedencii[j, i].Value;
                    }
                }

                for (var j = 0; j < matrixIncedencii.GetLength(0); j++)
                {
                    if (matrixIncedencii[j, i].HasValue)
                    {
                        matrixIncedencii[j, i] = maxValueOfColumn;
                    }
                }
            }
        }
    }
}