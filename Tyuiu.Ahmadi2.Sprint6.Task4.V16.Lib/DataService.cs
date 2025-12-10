using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task4.V16.Lib
{
    public class DataService :ISprint6Task4V16
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int len = (stopValue - startValue) + 1;
            double[] valueArray = new double[len];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                
                if (Math.Abs(x - 0.4) < 0.000001) 
                {
                    valueArray[count] = 0;
                }
                else
                {
                    double numerator = Math.Cos(x);
                    double denominator = x - 0.4;
                    double term1 = numerator / denominator;
                    double term2 = Math.Sin(x) * 8 * x;
                    double result = term1 + term2 + 2;
                    valueArray[count] = Math.Round(result, 2);
                }
                count++;
            }
            return valueArray;
        }

        public void SaveToFile(string path, int startValue, int stopValue, double[] array)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Табулирование функции F(x) = cos(x)/(x-0.4) + sin(x)*8x + 2");
                writer.WriteLine($"на интервале [{startValue}; {stopValue}] с шагом 1");
                writer.WriteLine("------------------------------------------------");
                writer.WriteLine("   x      F(x)");
                writer.WriteLine("------------------------------------------------");

                int count = 0;
                for (int x = startValue; x <= stopValue; x++)
                {
                    writer.WriteLine($"{x,5}   {array[count],8:F2}");
                    count++;
                }
            }
        }
    }
}