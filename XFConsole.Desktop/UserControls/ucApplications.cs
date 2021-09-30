using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using XFConsole.Shared;

namespace XFConsole.Desktop.UserControls
{
    public partial class ucApplications : UserControl
    {
        private HttpClient Http;
        private SessionInfo si;
        private List<XFApplication> applications;
        private XFApplication selectedApplication;
        private List<DashboardProfileInfo> dashboardProfileInfos = null;
        private Dictionary<string, Dashboard> dictDashboards = new Dictionary<string, Dashboard>();

        public ucApplications(HttpClient httpClient, SessionInfo si, List<XFApplication> applications, XFApplication selectedApplication, List<DashboardProfileInfo> dashboardProfileInfos)
        {
            InitializeComponent();
            this.Http = httpClient;
            this.si = si;
            this.applications = applications;
            this.selectedApplication = selectedApplication;
            this.dashboardProfileInfos = dashboardProfileInfos;
        }

        public void ShowApplications()
        {
            lvApplications.Columns.Add(new ColumnHeader() { Name = "ApplicationName", Text = "Applications", Width = lvApplications.Width - 5 });
            foreach( XFApplication application in this.applications)
            {
                lvApplications.Items.Add(new ListViewItem(new string[] { application.Name }));
            }

            int selectedAppIndex = this.applications.IndexOf(this.selectedApplication);
            lvApplications.SelectedIndices.Clear();
            lvApplications.Focus();
            lvApplications.Select();
            lvApplications.Items[selectedAppIndex].Focused = true;
            lvApplications.Items[selectedAppIndex].Selected = true;
            lvApplications.Refresh();
        }

        public void ShowDashboardsProfileInfo()
        {
            TreeNode nodeRoot = new TreeNode() { Name = "DashboardProfileInfo", Text = "DashboardProfileInfo", ImageIndex = 8, SelectedImageIndex = 8, Tag = "DashboardProfileInfo" };
            TreeNode nodeSub1 = new TreeNode() { Name = "DashboardProfiles", Text = "DashboardProfiles", ImageIndex = 8, SelectedImageIndex = 8, Tag = "DashboardProfiles" };
            TreeNode nodeSub2 = new TreeNode() { Name = "DashboardGroups", Text = "DashboardGroups", ImageIndex = 6, SelectedImageIndex = 6, Tag = "DashboardGroups" };

            foreach (DashboardProfileInfo dashboardProfileInfo in this.dashboardProfileInfos)
            {
                TreeNode nodeDashboardProfile = new TreeNode() { Name = dashboardProfileInfo.Profile.UniqueID.ToString(), Text = dashboardProfileInfo.Profile.Name, ImageIndex = 5, SelectedImageIndex = 5, Tag = "DashboardProfile" };
                nodeSub1.Nodes.Add(nodeDashboardProfile);
                nodeDashboardProfile.Nodes.Add(new TreeNode("*"));

                foreach (DashboardGroup dashboardGroup in dashboardProfileInfo.Groups)
                {
                    TreeNode nodeDashboardGroup = new TreeNode() { Name = dashboardGroup.UniqueID.ToString(), Text = dashboardGroup.Name, ImageIndex = 7, SelectedImageIndex = 7, Tag = "DashboardGroup" };
                    nodeSub2.Nodes.Add(nodeDashboardGroup);
                }
            }

            nodeRoot.Nodes.Add(nodeSub1);
            nodeRoot.Nodes.Add(nodeSub2);
            nodeRoot.Expand();
            nodeSub1.Expand();
            tvDashboardProfileInfos.Nodes.Add(nodeRoot);
        }

        private async void GetDashboardsInProfile(Guid dashboardProfileId, TreeNode selectedNode)
        {
            DashboardDataAccess dashboardDataAccess = DashboardDataAccess.Create(this.Http);
            List<Dashboard> dashboards = await dashboardDataAccess.GetDashboardsInProfile(this.si, dashboardProfileId);

            if (dashboards?.Count > 0)
            {
                foreach (Dashboard dashboard in dashboards)
                {
                    if (!this.dictDashboards.ContainsKey(dashboard.Name.ToString()))
                    {
                        this.dictDashboards.Add(dashboard.UniqueID.ToString(), dashboard);
                        TreeNode node = new TreeNode() { Name = dashboard.UniqueID.ToString(), Text = dashboard.Name, ImageIndex = 3, SelectedImageIndex = 3, Tag = "Dashboard" };
                        //node.Nodes.Add(new TreeNode("*"));
                        selectedNode.Nodes.Add(node);
                    }
                }
                selectedNode.ExpandAll();
            }
        }

        private DashboardProfile GetDashboardProfileInfoFromId(Guid uniqueId)
        {
            try
            {
                foreach (DashboardProfileInfo dashboardProfileInfo in this.dashboardProfileInfos)
                {
                    if (dashboardProfileInfo.Profile.UniqueID == uniqueId)
                    {
                        DashboardProfileInfo selectedDashboardProfileInfo = dashboardProfileInfo;
                        return selectedDashboardProfileInfo.Profile;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
            return null;
        }

        private void tvDashboardProfileInfos_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();
                if (!string.IsNullOrEmpty(e.Node.Name))
                {
                    string nodeTag = e.Node.Tag.ToString();
                    if (nodeTag == "DashboardProfile")
                    {
                        Guid dashboardProfileId = new Guid(e.Node.Name);
                        GetDashboardsInProfile(dashboardProfileId, e.Node);
                        e.Node.Parent.Expand();
                    }
                }
            }
        }

        private void tvDashboardProfileInfos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag?.ToString() == "DashboardProfile")
                {
                    Guid dashboardProfileId = new Guid(e.Node.Name);
                    DashboardProfile selectedDashboardProfile = GetDashboardProfileInfoFromId(dashboardProfileId);
                    this.splitContainer1.Panel2.Controls.Clear();

                    ucDashboardInfoProperties dashboardInfoProperties = new ucDashboardInfoProperties();
                    dashboardInfoProperties.ShowDashboardProperties(selectedDashboardProfile);
                    dashboardInfoProperties.Dock = DockStyle.Fill;
                    this.splitContainer1.Panel2.Controls.Add(dashboardInfoProperties);
                }
                else if (e.Node.Tag?.ToString() == "Dashboard")
                {
                    if (this.dictDashboards.ContainsKey(e.Node.Name.ToString()))
                    {
                        Dashboard dashboard = this.dictDashboards[e.Node.Name] as Dashboard;
                        this.splitContainer1.Panel2.Controls.Clear();
                        ucDashboardInfoProperties dashboardInfoProperties = new ucDashboardInfoProperties();
                        dashboardInfoProperties.ShowDashboardProperties(dashboard);
                        dashboardInfoProperties.Dock = DockStyle.Fill;
                        this.splitContainer1.Panel2.Controls.Add(dashboardInfoProperties);
                    } 

                }
                else if (e.Node.Tag?.ToString() == "DashboardGroups")
                {
                    return;         //ToDo: Implement Groups
                }
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
        }
    }
}
