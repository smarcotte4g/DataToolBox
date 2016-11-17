namespace DataToolBox
{
    partial class SFDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFDialog));
            this.cbxContacts = new System.Windows.Forms.CheckBox();
            this.cbxLeads = new System.Windows.Forms.CheckBox();
            this.btnReformat = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.cbxAccounts = new System.Windows.Forms.CheckBox();
            this.cbxOpportunities = new System.Windows.Forms.CheckBox();
            this.cbxNotes = new System.Windows.Forms.CheckBox();
            this.cbxTasks = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbxContacts
            // 
            this.cbxContacts.AutoSize = true;
            this.cbxContacts.Location = new System.Drawing.Point(113, 145);
            this.cbxContacts.Name = "cbxContacts";
            this.cbxContacts.Size = new System.Drawing.Size(84, 17);
            this.cbxContacts.TabIndex = 0;
            this.cbxContacts.Text = "Contact.csv";
            this.cbxContacts.UseVisualStyleBackColor = true;
            // 
            // cbxLeads
            // 
            this.cbxLeads.AutoSize = true;
            this.cbxLeads.Location = new System.Drawing.Point(113, 122);
            this.cbxLeads.Name = "cbxLeads";
            this.cbxLeads.Size = new System.Drawing.Size(68, 17);
            this.cbxLeads.TabIndex = 1;
            this.cbxLeads.Text = "Lead.csv";
            this.cbxLeads.UseVisualStyleBackColor = true;
            // 
            // btnReformat
            // 
            this.btnReformat.Location = new System.Drawing.Point(113, 326);
            this.btnReformat.Name = "btnReformat";
            this.btnReformat.Size = new System.Drawing.Size(75, 23);
            this.btnReformat.TabIndex = 2;
            this.btnReformat.Text = "Reformat";
            this.btnReformat.UseVisualStyleBackColor = true;
            this.btnReformat.Click += new System.EventHandler(this.btnReformat_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(12, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(304, 78);
            this.lblInstructions.TabIndex = 3;
            this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
            // 
            // cbxAccounts
            // 
            this.cbxAccounts.AutoSize = true;
            this.cbxAccounts.Location = new System.Drawing.Point(113, 168);
            this.cbxAccounts.Name = "cbxAccounts";
            this.cbxAccounts.Size = new System.Drawing.Size(86, 17);
            this.cbxAccounts.TabIndex = 5;
            this.cbxAccounts.Text = "Account.csv";
            this.cbxAccounts.UseVisualStyleBackColor = true;
            // 
            // cbxOpportunities
            // 
            this.cbxOpportunities.AutoSize = true;
            this.cbxOpportunities.Location = new System.Drawing.Point(113, 192);
            this.cbxOpportunities.Name = "cbxOpportunities";
            this.cbxOpportunities.Size = new System.Drawing.Size(108, 17);
            this.cbxOpportunities.TabIndex = 7;
            this.cbxOpportunities.Text = "Opportunity.csv";
            this.cbxOpportunities.UseVisualStyleBackColor = true;
            // 
            // cbxNotes
            // 
            this.cbxNotes.AutoSize = true;
            this.cbxNotes.Location = new System.Drawing.Point(113, 216);
            this.cbxNotes.Name = "cbxNotes";
            this.cbxNotes.Size = new System.Drawing.Size(69, 17);
            this.cbxNotes.TabIndex = 8;
            this.cbxNotes.Text = "Note.csv";
            this.cbxNotes.UseVisualStyleBackColor = true;
            // 
            // cbxTasks
            // 
            this.cbxTasks.AutoSize = true;
            this.cbxTasks.Location = new System.Drawing.Point(113, 240);
            this.cbxTasks.Name = "cbxTasks";
            this.cbxTasks.Size = new System.Drawing.Size(65, 17);
            this.cbxTasks.TabIndex = 9;
            this.cbxTasks.Text = "Task.csv";
            this.cbxTasks.UseVisualStyleBackColor = true;
            // 
            // SFDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 388);
            this.Controls.Add(this.cbxTasks);
            this.Controls.Add(this.cbxNotes);
            this.Controls.Add(this.cbxOpportunities);
            this.Controls.Add(this.cbxAccounts);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnReformat);
            this.Controls.Add(this.cbxLeads);
            this.Controls.Add(this.cbxContacts);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SFDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxContacts;
        private System.Windows.Forms.CheckBox cbxLeads;
        private System.Windows.Forms.Button btnReformat;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.CheckBox cbxAccounts;
        private System.Windows.Forms.CheckBox cbxOpportunities;
        private System.Windows.Forms.CheckBox cbxNotes;
        private System.Windows.Forms.CheckBox cbxTasks;

    }
}