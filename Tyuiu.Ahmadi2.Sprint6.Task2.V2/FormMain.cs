using System;
using System.Windows.Forms;
using Tyuiu.Ahmadi2.Sprint6.Task2.V2.Lib;

namespace Tyuiu.Ahmadi2.Sprint6.Task2.V2
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

            // پاک کردن داده‌های قبلی
            dataGridViewResult.Rows.Clear();
            dataGridViewResult.ColumnCount = 2;
            dataGridViewResult.Columns[0].HeaderText = "x";
            dataGridViewResult.Columns[1].HeaderText = "F(x)";

            // پر کردن DataGridView
            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                dataGridViewResult.Rows.Add(x.ToString(), values[count].ToString("F2"));
                count++;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 2 выполнил студент группы ИИПб-23-1 Ахмади Мухаммад Фархад", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}