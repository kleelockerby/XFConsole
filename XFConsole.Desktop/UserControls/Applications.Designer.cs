
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Applications));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDashboardProfileInfo = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDashboardProfileInfos = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tpCubeViewProfileInfo = new System.Windows.Forms.TabPage();
            this.tpWorkflowInitInfo = new System.Windows.Forms.TabPage();
            this.tpAppPropsSummaryInfo = new System.Windows.Forms.TabPage();
            this.tpUserAppSettings = new System.Windows.Forms.TabPage();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lvApplications = new System.Windows.Forms.ListView();
            this.pnlRight.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpDashboardProfileInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.tabControl1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(985, 565);
            this.pnlRight.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpDashboardProfileInfo);
            this.tabControl1.Controls.Add(this.tpCubeViewProfileInfo);
            this.tabControl1.Controls.Add(this.tpWorkflowInitInfo);
            this.tabControl1.Controls.Add(this.tpAppPropsSummaryInfo);
            this.tabControl1.Controls.Add(this.tpUserAppSettings);
            this.tabControl1.Location = new System.Drawing.Point(185, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 557);
            this.tabControl1.TabIndex = 0;
            // 
            // tpDashboardProfileInfo
            // 
            this.tpDashboardProfileInfo.Controls.Add(this.splitContainer1);
            this.tpDashboardProfileInfo.Location = new System.Drawing.Point(4, 24);
            this.tpDashboardProfileInfo.Name = "tpDashboardProfileInfo";
            this.tpDashboardProfileInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpDashboardProfileInfo.Size = new System.Drawing.Size(787, 529);
            this.tpDashboardProfileInfo.TabIndex = 0;
            this.tpDashboardProfileInfo.Text = "Dashboard Profile Info";
            this.tpDashboardProfileInfo.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDashboardProfileInfos);
            this.splitContainer1.Size = new System.Drawing.Size(781, 523);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvDashboardProfileInfos
            // 
            this.tvDashboardProfileInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDashboardProfileInfos.ImageIndex = 0;
            this.tvDashboardProfileInfos.ImageList = this.imageList1;
            this.tvDashboardProfileInfos.Location = new System.Drawing.Point(0, 0);
            this.tvDashboardProfileInfos.Name = "tvDashboardProfileInfos";
            this.tvDashboardProfileInfos.SelectedImageIndex = 0;
            this.tvDashboardProfileInfos.Size = new System.Drawing.Size(250, 523);
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
            // tpCubeViewProfileInfo
            // 
            this.tpCubeViewProfileInfo.Location = new System.Drawing.Point(4, 24);
            this.tpCubeViewProfileInfo.Name = "tpCubeViewProfileInfo";
            this.tpCubeViewProfileInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpCubeViewProfileInfo.Size = new System.Drawing.Size(787, 529);
            this.tpCubeViewProfileInfo.TabIndex = 1;
            this.tpCubeViewProfileInfo.Text = "CubeView Profile Info";
            this.tpCubeViewProfileInfo.UseVisualStyleBackColor = true;
            // 
            // tpWorkflowInitInfo
            // 
            this.tpWorkflowInitInfo.Location = new System.Drawing.Point(4, 24);
            this.tpWorkflowInitInfo.Name = "tpWorkflowInitInfo";
            this.tpWorkflowInitInfo.Size = new System.Drawing.Size(787, 529);
            this.tpWorkflowInitInfo.TabIndex = 2;
            this.tpWorkflowInitInfo.Text = "WorkflowInitInfo";
            this.tpWorkflowInitInfo.UseVisualStyleBackColor = true;
            // 
            // tpAppPropsSummaryInfo
            // 
            this.tpAppPropsSummaryInfo.Location = new System.Drawing.Point(4, 24);
            this.tpAppPropsSummaryInfo.Name = "tpAppPropsSummaryInfo";
            this.tpAppPropsSummaryInfo.Size = new System.Drawing.Size(787, 529);
            this.tpAppPropsSummaryInfo.TabIndex = 3;
            this.tpAppPropsSummaryInfo.Text = "AppPropsSummaryInfo";
            this.tpAppPropsSummaryInfo.UseVisualStyleBackColor = true;
            // 
            // tpUserAppSettings
            // 
            this.tpUserAppSettings.Location = new System.Drawing.Point(4, 24);
            this.tpUserAppSettings.Name = "tpUserAppSettings";
            this.tpUserAppSettings.Size = new System.Drawing.Size(787, 529);
            this.tpUserAppSettings.TabIndex = 4;
            this.tpUserAppSettings.Text = "UserAppSettings";
            this.tpUserAppSettings.UseVisualStyleBackColor = true;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.lvApplications);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(180, 565);
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
            this.lvApplications.Scrollable = false;
            this.lvApplications.Size = new System.Drawing.Size(178, 563);
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
            this.Size = new System.Drawing.Size(985, 565);
            this.pnlRight.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpDashboardProfileInfo.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ListView lvApplications;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpDashboardProfileInfo;
        private System.Windows.Forms.TabPage tpCubeViewProfileInfo;
        private System.Windows.Forms.TabPage tpWorkflowInitInfo;
        private System.Windows.Forms.TabPage tpAppPropsSummaryInfo;
        private System.Windows.Forms.TabPage tpUserAppSettings;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvDashboardProfileInfos;
        private System.Windows.Forms.ImageList imageList1;
    }
}
