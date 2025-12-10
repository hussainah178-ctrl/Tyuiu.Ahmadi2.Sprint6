using System;
using System.Windows.Forms;
using Tyuiu.Ahmadi2.Sprint6.Task1.V15.Lib;

namespace Tyuiu.Ahmadi2.Sprint6.Task1.V15
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;

            double[] values = ds.GetMassFunction(startValue, stopValue);

            textBoxResult.Text = "Результаты табулирования функции F(x) на интервале [-5; 5] с шагом 1:\r\n";
            textBoxResult.AppendText("------------------------------------------------------------\r\n");
            textBoxResult.AppendText("    x          F(x)\r\n");
            textBoxResult.AppendText("------------------------------------------------------------\r\n");

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                textBoxResult.AppendText($"   {x,3}        {values[count],8:F2}\r\n");
                count++;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 1 выполнил студент группы ИИПб-23-1 Ахмади Мухаммад Фархад", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}