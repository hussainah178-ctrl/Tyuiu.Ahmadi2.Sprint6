using System;
using System.Windows.Forms;
using Tyuiu.Ahmadi2.Sprint6.Task3.V12.Lib;

namespace Tyuiu.Ahmadi2.Sprint6.Task3.V12
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
            dataGridViewInput.RowCount = 5;
            dataGridViewInput.ColumnCount = 5;
            dataGridViewOutput.RowCount = 5;
            dataGridViewOutput.ColumnCount = 5;

            
            for (int i = 0; i < 5; i++)
            {
                dataGridViewInput.Columns[i].Width = 50;
                dataGridViewOutput.Columns[i].Width = 50;
            }

            
            int[,] matrix = new int[5, 5] {
                { -6, -13, -1, -7, 10 },
                { 14, -18, 18, 1, 11 },
                { -2, -17, -15, -10, -8 },
                { 19, -4, -6, -11, 8 },
                { -17, 17, 14, 13, 19 }
            };

            // پر کردن dataGridViewInput
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dataGridViewInput.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();

           
            int[,] matrix = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = Convert.ToInt32(dataGridViewInput.Rows[i].Cells[j].Value);
                }
            }

            
            int[,] resultMatrix = ds.Calculate(matrix);

           
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dataGridViewOutput.Rows[i].Cells[j].Value = resultMatrix[i, j];
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 3 выполнил студент группы ИИПб-23-1 Ахмади Мухаммад Фархад", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}