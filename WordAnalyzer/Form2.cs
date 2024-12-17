using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordAnalyzer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public Form2(Dictionary<string, string> results)
        {
            InitializeComponent();
            DisplayResults(results);
        }

        private void DisplayResults(Dictionary<string, string> results)
        {
            StringBuilder resultText = new StringBuilder();

            foreach (var item in results)
            {
                resultText.AppendLine($"{item.Key}: {item.Value}");
            }

            txtResults.Text = resultText.ToString();
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                saveFileDialog.Title = "Save Results As";
                saveFileDialog.FileName = "AnalysisResults.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Save the results as a file
                        File.WriteAllText(saveFileDialog.FileName, txtResults.Text);
                        MessageBox.Show("Results saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
