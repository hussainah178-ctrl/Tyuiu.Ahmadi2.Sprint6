using System;
using System.Windows.Forms;
using System.IO;
using Tyuiu.Ahmadi2.Sprint6.Task7.V1.Lib;

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
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите CSV файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    textBoxPath.Text = path;

                    DataService ds = new DataService();


                    originalMatrix = ds.LoadMatrix(path);

                    
                    DisplayMatrix(dataGridViewIn, originalMatrix);

                    
                    transformedMatrix = ds.TransformMatrix(originalMatrix);

                    
                    DisplayMatrix(dataGridViewOut, transformedMatrix);

                    buttonSaveFile.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayMatrix(DataGridView grid, int[,] matrix)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            
            for (int j = 0; j < cols; j++)
            {
                grid.Columns.Add($"Column{j}", $"Столбец {j + 1}");
            }

            
            for (int i = 0; i < rows; i++)
            {
                grid.Rows.Add();
                for (int j = 0; j < cols; j++)
                {
                    grid.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить результат";
                saveFileDialog.FileName = "OutPutFileTask7.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataService ds = new DataService();
                    ds.SaveMatrixToFile(saveFileDialog.FileName, transformedMatrix);

                    MessageBox.Show("Файл успешно сохранен: " + saveFileDialog.FileName,
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 7 выполнил студент группы ИИПб-23-1 Ахмади Мухаммад Фархад",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}