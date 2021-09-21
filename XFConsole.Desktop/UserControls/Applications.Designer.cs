
namespace XFConsole.Desktop.UserControls
{
    partial class Applications
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lvApplications = new System.Windows.Forms.ListView();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(1000, 601);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.lvApplications);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 601);
            this.pnlLeft.TabIndex = 1;
            // 
            // lvApplications
            // 
            this.lvApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvApplications.FullRowSelect = true;
            this.lvApplications.GridLines = true;
            this.lvApplications.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvApplications.HideSelection = false;
            this.lvApplications.LabelWrap = false;
            this.lvApplications.Location = new System.Drawing.Point(0, 0);
            this.lvApplications.MultiSelect = false;
            this.lvApplications.Name = "lvApplications";
            this.lvApplications.Size = new System.Drawing.Size(198, 599);
            this.lvApplications.TabIndex = 3;
            this.lvApplications.UseCompatibleStateImageBehavior = false;
            this.lvApplications.View = System.Windows.Forms.View.Details;
            // 
            // Applications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Name = "Applications";
            this.Size = new System.Drawing.Size(1000, 601);
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ListView lvApplications;
    }
}
