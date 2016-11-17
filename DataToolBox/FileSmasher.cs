using RDotNet.NativeLibrary;
using RDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataToolBox
{
    public partial class FileSmasher : Form
    {
        public FileSmasher()
        {
            InitializeComponent();
        }

        private void btnSmash_Click(object sender, EventArgs e)
        {
            string[] allFiles = GetFiles();
            for (int i = 0; i < allFiles.Length; i++ )
            {
                allFiles[i] = string.Format("'{0}'", allFiles[i]);
                allFiles[i] = allFiles[i].Replace("\\", "/");
            }
            //string toDisplay = string.Join(Environment.NewLine, files);
            //MessageBox.Show(toDisplay);

            // Creates the R engine
            REngine engine = REngine.GetInstance();
            // Start the R Engine
            // This adds the R file to a variable for use
            if (!engine.IsRunning)
            {
                engine.Initialize();
            }

            //var Root = @"D:\Program Files\R\R-3.3.1";
            //var envPath = Environment.GetEnvironmentVariable("PATH");
            // AnyCPU and x86 works with i386
            // x64 with x64
            // var arch = "x64"; 
            //var arch = "i386";
            //var rBinPath = Root + @"\bin\" + arch;
            //Environment.SetEnvironmentVariable("PATH", envPath + Path.PathSeparator + rBinPath);
            //Environment.SetEnvironmentVariable("R_LIBS", Root + @"\library");
            //Environment.SetEnvironmentVariable("R_HOME", Root);
            //String PersonalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //Environment.SetEnvironmentVariable("R_LIBS_USER", Root + "/R/win-library/3.0");
            //engine.Evaluate("library(plyr)");

            //var test = Environment.GetEnvironmentVariable("PATH");
            //Environment.GetEnvironmentVariable("R_HOME");
            //engine.Evaluate("library(package = plyr, verbose = TRUE, lib.loc = PATH) \n");

            var FileSmasher = DataToolBox.Properties.Resources.FileSmasher;
            //engine.Evaluate("library('plyr')");
            // Adds the R file to the engine
            engine.Evaluate(FileSmasher);

            MessageBox.Show("Please wait for the next pop-up telling you it is completed.");
            DataFrame smashed = engine.Evaluate(string.Format("FileSmasher({0})", allFiles)).AsDataFrame();

        }
        public static string[] GetFiles()
        {
            string[] fileNames;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = UniversalDataImporter.Properties.Settings.Default.openFilePath;
            openFileDialog1.Filter = "CSV Files (.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            openFileDialog1.CheckFileExists = false;

            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK && openFileDialog1.FileNames.Count() < 501)
                {
                    //UniversalDataImporter.Properties.Settings.Default.openFilePath =
                    //Path.GetDirectoryName(openFileDialog1.FileName);
                    //UniversalDataImporter.Properties.Settings.Default.Save();
                    return fileNames = openFileDialog1.FileNames;
                }
                else if (result == DialogResult.Cancel)
                {
                    return null;
                }
                else
                {
                    if (MessageBox.Show("Too many files were Selected. Would you like to import a folder instead?",
                        "Too many files...", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        return fileNames = GetFilesInFolder();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                return null;
            }
        }

        public static string[] GetFilesInFolder()
        {

            FileInfo[] fileInfo;

            string pathName;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.Desktop;

            DialogResult results = folderBrowserDialog.ShowDialog();

            if (results == DialogResult.OK)
            {
                try
                {
                    pathName = folderBrowserDialog.SelectedPath;

                    DirectoryInfo dir = new DirectoryInfo(pathName);
                    if (dir.Exists)
                    {

                        fileInfo = dir.GetFiles();

                        string[] fileNames = new string[fileInfo.Length];

                        for (int i = 0; i < fileInfo.Length; i++)//this is shit
                        {
                            fileNames[i] = fileInfo[i].FullName;
                        }

                        return fileNames;
                    }
                    else
                    {
                        return null;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    return null;
                }

            }
            else if (results == DialogResult.Cancel)
            {
                return null;
            }
            else { return null; }
        }
    }
}
