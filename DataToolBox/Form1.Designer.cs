namespace DataToolBox
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnParse = new System.Windows.Forms.Button();
            this.lblDBC = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSFFormat = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCSVSplitter = new System.Windows.Forms.Button();
            this.btnFileSmasher = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(76, 103);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(87, 42);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Remove Blank Columns";
            this.toolTip1.SetToolTip(this.btnParse, "This action will remove all columns with no data from 1 file.");
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // lblDBC
            // 
            this.lblDBC.AutoSize = true;
            this.lblDBC.Location = new System.Drawing.Point(106, 55);
            this.lblDBC.Name = "lblDBC";
            this.lblDBC.Size = new System.Drawing.Size(136, 13);
            this.lblDBC.TabIndex = 2;
            this.lblDBC.Text = "What would you like to do?";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(359, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.updateLogToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // updateLogToolStripMenuItem
            // 
            this.updateLogToolStripMenuItem.Name = "updateLogToolStripMenuItem";
            this.updateLogToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.updateLogToolStripMenuItem.Text = "Update Log";
            this.updateLogToolStripMenuItem.Click += new System.EventHandler(this.updateLogToolStripMenuItem_Click);
            // 
            // btnSFFormat
            // 
            this.btnSFFormat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSFFormat.Location = new System.Drawing.Point(189, 103);
            this.btnSFFormat.Name = "btnSFFormat";
            this.btnSFFormat.Size = new System.Drawing.Size(87, 42);
            this.btnSFFormat.TabIndex = 4;
            this.btnSFFormat.Text = "Salesforce Formatter";
            this.toolTip1.SetToolTip(this.btnSFFormat, "This action will format an entire Salesforce data set.");
            this.btnSFFormat.UseVisualStyleBackColor = true;
            this.btnSFFormat.Click += new System.EventHandler(this.btnSFFormat_Click);
            // 
            // btnCSVSplitter
            // 
            this.btnCSVSplitter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSVSplitter.Location = new System.Drawing.Point(76, 165);
            this.btnCSVSplitter.Name = "btnCSVSplitter";
            this.btnCSVSplitter.Size = new System.Drawing.Size(87, 42);
            this.btnCSVSplitter.TabIndex = 5;
            this.btnCSVSplitter.Text = "CSV Splitter";
            this.toolTip1.SetToolTip(this.btnCSVSplitter, "This action will split a .csv file into multiple chunks.");
            this.btnCSVSplitter.UseVisualStyleBackColor = true;
            this.btnCSVSplitter.Click += new System.EventHandler(this.btnCSVSplitter_Click);
            // 
            // btnFileSmasher
            // 
            this.btnFileSmasher.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSmasher.Location = new System.Drawing.Point(189, 165);
            this.btnFileSmasher.Name = "btnFileSmasher";
            this.btnFileSmasher.Size = new System.Drawing.Size(87, 42);
            this.btnFileSmasher.TabIndex = 6;
            this.btnFileSmasher.Text = "File Smasher";
            this.toolTip1.SetToolTip(this.btnFileSmasher, "This action will combine 2 or more files on header names.");
            this.btnFileSmasher.UseVisualStyleBackColor = true;
            this.btnFileSmasher.Visible = false;
            this.btnFileSmasher.Click += new System.EventHandler(this.btnFileSmasher_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(359, 271);
            this.Controls.Add(this.btnFileSmasher);
            this.Controls.Add(this.btnCSVSplitter);
            this.Controls.Add(this.btnSFFormat);
            this.Controls.Add(this.lblDBC);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Tool Box";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Label lblDBC;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.Button btnSFFormat;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem updateLogToolStripMenuItem;
        private System.Windows.Forms.Button btnCSVSplitter;
        private System.Windows.Forms.Button btnFileSmasher;
    }
}

