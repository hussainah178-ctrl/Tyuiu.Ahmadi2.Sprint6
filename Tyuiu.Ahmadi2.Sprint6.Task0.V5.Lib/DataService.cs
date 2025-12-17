using System;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Ahmadi2.Sprint6.Task0.V5.Lib
{
    public class DataService : ISprint6Task0V5
    {
        public double Calculate(int x)
        {
            // فرمول صحیح
            double numerator = Math.Pow(1 - x, 2);
            double denominator = -3 * x;
            double result = numerator / denominator;

            // استفاده از Culture با ویرگول به عنوان جداکننده اعشار
            return Math.Round(result, 3);
        }

        public string SaveToFile(int x)
        {
            double result = Calculate(x);

            // ایجاد رشته با Culture روسی (ویرگول به عنوان جداکننده)
            CultureInfo culture = new CultureInfo("ru-RU");
            string resultString = result.ToString("F3", culture);

            // ذخیره در فایل
            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, "OutPutFileTask0.txt");

            // ذخیره با کوتیشن
            string output = $"\"{resultString}\"";
            File.WriteAllText(filePath, output);

            Console.WriteLine($"Результат: {output}");
            Console.WriteLine($"Файл сохранен: {filePath}");

            return output;
        }
    }
}