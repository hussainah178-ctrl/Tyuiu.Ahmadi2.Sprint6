using System;
using System.Windows.Forms;
using Tyuiu.Ahmadi2.Sprint6.Task0.V5.Lib;

namespace Tyuiu.Ahmadi2.Sprint6.Task0.V5
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
            int x = 5;
            double result = ds.Calculate(x);
            textBoxResult.Text = result.ToString("F3");
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 0 выполнил студент группы ИИПб-23-1 Ахмади Мухаммад Фархад", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}