using RDotNet;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpUpdate;
using System.Reflection;
using Microsoft.Win32;

namespace DataToolBox
{
    public partial class Form1 : Form, ISharpUpdatable
    {
        
        
        private SharpUpdater updater;

        public Form1()
        {
            InitializeComponent();
            updater = new SharpUpdater(this);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit); 
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
            DisposeREngine();
        }
        private static void DisposeREngine()
        {
            REngine engine = REngine.GetInstance();
            engine.Dispose();
        }
        private static void UpdateLog()
        {
            MessageBox.Show(string.Format("V 0.1.0.0 Remove Blank Columns Functionality\n"
                + "V 0.1.2.0 Salesforce Formatter Functionality\n"
                + "V 0.1.3.0 Cleaned up code and performance enhancement’s\n"
                + "V 0.1.4.0 Fixed issue with needing to shutdown program to run multiple functions\n"
                + "V 0.1.5.0 Salesforce Formatter completely reworked to have more options\n"
                + "V 0.1.6.0 Added a CSV Splitter in C#\n"
                + "V 0.1.6.1 Added File Encoding to the 'Remove Blank Columns' Function"));
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            CSVScrubbing();
        }

        /// <summary>
        /// Navigation Tool Bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // When Exit navigation button is clicked
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // When About navigation button is clicked
        // Show messagebox with about info
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("V {0}\n\nApplication is built using C# and R.\nThe Purpose of this application is to\n"
                + "make the repetative tasks that Data Migration\nExperts do day to day easier.\n\n"
                + "Contact Shane Marcotte with any issues.", this.ApplicationAssembly.GetName().Version.ToString()));
        }

        // When Update navigation button is clicked
        // start ISharpUpdater
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();
        }

        private void updateLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateLog();
        }

        private void btnSFFormat_Click(object sender, EventArgs e)
        {
            SFDialog sfDialog = new SFDialog();
            sfDialog.ShowDialog();
        }
        private void btnCSVSplitter_Click(object sender, EventArgs e)
        {
            Splitter splitter = new Splitter();
            splitter.ShowDialog();
        }
        private void btnFileSmasher_Click(object sender, EventArgs e)
        {
            FileSmasher filesmasher = new FileSmasher();
            filesmasher.ShowDialog();
        }

        // Methods
        private static void CSVScrubbing()
        {
            // Creates the R engine
            REngine engine = REngine.GetInstance();
            if (!engine.IsRunning)
            {
                engine.Initialize();
            }
            // Create a file dialog box
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // Only show .CSV files
            openFileDialog1.Filter = "CSV Files (.csv)|*.csv";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                try
                {
                    // This will take the file filepath and name
                    string pathNotChanged = openFileDialog1.FileName.ToString();
                    // This will take just the filename
                    string fileName = Path.GetFileName(pathNotChanged);
                    // This will change the filepath from "\\" to "/"
                    string pathChanged = pathNotChanged.Replace("\\", "/");
                    // This will add '' around the filepath so R can read it
                    pathChanged = string.Format("'{0}'", pathChanged);
                    // This will add '' around the filename so R can read it
                    fileName = string.Format("'{0}'", fileName);

                    // Call the Method that will check the registry to see if R is installed
                    //SettingEnv();

                    // This adds the R file to a variable for use
                    var CSVScrubber = DataToolBox.Properties.Resources.CSVScrubber;
                    // Adds the R file to the engine
                    engine.Evaluate(CSVScrubber);
                    // Inputs arguments from file dialog box and runs R method
                    // If any errors come up they will be caught by try catch and show error
                    DataFrame dataframe = engine.Evaluate(string.Format("csvScrubber({0}, {1})", pathChanged, fileName)).AsDataFrame();
                    // Dispaly messagebox if file is cleaned
                    MessageBox.Show("File was cleaned Sucessfully! It is located in the folder ");
                }
                catch (Exception ex)
                {
                    // Display messagebox if file is not cleaned
                    MessageBox.Show("Could not read file from disk. Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
        }


        private static void SettingEnv()
        {
            // STILL BROKED****************************
            // Oldest supported R version
            string supportVersion = "3.2.3";
            // Checks the registry to see if R is installed
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\R-core\R");
            // Finds the path to R
            string rPath = (string)registryKey.GetValue("InstallPath");
            // Finds the R Version number
            string rVersion = (string)registryKey.GetValue("Current Version");
            // Compares oldest version to current user version
            var result = rVersion.CompareTo(supportVersion);
            // If the user version is greater than supported version run normally
            if (result > 0)
            {
                registryKey.Dispose();
            }
                // If user version is less than supported version kill porgram
            else if (result < 0)
            {
                MessageBox.Show("Either your R version is older than 3.2.3 or you do not have R installed. Please install the latest version of R.", "", MessageBoxButtons.OK);
                registryKey.Dispose();
                System.Environment.Exit(0);
            }
                // Continue program
            else
                registryKey.Dispose();
            return;
        }

        // getters
        public string ApplicationName
        {
            get { return "DataToolBox"; }
        }

        public string ApplicationID
        {
            get { return "DataToolBox"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("https://raw.githubusercontent.com/smarcotte4g/DataToolBox/master/update.xml"); }
        }

        public Form Context
        {
            get { return this; }
        }
        

        

    }
}
