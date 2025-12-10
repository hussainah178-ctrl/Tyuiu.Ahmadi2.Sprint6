using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint6.Task2.V2.Lib;

namespace Tyuiu.Ahmadi2.Sprint6.Task2.V2.Test
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
                20.15, 16.19, 10.81, 7.84, 4.81, 0, -1.97, -7.24, -12.01, -16.95, -21.51
            };
            CollectionAssert.AreEqual(wait, res);
        }
    }
}