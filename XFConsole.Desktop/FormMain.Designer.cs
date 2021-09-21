
namespace XFConsole.Desktop
{
    partial class FormMain
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
            this.pnlRight = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnDashboardsMain = new System.Windows.Forms.Button();
            this.btnApplicationsMain = new System.Windows.Forms.Button();
            this.btnLoginMain = new System.Windows.Forms.Button();
            this.pnlRight.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.statusStrip1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(189, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(995, 601);
            this.pnlRight.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 577);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "Status: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel2.Text = "Logged Off";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.btnDashboardsMain);
            this.pnlLeft.Controls.Add(this.btnApplicationsMain);
            this.pnlLeft.Controls.Add(this.btnLoginMain);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(189, 601);
            this.pnlLeft.TabIndex = 4;
            // 
            // btnDashboardsMain
            // 
            this.btnDashboardsMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboardsMain.Location = new System.Drawing.Point(0, 46);
            this.btnDashboardsMain.Name = "btnDashboardsMain";
            this.btnDashboardsMain.Size = new System.Drawing.Size(187, 23);
            this.btnDashboardsMain.TabIndex = 4;
            this.btnDashboardsMain.Text = "Dashboards";
            this.btnDashboardsMain.UseVisualStyleBackColor = true;
            this.btnDashboardsMain.Click += new System.EventHandler(this.btnDashboardsMain_Click);
            // 
            // btnApplicationsMain
            // 
            this.btnApplicationsMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApplicationsMain.Location = new System.Drawing.Point(0, 23);
            this.btnApplicationsMain.Name = "btnApplicationsMain";
            this.btnApplicationsMain.Size = new System.Drawing.Size(187, 23);
            this.btnApplicationsMain.TabIndex = 3;
            this.btnApplicationsMain.Text = "Applications";
            this.btnApplicationsMain.UseVisualStyleBackColor = true;
            this.btnApplicationsMain.Click += new System.EventHandler(this.btnApplicationsMain_Click);
            // 
            // btnLoginMain
            // 
            this.btnLoginMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoginMain.Location = new System.Drawing.Point(0, 0);
            this.btnLoginMain.Name = "btnLoginMain";
            this.btnLoginMain.Size = new System.Drawing.Size(187, 23);
            this.btnLoginMain.TabIndex = 2;
            this.btnLoginMain.Text = "Logon";
            this.btnLoginMain.UseVisualStyleBackColor = true;
            this.btnLoginMain.Click += new System.EventHandler(this.btnLoginMain_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 601);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnDashboardsMain;
        private System.Windows.Forms.Button btnApplicationsMain;
        private System.Windows.Forms.Button btnLoginMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}