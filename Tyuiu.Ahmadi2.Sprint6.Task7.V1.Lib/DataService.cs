using System;
using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task7.V1.Lib
{
    public class DataService :ISprint6Task7V1
    {
        public int[,] LoadMatrix(string path)
        {
            string[] lines = File.ReadAllLines(path, Encoding.Default);
            int rowCount = lines.Length;
            int colCount = lines[0].Split(';').Length;

            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] values = lines[i].Split(';');

                for (int j = 0; j < colCount; j++)
                {
                    if (int.TryParse(values[j], out int number))
                    {
                        matrix[i, j] = number;
                    }
                    else
                    {
                        matrix[i, j] = 0; 
                    }
                }
            }

            return matrix;
        }

        public int[,] TransformMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            
            int[,] result = (int[,])matrix.Clone();

           
            for (int i = 0; i < rows; i++)
            {
                if (cols > 1 && result[i, 1] < 0) 
                {
                    result[i, 1] = 1;
                }
            }

            return result;
        }

        public void SaveMatrixToFile(string path, int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            using (StreamWriter writer = new StreamWriter(path, false, Encoding.Default))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.Write(matrix[i, j]);
                        if (j < cols - 1)
                        {
                            writer.Write(";");
                        }
                    }
                    writer.WriteLine();
                }
            }
        }

        public int[,] GetMatrix(string path)
        {
            throw new NotImplementedException();
        }
    }
}