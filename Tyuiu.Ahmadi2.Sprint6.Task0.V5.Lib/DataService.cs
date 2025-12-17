using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task0.V5.Lib
{
    public class DataService : ISprint6Task0V5
    {
        public double Calculate(int x)
        {
            // فرمول صحیح: y(x) = (1 - x)^2 / (-3x)
            if (x == 0)
                throw new DivideByZeroException("x نمی‌تواند صفر باشد");

            double numerator = Math.Pow(1 - x, 2);
            double denominator = -3 * x;
            double result = numerator / denominator;

            return Math.Round(result, 3);
        }

        // متد برای ذخیره در فایل
        public void SaveToFile(int x)
        {
            double result = Calculate(x);

            // ایجاد مسیر فایل
            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, "OutPutFileTask0.txt");

            // ذخیره نتیجه در فایل
            File.WriteAllText(filePath, result.ToString("F3"));

            // چاپ در کنسول
            Console.WriteLine($"Результат: {result:F3}");
            Console.WriteLine($"Файл сохранен: {filePath}");
        }
    }
}