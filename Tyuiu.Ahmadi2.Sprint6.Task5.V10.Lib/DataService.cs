using System;
using System.IO;
using System.Collections.Generic;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task5.V10.Lib
{
    public class DataService :ISprint6Task5V10
    {
        public double[] LoadFromDataFile(string path)
        {
            List<double> numbers = new List<double>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                   
                    if (double.TryParse(line, out double number))
                    {
                        numbers.Add(Math.Round(number, 3));
                    }
                }
            }

            return numbers.ToArray();
        }

        public double[] GetNonZeroValues(double[] array)
        {
            List<double> nonZeroList = new List<double>();

            foreach (double num in array)
            {
                if (Math.Abs(num) > 0.0001) 
                {
                    nonZeroList.Add(num);
                }
            }

            return nonZeroList.ToArray();
        }
    }
}