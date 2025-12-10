using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.Ahmadi2.Sprint6.Task5.V10.Lib;
using System.IO;

namespace Tyuiu.Ahmadi2.Sprint6.Task5.V10
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Выберите файл с данными",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                textBoxPath.Text = path;

                try
                {
                    DataService ds = new DataService();
                    double[] allValues = ds.LoadFromDataFile(path);
                    double[] nonZeroValues = ds.GetNonZeroValues(allValues);

                    
                    DisplayDataInGrid(dataGridViewAll, allValues, "Все значения");

                   
                    DisplayDataInGrid(dataGridViewNonZero, nonZeroValues, "Значения не равные 0");

                    
                    DrawChart(chartValues, nonZeroValues);

                    
                    labelInfo.Text = $"Всего значений: {allValues.Length} | Не равных 0: {nonZeroValues.Length}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayDataInGrid(DataGridView grid, double[] values, string title)
        {
            grid.Rows.Clear();
            grid.ColumnCount = 2;
            grid.Columns[0].HeaderText = "№";
            grid.Columns[1].HeaderText = "Значение";
            grid.Columns[0].Width = 50;
            grid.Columns[1].Width = 100;

            for (int i = 0; i < values.Length; i++)
            {
                grid.Rows.Add(i + 1, values[i].ToString("F3"));
            }

            
            if (grid == dataGridViewAll)
                labelAll.Text = title;
            else
                labelNonZero.Text = title;
        }

        private void DrawChart(Chart chart, double[] values)
        {
            chart.Series[0].Points.Clear();
            chart.ChartAreas[0].AxisX.Title = "Номер элемента";
            chart.ChartAreas[0].AxisY.Title = "Значение";
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].Name = "Значения (не равные 0)";

            for (int i = 0; i < values.Length; i++)
            {
                chart.Series[0].Points.AddXY(i + 1, values[i]);
                chart.Series[0].Points[i].Label = values[i].ToString("F3");
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 5 выполнил студент группы ИИПб-23-1 Ахмади Мухаммад Фархад",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}