using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint6.Task7.V1.Lib;

namespace Tyuiu.Ahmadi2.Sprint6.Task7.V1.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadMatrix()
        {
            DataService ds = new DataService();

            string path = @"C:\Temp\test.csv";
            string[] testData = { "1;2;3", "4;5;6", "7;8;9" };
            System.IO.File.WriteAllLines(path, testData);

            int[,] matrix = ds.LoadMatrix(path);
            int[,] wait = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            CollectionAssert.AreEqual(wait, matrix);
        }

        [TestMethod]
        public void ValidTransformMatrix()
        {
            DataService ds = new DataService();

            int[,] matrix = {
                { 1, -2, 3 },
                { 4, 5, 6 },
                { 7, -8, 9 }
            };

            int[,] result = ds.TransformMatrix(matrix);
            int[,] wait = {
                { 1, 1, 3 },    // -2 → 1
                { 4, 5, 6 },    // 5 بدون تغییر
                { 7, 1, 9 }     // -8 → 1
            };

            CollectionAssert.AreEqual(wait, result);
        }
    }
}