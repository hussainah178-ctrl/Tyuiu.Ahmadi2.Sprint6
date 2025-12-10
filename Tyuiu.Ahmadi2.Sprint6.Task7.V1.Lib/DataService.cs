using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task7.V1.Lib
{
    public class DataService :ISprint6Task7V1
    {
        public int[,] LoadMatrix(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int rowCount = lines.Length;
            int colCount = lines[0].Split(';').Length;

            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] values = lines[i].Split(';');
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = Convert.ToInt32(values[j]);
                }
            }

            return matrix;
        }

        public int[,] TransformMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] resultMatrix = new int[rows, cols];

            // کپی ماتریس
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = matrix[i, j];
                }
            }

            // تغییر مقادیر منفی در ستون دوم (ایندکس 1) به 1
            for (int i = 0; i < rows; i++)
            {
                if (resultMatrix[i, 1] < 0)
                {
                    resultMatrix[i, 1] = 1;
                }
            }

            return resultMatrix;
        }

        public void SaveMatrixToFile(string path, int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < rows; i++)
                {
                    string line = "";
                    for (int j = 0; j < cols; j++)
                    {
                        line += matrix[i, j];
                        if (j < cols - 1)
                        {
                            line += ";";
                        }
                    }
                    writer.WriteLine(line);
                }
            }
        }

        public int[,] GetMatrix(string path)
        {
            throw new NotImplementedException();
        }
    }
}