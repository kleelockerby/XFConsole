using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using OneStream.Shared.Wcf;
using XFConsole.Shared;
using OneStreamWebUI.Shared;
using OneStream.Shared.Common;

namespace XFConsole.Desktop.UserControls
{
    public partial class Applications : UserControl
    {
        private HttpClient Http;
        private XFApplicationData applicationData;
        private SessionInfo SI;

        public Applications(HttpClient httpClient, SessionInfo si)
        {
            InitializeComponent();
            this.Http = httpClient;
            this.SI = si;
            lvApplications.Columns.Add(new ColumnHeader() { Name = "ApplicationName", Text = "               Applications", Width = lvApplications.Width - 5 });
            lvApplications.Refresh();
        }

        public void ShowApplications(XFApplicationData applicationData)
        {
            this.applicationData = applicationData;
            foreach (XFApplication application in this.applicationData.Applications)
            {
                ListViewItem lvItem = new ListViewItem(new string[] { application.Name });
                lvApplications.Items.Add(lvItem);
            }

            int selectedIndex = this.applicationData.Applications.IndexOf(this.applicationData.SelectedApplication);
            lvApplications.SelectedIndices.Clear();
            lvApplications.Focus();
            lvApplications.Select();
            lvApplications.Items[selectedIndex].Focused = true;
            lvApplications.Items[selectedIndex].Selected = true;

            GetDashboardsProfileInfo();
        }

        private void GetDashboardsProfileInfo()
        {
            TreeNode nodeRoot = new TreeNode("DashboardProfileInfo", 8, 8);
            TreeNode nodeSub1 = new TreeNode("DashboardProfiles", 5, 5);
            TreeNode nodeSub2 = new TreeNode("DashboardGroups", 6, 6);

            foreach (DashboardProfileInfo dashboardProfileInfo in applicationData.DashboardProfileInfos)
            {
                TreeNode nodeDashboardProfile = new TreeNode() { Name = dashboardProfileInfo.Profile.UniqueID.ToString(), Text = dashboardProfileInfo.Profile.Name, ImageIndex = 5, SelectedImageIndex = 5, Tag = "DashboardProfile" };
                nodeDashboardProfile.Nodes.Add("*");
                nodeSub1.Nodes.Add(nodeDashboardProfile);

                foreach(DashboardGroup dashboardGroup in dashboardProfileInfo.Groups)
                {
                    TreeNode nodeDashboardGroup = new TreeNode() { Name = dashboardGroup.UniqueID.ToString(), Text = dashboardGroup.Name, ImageIndex = 7, StateImageIndex = 7 };
                    nodeSub2.Nodes.Add(nodeDashboardGroup);
                }
            }

            nodeRoot.Nodes.Add(nodeSub1);
            nodeRoot.Nodes.Add(nodeSub2);
            nodeRoot.Expand();
            nodeSub1.Expand();
            tvDashboardProfileInfos.Nodes.Add(nodeRoot);
        }

        private void tvDashboardProfileInfos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode nodeSelected = e.Node;
                if (string.IsNullOrEmpty(nodeSelected.Name))
                {
                    return;
                }

                string nodeText = nodeSelected.Text;
                string nodeTag = nodeSelected.Tag.ToString();

                if (nodeTag == "DashboardProfile")
                {
                    //Temp test
                    var selNode = this.tvDashboardProfileInfos.SelectedNode;

                    string nodeName = tvDashboardProfileInfos.SelectedNode.Name;
                    Guid dashboardProfileId = new Guid(nodeName);
                    DashboardProfile selectedDashboardProfile = GetDashboardProfileInfoFromId(dashboardProfileId);
                    this.splitContainer1.Panel2.Controls.Clear();

                    DashboardProperties ucDashboardProperties = new DashboardProperties(this.Http);
                    ucDashboardProperties.ShowDashboardProperties(selectedDashboardProfile);
                    ucDashboardProperties.Dock = DockStyle.Left;

                    this.splitContainer1.Panel2.Controls.Add(ucDashboardProperties);
                }
                else if (nodeText == "DashboardGroups")
                {
                    return;         //ToDo: Implement Groups
                }
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
        }

        private DashboardProfile GetDashboardProfileInfoFromId(Guid uniqueId)
        {
            try
            {
                foreach (DashboardProfileInfo dashboardProfileInfo in applicationData.DashboardProfileInfos)
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

        private async void GetDashboardsInProfile(Guid dashboardProfileId, TreeNode selectedNode)
        {
            DashboardDataAccess dashboardDataAccess = DashboardDataAccess.Create(this.Http);
            List<Dashboard> dashboards = await dashboardDataAccess.GetDashboardsInProfile(this.SI, dashboardProfileId);

            if (dashboards?.Count > 0)
            {
                foreach (Dashboard dashboard in dashboards)
                {
                    TreeNode node = new TreeNode() { Name = dashboard.UniqueID.ToString(), Text = dashboard.Name, ImageIndex = 3, SelectedImageIndex = 3, Tag = "Dashboard" };
                    selectedNode.Nodes.Add(node);
                } 
            }
        }

        private void tvDashboardProfileInfos_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode nodeSelected = e.Node;
            if (nodeSelected.Nodes[0].Text == "*")
            {
                nodeSelected.Nodes.Clear();
                if (!string.IsNullOrEmpty(nodeSelected.Name))
                {
                    string nodeTag = nodeSelected.Tag.ToString();
                    if (nodeTag == "DashboardProfile")
                    {
                        string nodeName = nodeSelected.Name;
                        Guid dashboardProfileId = new Guid(nodeName);
                        GetDashboardsInProfile(dashboardProfileId, nodeSelected);
                    }
                }
            }
        }
    }
}


/*
 
        private void tvDashboardProfileInfos_AfterExpand(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode nodeSelected = e.Node;
                if (!string.IsNullOrEmpty(nodeSelected.Name))
                {
                    return;
                }
                
                if (nodeSelected.Nodes?.Count > 0)
                {
                    string nodeText = nodeSelected.Text;
                    string nodeTag = nodeSelected.Tag.ToString();
                    if (nodeTag == "DashboardProfile")
                    {
                        if ((nodeSelected.Nodes[0] != null) && (nodeSelected.Nodes[0].Text == "FakeTreeNode"))
                        {
                            TreeNode nodeChild = nodeSelected.Nodes[0];
                            nodeSelected.Nodes.Remove(nodeChild);
                        }
                        
                        string nodeName = tvDashboardProfileInfos.SelectedNode.Name;
                        Guid dashboardProfileId = new Guid(nodeName);
                        GetDashboardsInProfile(dashboardProfileId, nodeSelected);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
        }

*/