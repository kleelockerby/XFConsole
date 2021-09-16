
namespace XFConsole.Desktop
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lvApplications = new System.Windows.Forms.ListView();
            this.btnLogon = new System.Windows.Forms.Button();
            this.btnOpenApplication = new System.Windows.Forms.Button();
            this.lvDashboardProfiles = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvCubeViewProfiles = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.Location = new System.Drawing.Point(32, 16);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 17);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name:";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserName.Location = new System.Drawing.Point(136, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(277, 23);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Applications";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(136, 54);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(277, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "123";
            // 
            // lvApplications
            // 
            this.lvApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvApplications.FullRowSelect = true;
            this.lvApplications.GridLines = true;
            this.lvApplications.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvApplications.HideSelection = false;
            this.lvApplications.LabelWrap = false;
            this.lvApplications.Location = new System.Drawing.Point(136, 156);
            this.lvApplications.MultiSelect = false;
            this.lvApplications.Name = "lvApplications";
            this.lvApplications.Size = new System.Drawing.Size(277, 230);
            this.lvApplications.TabIndex = 2;
            this.lvApplications.UseCompatibleStateImageBehavior = false;
            this.lvApplications.View = System.Windows.Forms.View.Details;
            this.lvApplications.SelectedIndexChanged += new System.EventHandler(this.lvApplications_SelectedIndexChanged);
            // 
            // btnLogon
            // 
            this.btnLogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogon.Location = new System.Drawing.Point(136, 95);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(277, 28);
            this.btnLogon.TabIndex = 3;
            this.btnLogon.Text = "Logon";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // btnOpenApplication
            // 
            this.btnOpenApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenApplication.Location = new System.Drawing.Point(136, 420);
            this.btnOpenApplication.Name = "btnOpenApplication";
            this.btnOpenApplication.Size = new System.Drawing.Size(277, 28);
            this.btnOpenApplication.TabIndex = 3;
            this.btnOpenApplication.Text = "Open Application";
            this.btnOpenApplication.UseVisualStyleBackColor = true;
            //this.btnOpenApplication.Click += new System.EventHandler(this.btnOpenApplication_Click);
            // 
            // lvDashboardProfiles
            // 
            this.lvDashboardProfiles.Enabled = false;
            this.lvDashboardProfiles.FullRowSelect = true;
            this.lvDashboardProfiles.GridLines = true;
            this.lvDashboardProfiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDashboardProfiles.HideSelection = false;
            this.lvDashboardProfiles.LabelWrap = false;
            this.lvDashboardProfiles.Location = new System.Drawing.Point(483, 43);
            this.lvDashboardProfiles.MultiSelect = false;
            this.lvDashboardProfiles.Name = "lvDashboardProfiles";
            this.lvDashboardProfiles.Size = new System.Drawing.Size(700, 181);
            this.lvDashboardProfiles.TabIndex = 4;
            this.lvDashboardProfiles.UseCompatibleStateImageBehavior = false;
            this.lvDashboardProfiles.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(483, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dashboard Profiles:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(483, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cube View Profiles:";
            // 
            // lvCubeViewProfiles
            // 
            this.lvCubeViewProfiles.Enabled = false;
            this.lvCubeViewProfiles.FullRowSelect = true;
            this.lvCubeViewProfiles.GridLines = true;
            this.lvCubeViewProfiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCubeViewProfiles.HideSelection = false;
            this.lvCubeViewProfiles.LabelWrap = false;
            this.lvCubeViewProfiles.Location = new System.Drawing.Point(483, 267);
            this.lvCubeViewProfiles.MultiSelect = false;
            this.lvCubeViewProfiles.Name = "lvCubeViewProfiles";
            this.lvCubeViewProfiles.Size = new System.Drawing.Size(700, 181);
            this.lvCubeViewProfiles.TabIndex = 7;
            this.lvCubeViewProfiles.UseCompatibleStateImageBehavior = false;
            this.lvCubeViewProfiles.View = System.Windows.Forms.View.Details;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 510);
            this.Controls.Add(this.lvCubeViewProfiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvDashboardProfiles);
            this.Controls.Add(this.btnOpenApplication);
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.lvApplications);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Logon Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ListView lvApplications;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Button btnOpenApplication;
        private System.Windows.Forms.ListView lvDashboardProfiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvCubeViewProfiles;
    }
}