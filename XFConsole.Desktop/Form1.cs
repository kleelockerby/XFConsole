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

namespace XFConsole.Desktop
{
    public partial class Form1 : Form
    {
        private LogonClient logonClient = null;
        private List<XFApplication> xfApplications = null;
        private string initialSelectedApplicationName = "GolfStreamDemo_v36";
        private XFOneStream oneStreamModel = null;
        private AuthenticationDataAccess authenticationDataAccess = null;

        public Form1()
        {
            InitializeComponent();

            btnOpenApplication.Enabled = false;

            int chAppNameWidth = lvApplications.Width - SystemInformation.VerticalScrollBarWidth - 4;
            lvApplications.Columns.Add(new ColumnHeader() { Name = "ApplicationName", Text = "Application Name", TextAlign = HorizontalAlignment.Center, Width = chAppNameWidth });
            lvApplications.Refresh();

            lvDashboardProfiles.Columns.Add(new ColumnHeader() { Name = "NameOrDesc", Text = "Name", TextAlign = HorizontalAlignment.Left, Width = 200 });
            lvDashboardProfiles.Columns.Add(new ColumnHeader() { Name = "XFType", Text = "XFType", TextAlign = HorizontalAlignment.Left, Width = 120 });
            lvDashboardProfiles.Columns.Add(new ColumnHeader() { Name = "UniqueID", Text = "UniqueID", TextAlign = HorizontalAlignment.Left, Width = 260 });
            lvDashboardProfiles.Columns.Add(new ColumnHeader() { Name = "AccessLevel", Text = "Access Level", TextAlign = HorizontalAlignment.Left, Width = 90 });

            lvCubeViewProfiles.Columns.Add(new ColumnHeader() { Name = "NameOrDesc", Text = "Name", TextAlign = HorizontalAlignment.Left, Width = 200 });
            lvCubeViewProfiles.Columns.Add(new ColumnHeader() { Name = "XFType", Text = "XFType", TextAlign = HorizontalAlignment.Left, Width = 120 });
            lvCubeViewProfiles.Columns.Add(new ColumnHeader() { Name = "UniqueID", Text = "UniqueID", TextAlign = HorizontalAlignment.Left, Width = 260 });
            lvCubeViewProfiles.Columns.Add(new ColumnHeader() { Name = "AccessLevel", Text = "Access Level", TextAlign = HorizontalAlignment.Left, Width = 90 });
        }

        private async void btnLogon_Click(object sender, EventArgs e)
        {
            authenticationDataAccess = AuthenticationDataAccess.Create(new HttpClient());
            XFLogonRequestDto logonModel = AuthenticationHelper.GetLogonHelper(txtUserName.Text, txtPassword.Text, initialSelectedApplicationName);
            this.oneStreamModel = await authenticationDataAccess.GetLogonAsync(logonModel);

            if (oneStreamModel.ApplicationData.Applications?.Count > 0)
            {
                lvApplications.Items.Clear();
                foreach (XFApplication application in this.oneStreamModel.ApplicationData.Applications)
                {
                    ListViewItem lvItem = new ListViewItem(new string[] { application.Name });
                    lvApplications.Items.Add(lvItem);
                }
            }
            OpenNewApplication(oneStreamModel.SelectedApplication.Name, this.oneStreamModel.SI);
        }

        private async void OpenNewApplication(string selectedApplicationName, SessionInfo si)
        {
            XFOpenApplicationRequestDto openApplicationRequestDto = AuthenticationHelper.GetOpenApplicationHelper(selectedApplicationName, si);
            await authenticationDataAccess.OpenApplicationAsync(openApplicationRequestDto, this.oneStreamModel);
            GetDashboardsProfileInfo();
            GetCubeViewsProfileInfo();
        }

        private void GetDashboardsProfileInfo()
        {
            lvDashboardProfiles.Items.Clear();
            foreach (DashboardProfileInfo dashboardProfileInfo in logonClient.DashboardProfiles)
            {
                DashboardProfile dashboardProfile = dashboardProfileInfo.Profile;
                string nameOrDescription = dashboardProfile.NameOrDescription;
                string xfObjectType = dashboardProfile.XFType.ToString();
                string uniqueId = dashboardProfile.UniqueID.ToString();
                string accessLevel = dashboardProfile.AccessLevel.ToString();

                ListViewItem lvItem = new ListViewItem(new string[] { nameOrDescription, xfObjectType, uniqueId, accessLevel });
                lvDashboardProfiles.Items.Add(lvItem);
            }
            lvDashboardProfiles.Enabled = true;
        }

        private void GetCubeViewsProfileInfo()
        {
            lvCubeViewProfiles.Items.Clear();
            foreach (CubeViewProfileInfo cubeViewProfileInfo in logonClient.CubeViewProfiles)
            {
                CubeViewProfile cubeViewProfile = cubeViewProfileInfo.Profile;
                string nameOrDescription = cubeViewProfile.NameOrDescription;
                string xfObjectType = cubeViewProfile.XFType.ToString();
                string uniqueId = cubeViewProfile.UniqueID.ToString();
                string accessLevel = cubeViewProfile.AccessLevel.ToString();

                ListViewItem lvItem = new ListViewItem(new string[] { nameOrDescription, xfObjectType, uniqueId, accessLevel });
                lvCubeViewProfiles.Items.Add(lvItem); 
            }
            lvCubeViewProfiles.Enabled = true;
        }

        private void lvApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid applicationUniqueID = new Guid(AuthenticationHelper.GetSelectedApplicationStringId(lvApplications.SelectedItems[0].Text));
            XFApplication application = new XFApplication(applicationUniqueID, lvApplications.SelectedItems[0].Text, "", "", "");
            this.oneStreamModel.SelectedApplication = application;

            // TODO: Fire Application Changed Event;

            OpenNewApplication(this.oneStreamModel.SelectedApplication.Name, this.oneStreamModel.SI);
        }

    }
}



/*





private async void btnOpenApplication_Click(object sender, EventArgs e)
        {
            this.selectedApplication = lvApplications.SelectedItems[0].SubItems[0].Text;
            
        }


        private async void OnSelectedApplicationChanged()
        {
            await this.logonClient.OpenApplicationAsync(this.selectedApplication);

            if (logonClient.DashboardProfiles?.Count > 0)
            {
                GetDashboardsProfileInfo();
                GetCubeViewsProfileInfo();
            }
        }
*/
