namespace DataToolBox
{
    partial class FileSmasher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSmasher));
            this.btnSmash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSmash
            // 
            this.btnSmash.Location = new System.Drawing.Point(94, 96);
            this.btnSmash.Name = "btnSmash";
            this.btnSmash.Size = new System.Drawing.Size(94, 53);
            this.btnSmash.TabIndex = 0;
            this.btnSmash.Text = "Select Files and Smash";
            this.btnSmash.UseVisualStyleBackColor = true;
            this.btnSmash.Click += new System.EventHandler(this.btnSmash_Click);
            // 
            // FileSmasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSmash);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileSmasher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FileSmasher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSmash;
    }
}