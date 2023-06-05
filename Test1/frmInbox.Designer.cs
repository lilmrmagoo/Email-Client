namespace Test1
{
    partial class frmInbox
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
            this.lstInbox = new System.Windows.Forms.ListBox();
            this.btnCompose = new System.Windows.Forms.Button();
            this.txtViewEmail = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstInbox
            // 
            this.lstInbox.FormattingEnabled = true;
            this.lstInbox.Location = new System.Drawing.Point(12, 68);
            this.lstInbox.Name = "lstInbox";
            this.lstInbox.Size = new System.Drawing.Size(515, 459);
            this.lstInbox.TabIndex = 0;
            this.lstInbox.SelectedIndexChanged += new System.EventHandler(this.lstInbox_SelectedIndexChanged);
            // 
            // btnCompose
            // 
            this.btnCompose.Location = new System.Drawing.Point(29, 28);
            this.btnCompose.Name = "btnCompose";
            this.btnCompose.Size = new System.Drawing.Size(75, 23);
            this.btnCompose.TabIndex = 2;
            this.btnCompose.Text = "New Email";
            this.btnCompose.UseVisualStyleBackColor = true;
            this.btnCompose.Click += new System.EventHandler(this.btnCompose_Click);
            // 
            // txtViewEmail
            // 
            this.txtViewEmail.Location = new System.Drawing.Point(563, 71);
            this.txtViewEmail.Multiline = true;
            this.txtViewEmail.Name = "txtViewEmail";
            this.txtViewEmail.ReadOnly = true;
            this.txtViewEmail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtViewEmail.Size = new System.Drawing.Size(616, 456);
            this.txtViewEmail.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(128, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh Inbox";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 565);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstInbox);
            this.Controls.Add(this.txtViewEmail);
            this.Controls.Add(this.btnCompose);
            this.Name = "frmInbox";
            this.Text = "frmInbox";
            this.Load += new System.EventHandler(this.frmInbox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstInbox;
        private System.Windows.Forms.Button btnCompose;
        private System.Windows.Forms.TextBox txtViewEmail;
        private System.Windows.Forms.Button btnRefresh;
    }
}