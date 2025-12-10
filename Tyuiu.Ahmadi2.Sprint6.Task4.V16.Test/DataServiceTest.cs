using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint6.Task4.V16.Lib;
using System.IO;

namespace Tyuiu.Ahmadi2.Sprint6.Task4.V16.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMassFunction()
        {
            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;
            double[] res = ds.GetMassFunction(startValue, stopValue);
            double[] wait = {
                -42.90, -25.73, -17.64, -0.70, 4.82, 0, 3.45, -10.47, -18.20, -30.10, -46.17
            };
            CollectionAssert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidSaveToFile()
        {
            DataService ds = new DataService();
            string path = @"C:\Temp\OutPutFileTask4V16.txt";
            int startValue = -5;
            int stopValue = 5;
            double[] array = ds.GetMassFunction(startValue, stopValue);

            ds.SaveToFile(path, startValue, stopValue, array);

            Assert.IsTrue(File.Exists(path));
        }
    }
}