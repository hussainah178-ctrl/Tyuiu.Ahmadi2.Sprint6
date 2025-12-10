using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint6.Task7.V1.Lib;
using System.IO;
using System.Text;

namespace Tyuiu.Ahmadi2.Sprint6.Task7.V1.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadAndTransform()
        {
            DataService ds = new DataService();

           
            string path = @"C:\Temp\InPutFileTask7V1.csv";
            string[] csvData =
            {
                "5;-3;10",
                "-2;7;15",
                "8;-5;20",
                "3;4;-6"
            };
            File.WriteAllLines(path, csvData, Encoding.Default);

            // 
            int[,] matrix = ds.LoadMatrix(path);

            
            int[,] transformed = ds.TransformMatrix(matrix);

            
            int[,] expected =
            {
                {5, 1, 10},    
                {-2, 7, 15},   
                {8, 1, 20},   
                {3, 4, -6}     
            };

            
            CollectionAssert.AreEqual(expected, transformed);
        }

        [TestMethod]
        public void ValidSaveToFile()
        {
            DataService ds = new DataService();
            string savePath = @"C:\Temp\OutPutFileTask7.csv";

            int[,] testMatrix =
            {
                {1, 2, 3},
                {4, 5, 6}
            };

            ds.SaveMatrixToFile(savePath, testMatrix);

            Assert.IsTrue(File.Exists(savePath));
        }
    }
}