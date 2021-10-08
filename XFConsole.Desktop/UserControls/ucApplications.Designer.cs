
namespace XFConsole.Desktop.UserControls
{
    partial class ucApplications
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucApplications));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lvApplications = new System.Windows.Forms.ListView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDashboardProfileInfos = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.lvApplications);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(180, 690);
            this.pnlLeft.TabIndex = 0;
            // 
            // lvApplications
            // 
            this.lvApplications.AllowDrop = true;
            this.lvApplications.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.lvApplications.Scrollable = false;
            this.lvApplications.Size = new System.Drawing.Size(178, 688);
            this.lvApplications.TabIndex = 4;
            this.lvApplications.UseCompatibleStateImageBehavior = false;
            this.lvApplications.View = System.Windows.Forms.View.Details;
            this.lvApplications.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvApplications_ItemSelectionChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.tabControl1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(180, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(990, 690);
            this.pnlRight.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(979, 680);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.ImageIndex = 3;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(971, 652);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DashboardProfileInfo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDashboardProfileInfos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Size = new System.Drawing.Size(965, 646);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvDashboardProfileInfos
            // 
            this.tvDashboardProfileInfos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvDashboardProfileInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDashboardProfileInfos.ImageIndex = 0;
            this.tvDashboardProfileInfos.ImageList = this.imageList1;
            this.tvDashboardProfileInfos.Location = new System.Drawing.Point(0, 0);
            this.tvDashboardProfileInfos.Name = "tvDashboardProfileInfos";
            this.tvDashboardProfileInfos.SelectedImageIndex = 0;
            this.tvDashboardProfileInfos.Size = new System.Drawing.Size(274, 642);
            this.tvDashboardProfileInfos.TabIndex = 0;
            this.tvDashboardProfileInfos.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvDashboardProfileInfos_BeforeExpand);
            this.tvDashboardProfileInfos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDashboardProfileInfos_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "application.ico");
            this.imageList1.Images.SetKeyName(1, "cubeview.ico");
            this.imageList1.Images.SetKeyName(2, "cubeviewlight.ico");
            this.imageList1.Images.SetKeyName(3, "dashboard.ico");
            this.imageList1.Images.SetKeyName(4, "generalprofile.ico");
            this.imageList1.Images.SetKeyName(5, "presprofile.ico");
            this.imageList1.Images.SetKeyName(6, "group.ico");
            this.imageList1.Images.SetKeyName(7, "workflow.ico");
            this.imageList1.Images.SetKeyName(8, "dashboardinfo.ico");
            this.imageList1.Images.SetKeyName(9, "objects.ico");
            this.imageList1.Images.SetKeyName(10, "parameter.ico");
            this.imageList1.Images.SetKeyName(11, "pov.ico");
            this.imageList1.Images.SetKeyName(12, "properties.ico");
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 2;
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(973, 654);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CubeViewProfileInfo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "ucApplications";
            this.Size = new System.Drawing.Size(1170, 690);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lvApplications;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvDashboardProfileInfos;
    }
}
