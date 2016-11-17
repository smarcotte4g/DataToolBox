using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataToolBox
{
    public partial class Splitter : Form
    {
        public Splitter()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Create a file dialog box
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            // Only show .CSV files
            openFileDialog2.Filter = "CSV Files (.csv)|*.csv";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
                try
                {
                    // This will take the file filepath and name
                    string pathNotChanged = openFileDialog2.FileName.ToString();
                    txtFilePath.Text = pathNotChanged;
                }
                catch (Exception ex)
                {
                    // Display messagebox if file is not cleaned
                    MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            // Start Progress bar scrolling
            //pgrbSplitter.Visible = true;
            //btnSplit.Enabled = false;
            //pgrbSplitter.Style = ProgressBarStyle.Marquee;
            //pgrbSplitter.MarqueeAnimationSpeed = 30;
            double parseSize;
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("Please select a file path before continuing!");
            }
            if (cbxDigitalSize.SelectedItem == null)
            {
                MessageBox.Show("Please select the size type before continuing!");
            }
            if (!double.TryParse(txtSize.Text, out parseSize))
            {
                MessageBox.Show("Please make sure the size is in number format!");
            }
            else
            {


                string type = cbxDigitalSize.Text;
                double dResult = ConvertSize(parseSize, type);
                long size = Convert.ToInt64(dResult);
                string filePath = txtFilePath.Text;
                string direcPath = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                SplitCSV(direcPath, filePath, fileName, size);
                //this.pgrbSplitter.Style = ProgressBarStyle.Continuous;
                //this.pgrbSplitter.MarqueeAnimationSpeed = 0;
                //this.pgrbSplitter.Visible = false;
            }

            //Dispaly messagebox if file is cleaned
            if (MessageBox.Show("The files have been split", "", MessageBoxButtons.OK) == DialogResult.OK)
            {
                this.Close();
            }
            else { this.Close(); }
        }

        public static double ConvertSize(double bytes, string type)
        {
            try
            {
                const int CONVERSION_VALUE = 1024;
                //determine what conversion they want
                switch (type)
                {
                    case "Byte":
                        //convert to bytes (default)
                        return bytes;
                    case "Kilobyte":
                        //convert to kilobytes
                        return (bytes * CONVERSION_VALUE);
                    case "Megabyte":
                        //convert to megabytes
                        return (bytes * CalculateSquare(CONVERSION_VALUE));
                    case "Gigabyte":
                        //convert to gigabytes
                        return (bytes * CalculateCube(CONVERSION_VALUE));
                    default:
                        //default
                        return bytes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        /// <summary>
        /// Function to calculate the square of the provided number
        /// </summary>
        /// <param name="number">Int32 -> Number to be squared</param>
        /// <returns>Double -> THe provided number squared</returns>
        /// <remarks></remarks>
        public static double CalculateSquare(Int32 number)
        {
            return Math.Pow(number, 2);
        }


        /// <summary>
        /// Function to calculate the cube of the provided number
        /// </summary>
        /// <param name="number">Int32 -> Number to be cubed</param>
        /// <returns>Double -> THe provided number cubed</returns>
        /// <remarks></remarks>
        public static double CalculateCube(Int32 number)
        {
            return Math.Pow(number, 3);
        }
        public static void SplitCSV(string direcPath, string FilePath, string FileName, long size)
        {
            
            Directory.SetCurrentDirectory(direcPath);
            //int size = 15000000;
            int total = 0;
            int num = 0;
            string FirstLine = null;   // header to new file
            var writer = new StreamWriter(GetFileName(FileName, num));
            // Loop through all source lines
            foreach (var line in File.ReadLines(FilePath))
            {
                if (string.IsNullOrEmpty(FirstLine)) FirstLine = line;
                // Length of current line
                int length = line.Length;

                // See if adding this line would exceed the size threshold
                if (total + length >= size)
                {
                    // Create a new file
                    num++;
                    total = 0;
                    writer.Dispose();
                    writer = new StreamWriter(GetFileName(FileName, num));
                    writer.WriteLine(FirstLine);
                    length += FirstLine.Length;
                }

                // Write the line to the current file                
                writer.WriteLine(line);

                // Add length of line in bytes to running size
                total += length;

                // Add size of newlines
                total += Environment.NewLine.Length;
                
            }
            // Dispaly messagebox if file is cleaned
            
            writer.Close();
        }

        private static string GetFileName(string FileName, int num)
        {
            return FileName + num + ".csv";
        }
    }
}
