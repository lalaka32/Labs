namespace IO
{
    public interface IMatrixOperations
    {
        int[,] Multiply(int[,] first, int[,] second);
        
        int[,] MultiplyNumber(int[,] first, int second);
        
        int[,] Subtraction(int[,] first, int[,] second);

        int[,] Transpose(int[,] first);
        
        int[,] IdentityMatrix(int size);
    }
}