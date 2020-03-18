namespace IO
{
    public interface IFalkersonAlgorithm
    {
        int?[,] SearchPaths(int?[,] matrixIncedencii, int beginNodeIndex);
    }
}