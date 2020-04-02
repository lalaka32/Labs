using System.Collections.Generic;

namespace IO
{
    public interface IFalkersonAlgorithm
    {
        int?[,] SearchPathsForStartNode(int?[,] matrixIncedencii, int beginNodeIndex);
        List<int> FindPathToNode(int endNodeIndex);
    }
}