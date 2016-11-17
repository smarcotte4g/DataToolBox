using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SharpUpdate
{
    /// <summary>
    /// Form that downloads update
    /// </summary>
    internal partial class SharpUpdateDownloadForm : Form
    {
        /// <summary>
        /// The web client to download the update
        /// </summary>
        private WebClient webClient;

        /// <summary>
        /// The thread to hash the file on
        /// </summary>
        private BackgroundWorker bgWorker;

        /// <summary>
        /// A temp file name to download to
        /// </summary>
        private string tempFile;

        /// <summary>
        /// The MD5 hash of the file to download
        /// </summary>
        private string md5;

        /// <summary>
        /// Gets the temp file path for the downloaded file
        /// </summary>
        internal string TempFilePath
        {
            get { return this.tempFile; }
        }

        /// <summary>
        /// Creates a new SharpUpdateDownloadForm
        /// </summary>
        /// <param name="location"></param>
        /// <param name="md5"></param>
        /// <param name="programIcon"></param>
        internal SharpUpdateDownloadForm(Uri location, string md5, Icon programIcon)
        {
            InitializeComponent();

            if (programIcon != null)
                this.Icon = programIcon;

            // Sets the temp file name and creates new 0-byte file
            tempFile = Path.GetTempFileName();

            this.md5 = md5;

            webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);

            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            try { webClient.DownloadFileAsync(location, this.tempFile); }
            catch { this.DialogResult = DialogResult.No; this.Close(); }
        }

        /// <summary>
        /// Update the label and progrss bar by how much is downloaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            this.lblProgress.Text = String.Format("Downloaded {0} of {1}", FormatBytes(e.BytesReceived, 1, true), FormatBytes(e.TotalBytesToReceive, 1, true));
        }

        /// <summary>
        /// Format bytes into either B, KB, MB, or GB depending on file size
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="decimalPlaces"></param>
        /// <param name="showByteType"></param>
        /// <returns></returns>
        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = "B";

            if(newBytes > 1024 && newBytes < 1048567)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                newBytes /= 1073741824;
                byteType = "GB";
            }

            if (decimalPlaces > 0)
                formatString += ":0.";

            for (int i = 0; i < decimalPlaces; i++)
                formatString += "0";

            formatString += "}";

            if (showByteType)
                formatString += byteType;

            return String.Format(formatString, newBytes);
        }

        /// <summary>
        /// This will happen when the file is done downloading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else if (e.Cancelled)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {
                lblProgress.Text = "Verifying Download...";
                progressBar.Style = ProgressBarStyle.Marquee;

                bgWorker.RunWorkerAsync(new string[] { this.tempFile, this.md5 });
            }
        }

        /// <summary>
        /// Pass the argument as string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string file = ((string[])e.Argument)[0];
            string updateMD5 = ((string[])e.Argument)[1];

            // Hash the file and compare to the hash in the update xml
            if (Hasher.HashFile(file, HashType.MD5).ToUpper() != updateMD5.ToUpper())
                e.Result = DialogResult.No;
            else
                e.Result = DialogResult.OK;
        }

        /// <summary>
        /// After bgWorker_DoWork is done working
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = (DialogResult)e.Result;
            this.Close();
        }

        /// <summary>
        /// What happens when the form is closed during update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SharpUpdateDownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(webClient.IsBusy)
            {
                webClient.CancelAsync();
                this.DialogResult = DialogResult.Abort;
            }
            
            if(bgWorker.IsBusy)
            {
                bgWorker.CancelAsync();
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
