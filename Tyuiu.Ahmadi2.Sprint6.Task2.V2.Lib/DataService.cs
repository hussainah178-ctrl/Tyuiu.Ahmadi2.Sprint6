using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task2.V2.Lib
{
    public class DataService :ISprint6Task2V2
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int len = (stopValue - startValue) + 1;
            double[] valueArray = new double[len];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                
                if (3 * x + 0.5 == 0)
                {
                    valueArray[count] = 0;
                }
                else
                {
                    double term1 = Math.Sin(x);
                    double term2 = 2.0 / (3 * x + 0.5);
                    double term3 = 2 * Math.Cos(x) * 2 * x;
                    double result = term1 + term2 - term3;
                    valueArray[count] = Math.Round(result, 2);
                }
                count++;
            }
            return valueArray;
        }
    }
}