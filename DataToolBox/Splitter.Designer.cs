namespace DataToolBox
{
    partial class Splitter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splitter));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cbxDigitalSize = new System.Windows.Forms.ComboBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.lblBrowse = new System.Windows.Forms.Label();
            this.lblSizeType = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.pgrbSplitter = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(116, 67);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbxDigitalSize
            // 
            this.cbxDigitalSize.FormattingEnabled = true;
            this.cbxDigitalSize.Items.AddRange(new object[] {
            "Byte",
            "Kilobyte",
            "Megabyte",
            "Gigabyte"});
            this.cbxDigitalSize.Location = new System.Drawing.Point(95, 124);
            this.cbxDigitalSize.Name = "cbxDigitalSize";
            this.cbxDigitalSize.Size = new System.Drawing.Size(121, 21);
            this.cbxDigitalSize.TabIndex = 2;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(51, 39);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(217, 22);
            this.txtFilePath.TabIndex = 3;
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(116, 229);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 4;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // lblBrowse
            // 
            this.lblBrowse.AutoSize = true;
            this.lblBrowse.Location = new System.Drawing.Point(48, 23);
            this.lblBrowse.Name = "lblBrowse";
            this.lblBrowse.Size = new System.Drawing.Size(102, 13);
            this.lblBrowse.TabIndex = 5;
            this.lblBrowse.Text = "Browse for the file";
            // 
            // lblSizeType
            // 
            this.lblSizeType.AutoSize = true;
            this.lblSizeType.Location = new System.Drawing.Point(92, 108);
            this.lblSizeType.Name = "lblSizeType";
            this.lblSizeType.Size = new System.Drawing.Size(104, 13);
            this.lblSizeType.TabIndex = 6;
            this.lblSizeType.Text = "Select the size type";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(95, 184);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(121, 22);
            this.txtSize.TabIndex = 7;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(92, 168);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(76, 13);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "Enter the size";
            // 
            // pgrbSplitter
            // 
            this.pgrbSplitter.Location = new System.Drawing.Point(12, 256);
            this.pgrbSplitter.Name = "pgrbSplitter";
            this.pgrbSplitter.Size = new System.Drawing.Size(302, 23);
            this.pgrbSplitter.TabIndex = 9;
            this.pgrbSplitter.Visible = false;
            // 
            // Splitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 291);
            this.Controls.Add(this.pgrbSplitter);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSizeType);
            this.Controls.Add(this.lblBrowse);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.cbxDigitalSize);
            this.Controls.Add(this.btnBrowse);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splitter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CSV File Splitter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cbxDigitalSize;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Label lblBrowse;
        private System.Windows.Forms.Label lblSizeType;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ProgressBar pgrbSplitter;
    }
}