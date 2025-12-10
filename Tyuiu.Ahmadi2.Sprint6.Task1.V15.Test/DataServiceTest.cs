using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint6.Task1.V15.Lib;

namespace Tyuiu.Ahmadi2.Sprint6.Task1.V15.Test
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
                -60.63, -35.01, -25.18, -1.83, 6.50, 0, 3.32, -16.76, -29.30, -46.86, -69.66
            };
            CollectionAssert.AreEqual(wait, res);
        }
    }
}