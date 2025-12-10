using System;
using System.Windows.Forms;
using Tyuiu.Ahmadi2.Sprint6.Task7.V1.Lib;
using System.IO;
using System.Text;

namespace Tyuiu.Ahmadi2.Sprint6.Task7.V1
{
    public partial class FormMain : Form
    {
        private int[,] originalMatrix;
        private int[,] transformedMatrix;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*",
                Title = "Выберите CSV файл с матрицей",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                textBoxPath.Text = path;

                try
                {
                    DataService ds = new DataService();

                    
                    originalMatrix = ds.LoadMatrix(path);

                    
                    DisplayMatrixInGrid(dataGridViewIn, originalMatrix, "Исходная матрица");

                    
                    transformedMatrix = ds.TransformMatrix(originalMatrix);

                   
                    DisplayMatrixInGrid(dataGridViewOut, transformedMatrix, "Матрица после преобразования");

                   
                    buttonSaveFile.Enabled = true;

                    
                    labelInfo.Text = $"Матрица загружена: {originalMatrix.GetLength(0)}x{originalMatrix.GetLength(1)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayMatrixInGrid(DataGridView grid, int[,] matrix, string title)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            
            for (int j = 0; j < cols; j++)
            {
                grid.Columns.Add($"col{j}", $"Столбец {j + 1}");
                grid.Columns[j].Width = 60;
            }

            
            for (int i = 0; i < rows; i++)
            {
                grid.Rows.Add();
                for (int j = 0; j < cols; j++)
                {
                    grid.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }

            
            if (grid == dataGridViewIn)
                labelInput.Text = title;
            else
                labelOutput.Text = title;
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            if (transformedMatrix == null)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала загрузите файл.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*",
                Title = "Сохранить результат",
                FileName = "OutPutFileTask7.csv",
                DefaultExt = "csv",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataService ds = new DataService();
                    ds.SaveMatrixToFile(saveFileDialog.FileName, transformedMatrix);

                    MessageBox.Show($"Файл успешно сохранен:\n{saveFileDialog.FileName}",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 7 выполнил студент группы ИИПб-23-1 Ахмади Мухаммад Фархад",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}