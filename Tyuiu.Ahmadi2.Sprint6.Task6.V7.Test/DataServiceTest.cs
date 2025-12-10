using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint6.Task6.V7.Lib;
using System.IO;

namespace Tyuiu.Ahmadi2.Sprint6.Task6.V7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCollectTextFromFile()
        {
            DataService ds = new DataService();

            
            string path = @"C:\Temp\InPutFileTask6V7.txt";
            string[] testData =
            {
                "Это первая строка с несколькими словами",
                "Вторая строка тоже имеет слова",
                "Третья строка текста для проверки",
                "Четвертая",
                "Пятая строка с достаточным количеством"
            };
            File.WriteAllLines(path, testData);

            string res = ds.CollectTextFromFile(path);
            string wait = "строка строка с"; 

            Assert.AreEqual(wait, res);
        }
    }
}