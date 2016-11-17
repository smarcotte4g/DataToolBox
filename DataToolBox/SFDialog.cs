using Microsoft.Win32;
using RDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataToolBox
{
    public partial class SFDialog : Form
    {


        public SFDialog()
        {
            InitializeComponent();
        }

        private void btnReformat_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the path to the Salesforce files.";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                try
                {

                    
                    // This will put the path into a variable
                    string folderNotChanged = fbd.SelectedPath.ToString();
                    // This will change the filepath from "\\" to "/"
                    string folderChanged = folderNotChanged.Replace("\\", "/");
                    // This will add '' around the filepath so R can read it
                    folderChanged = string.Format("'{0}'", folderChanged);

                    // Call the Method that will check the registry to see if R is installed
                    //SettingEnv();

                    // Creates the R engine
                    REngine engine = REngine.GetInstance();
                    REngine.SetEnvironmentVariables();
                    // Start the R Engine
                    // This adds the R file to a variable for use

                    if (!engine.IsRunning)
                    {
                        engine.Initialize();
                    }
                    var SFMaster = DataToolBox.Properties.Resources.SalesforceMaster;


                    // Adds the R file to the engine
                    engine.Evaluate(SFMaster);

                    MessageBox.Show("Please wait for the next pop-up telling you it is completed.");

                    DataFrame createDirec = engine.Evaluate(string.Format("createDirec({0})", folderChanged)).AsDataFrame();

                    if (cbxContacts.Checked && !cbxAccounts.Checked)
                    {
                        if (System.IO.File.Exists(folderNotChanged + "\\Account.csv"))
                        {
                            if (System.IO.File.Exists(folderNotChanged + "\\User.csv"))
                            {
                                DataFrame fCcAncAyUy = engine.Evaluate(string.Format("fCcAncAyUy({0})", folderChanged)).AsDataFrame();
                                // Run Contacts function with account link and user link
                            }
                            else
                            {
                                DataFrame fCcAncAyUn = engine.Evaluate(string.Format("fCcAncAyUn({0})", folderChanged)).AsDataFrame();
                                // Run Contacts function with account link and without user link
                            }
                        }
                        else
                        {
                            if (System.IO.File.Exists(folderNotChanged + "\\User.csv"))
                            {
                                DataFrame fCcAncAnUy = engine.Evaluate(string.Format("fCcAncAnUy({0})", folderChanged)).AsDataFrame();
                                // Run Contacts function without account link and with user link
                            }
                            else
                            {
                                DataFrame fCcAncAnUn = engine.Evaluate(string.Format("fCcAncAnUn({0})", folderChanged)).AsDataFrame();
                                // Run Contacts function without account link and without user link"
                            }
                        }
                    }
                    if (cbxAccounts.Checked && !cbxContacts.Checked)
                    {
                        if (System.IO.File.Exists(folderNotChanged + "\\User.csv"))
                        {
                            DataFrame AcCncUy = engine.Evaluate(string.Format("AcCncUy({0})", folderChanged)).AsDataFrame();
                            // Run Accounts function without contacts link and with user link
                        }
                        else
                        {
                            DataFrame AcCncUn = engine.Evaluate(string.Format("AcCncUn({0})", folderChanged)).AsDataFrame();
                            // Run Accounts function without user link
                        }
                    }
                    else if (cbxContacts.Checked && cbxAccounts.Checked)
                    {
                        if (System.IO.File.Exists(folderNotChanged + "\\User.csv"))
                        {
                            DataFrame CcAcUy = engine.Evaluate(string.Format("CcAcUy({0})", folderChanged)).AsDataFrame();
                            // Run full parser function with user link
                        }
                        else
                        {
                            DataFrame CcAcUn = engine.Evaluate(string.Format("CcAcUn({0})", folderChanged)).AsDataFrame();
                            // Run no user function without user link
                        }
                    }
                    if (cbxLeads.Checked)
                    {
                        if (System.IO.File.Exists(folderNotChanged + "\\User.csv"))
                        {
                            DataFrame LeadUy = engine.Evaluate(string.Format("LeadUy({0})", folderChanged)).AsDataFrame();
                        }
                        else
                        {
                            DataFrame LeadUn = engine.Evaluate(string.Format("LeadUn({0})", folderChanged)).AsDataFrame();
                        }
                    }
                    if (cbxOpportunities.Checked)
                    {
                        if (System.IO.File.Exists(folderNotChanged + "\\User.csv"))
                        {
                            DataFrame OpportunitiesUy = engine.Evaluate(string.Format("OpportunitiesUy({0})", folderChanged)).AsDataFrame();
                        }
                        else
                        {
                            DataFrame OpportunitiesUn = engine.Evaluate(string.Format("OpportunitiesUn({0})", folderChanged)).AsDataFrame();
                        }
                    }
                    if (cbxNotes.Checked)
                    {
                        if (System.IO.File.Exists(folderNotChanged + "\\User.csv"))
                        {
                            DataFrame NoteUy = engine.Evaluate(string.Format("NoteUy({0})", folderChanged)).AsDataFrame();
                        }
                        else
                        {
                            DataFrame NoteUn = engine.Evaluate(string.Format("NoteUn({0})", folderChanged)).AsDataFrame();
                        }
                    }
                    if (cbxTasks.Checked)
                    {
                        if (System.IO.File.Exists(folderNotChanged + "\\User.csv"))
                        {
                            DataFrame TaskUy = engine.Evaluate(string.Format("TaskUy({0})", folderChanged)).AsDataFrame();
                        }
                        else
                        {
                            DataFrame TaskUn = engine.Evaluate(string.Format("TaskUn({0})", folderChanged)).AsDataFrame();
                        }
                    }

                    // Dispaly messagebox if file is cleaned
                    if (MessageBox.Show("The files have been formatted", "", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        this.Close();
                    }
                    else { this.Close(); }
                }
                catch (Exception ex)
                {
                    // Display messagebox if file is not cleaned
                    MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

        }

        // Methods
        private static void SettingEnv()
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\R-core\R");
            string rPath = (string)registryKey.GetValue("InstallPath");
            string rVersion = (string)registryKey.GetValue("Current Version");
            registryKey.Dispose();
        }

    }
}
