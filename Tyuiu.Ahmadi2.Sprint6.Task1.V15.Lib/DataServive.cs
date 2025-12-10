using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task1.V15.Lib
{
    public class DataService :ISprint6Task1V15
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int len = (stopValue - startValue) + 1;
            double[] valueArray = new double[len];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                
                if (x - 0.7 == 0)
                {
                    valueArray[count] = 0;
                }
                else
                {
                    double numerator = Math.Cos(x);
                    double denominator = x - 0.7;
                    double term1 = numerator / denominator;
                    double term2 = Math.Sin(x) * 12 * x;
                    double result = term1 - term2 + 2;
                    valueArray[count] = Math.Round(result, 2);   
                }
                count++;
            }
            return valueArray;
        }
    }
}