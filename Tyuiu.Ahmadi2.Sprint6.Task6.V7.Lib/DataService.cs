using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task6.V7.Lib
{
    public class DataService : ISprint6Task6V7
    {
        public string CollectTextFromFile(string path)
        {
            string result = "";

            try
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    
                    if (words.Length >= 3)
                    {
                        result += words[2] + " ";
                    }
                }

                
                if (result.Length > 0)
                {
                    result = result.TrimEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении файла: " + ex.Message);
            }

            return result;
        }
    }
}