
namespace XFConsole.Desktop.UserControls
{
    partial class ucDashboardInfoProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDashboardInfoProperties));
            this.propertyGridDashboardInfo = new System.Windows.Forms.PropertyGrid();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtProp = new System.Windows.Forms.RichTextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvParamDisplayInfos = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGridDashboardInfo
            // 
            this.propertyGridDashboardInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridDashboardInfo.HelpVisible = false;
            this.propertyGridDashboardInfo.Location = new System.Drawing.Point(3, 30);
            this.propertyGridDashboardInfo.Name = "propertyGridDashboardInfo";
            this.propertyGridDashboardInfo.Size = new System.Drawing.Size(1034, 363);
            this.propertyGridDashboardInfo.TabIndex = 0;
            this.propertyGridDashboardInfo.ToolbarVisible = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtProp);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1040, 30);
            this.pnlTop.TabIndex = 1;
            // 
            // txtProp
            // 
            this.txtProp.BackColor = System.Drawing.Color.White;
            this.txtProp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProp.Location = new System.Drawing.Point(24, 3);
            this.txtProp.Multiline = false;
            this.txtProp.Name = "txtProp";
            this.txtProp.ReadOnly = true;
            this.txtProp.Size = new System.Drawing.Size(400, 28);
            this.txtProp.TabIndex = 2;
            this.txtProp.Text = "";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.splitContainer1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 399);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1040, 451);
            this.pnlBottom.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvParamDisplayInfos);
            this.splitContainer1.Size = new System.Drawing.Size(1040, 451);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvParamDisplayInfos
            // 
            this.lvParamDisplayInfos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvParamDisplayInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvParamDisplayInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvParamDisplayInfos.FullRowSelect = true;
            this.lvParamDisplayInfos.GridLines = true;
            this.lvParamDisplayInfos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvParamDisplayInfos.HideSelection = false;
            this.lvParamDisplayInfos.LabelWrap = false;
            this.lvParamDisplayInfos.LargeImageList = this.imageList1;
            this.lvParamDisplayInfos.Location = new System.Drawing.Point(0, 0);
            this.lvParamDisplayInfos.MultiSelect = false;
            this.lvParamDisplayInfos.Name = "lvParamDisplayInfos";
            this.lvParamDisplayInfos.Scrollable = false;
            this.lvParamDisplayInfos.Size = new System.Drawing.Size(498, 449);
            this.lvParamDisplayInfos.StateImageList = this.imageList1;
            this.lvParamDisplayInfos.TabIndex = 0;
            this.lvParamDisplayInfos.UseCompatibleStateImageBehavior = false;
            this.lvParamDisplayInfos.View = System.Windows.Forms.View.Details;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Dummy32.ico");
            // 
            // ucDashboardInfoProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.propertyGridDashboardInfo);
            this.Name = "ucDashboardInfoProperties";
            this.Size = new System.Drawing.Size(1040, 850);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGridDashboardInfo;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.RichTextBox txtProp;
        private System.Windows.Forms.ListView lvParamDisplayInfos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
    }
}
