using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SharpUpdate
{
    public class SharpUpdater
    {
        private ISharpUpdatable applicationInfo;
        private BackgroundWorker bgWorker;

        public SharpUpdater(ISharpUpdatable applicationInfo)
        {
            this.applicationInfo = applicationInfo;

            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

        }

        public void DoUpdate()
        {
            if (!this.bgWorker.IsBusy)
                this.bgWorker.RunWorkerAsync(this.applicationInfo);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ISharpUpdatable application = (ISharpUpdatable)e.Argument;

            if (!SharpUpdateXML.ExistsOnServer(application.UpdateXmlLocation))
                e.Cancel = true;
            else
                e.Result = SharpUpdateXML.Parse(application.UpdateXmlLocation, application.ApplicationID);
        }

        /// <summary>
        /// If Background worker is not cancelled get the updated XML from the bgWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // If there is a file on the server
            if (!e.Cancelled)
            {
                SharpUpdateXML update = (SharpUpdateXML)e.Result;

                // Check if the update is not null and is a newer version than the current application
                if (update != null && update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version))
                {
                    // Ask to accept the update
                    if (new SharpUpdateAcceptForm(this.applicationInfo, update).ShowDialog(this.applicationInfo.Context) == DialogResult.Yes)
                        this.DownloadUpdate(update); // Do the update
                }
                else
                    MessageBox.Show("You have the latest version already!");
            }
            else
                MessageBox.Show("No update information found!");
        }

        private void DownloadUpdate(SharpUpdateXML update)
        {
            SharpUpdateDownloadForm form = new SharpUpdateDownloadForm(update.Uri, update.MD5, this.applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(this.applicationInfo.Context);

            if(result == DialogResult.OK)
            {
                string currentPath = this.applicationInfo.ApplicationAssembly.Location;
                string newPath = Path.GetDirectoryName(currentPath) + "\\" + update.FileName;

                UpdateApplication(form.TempFilePath, currentPath, newPath, update.LaunchArgs);

                Application.Exit();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("The update download was cancelled.\nThis program has not been modified.", "Update Download Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
            else
            {
                MessageBox.Show("There was a problem downloading the update.\nPlease try again later.", "Update Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
        }

        private void UpdateApplication(string tempFilePath, string currentPath, string newPath, string launchArgs)
        {
            string argument = "/C choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & choice /C Y /N /D Y /T 2 & Move /Y \"{1}\" \"{2}\" & Start \"\" /D \"{3}\" \"{4}\" {5}";

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = String.Format(argument, currentPath, tempFilePath, newPath, Path.GetDirectoryName(newPath), Path.GetFileName(newPath), launchArgs);
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
        }

    }
}
