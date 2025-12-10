namespace Tyuiu.Ahmadi2.Sprint6.Task3.V12.Lib
{
    public class DataService
    {
        public int[,] Calculate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            
            int[,] resultMatrix = (int[,])matrix.Clone();

            
            for (int j = 0; j < columns; j++)
            {
                if (resultMatrix[0, j] % 2 == 0)
                {
                    resultMatrix[0, j] = 0;
                }
            }

            return resultMatrix;
        }
    }
}