using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint6.Task5.V10.Lib;
using System.IO;

namespace Tyuiu.Ahmadi2.Sprint6.Task5.V10.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            DataService ds = new DataService();

            
            string path = @"C:\Temp\InPutFileTask5V10.txt";
            string[] testData = { "5.1234", "-3.4567", "0", "7.8912", "0", "-1.2345" };
            File.WriteAllLines(path, testData);

            double[] res = ds.LoadFromDataFile(path);
            double[] wait = { 5.123, -3.457, 0, 7.891, 0, -1.235 };

            CollectionAssert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidGetNonZeroValues()
        {
            DataService ds = new DataService();

            double[] input = { 5.123, -3.457, 0, 7.891, 0, -1.235 };
            double[] res = ds.GetNonZeroValues(input);
            double[] wait = { 5.123, -3.457, 7.891, -1.235 };

            CollectionAssert.AreEqual(wait, res);
        }
    }
}