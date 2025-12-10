using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint6.Task0.V5.Lib;

namespace Tyuiu.Ahmadi2.Sprint6.Task0.V5.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate()
        {
            DataService ds = new DataService();
            int x = 5;
            double res = ds.Calculate(x);
            double wait = -129.5; 
            wait = -114.5;
            Assert.AreEqual(wait, res);
        }
    }
}