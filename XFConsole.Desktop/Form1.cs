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
        private string initialSelectedApplicationName = "GolfStreamDemo_v36";
        private XFOneStream oneStreamModel = null;
        private AuthenticationDataAccess authenticationDataAccess = null;
        private HttpClient httpClient = new HttpClient();

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
            authenticationDataAccess = AuthenticationDataAccess.Create(this.httpClient);
            XFLogonRequestDto logonModel = HttpClientHelper.GetLogon(txtUserName.Text, txtPassword.Text, initialSelectedApplicationName);
            this.oneStreamModel = await authenticationDataAccess.GetLogonAsync(logonModel);

            if (oneStreamModel.ApplicationData.Applications?.Count > 0)
            {
                //lvApplications.Items.Clear();
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
            XFOpenApplicationRequestDto openApplicationRequestDto = HttpClientHelper.GetOpenApplication(selectedApplicationName, si);
            await authenticationDataAccess.OpenApplicationAsync(openApplicationRequestDto, this.oneStreamModel);
            GetDashboardsProfileInfo();
            GetCubeViewsProfileInfo();
        }

        private void GetDashboardsProfileInfo()
        {
            lvDashboardProfiles.Items.Clear();
            foreach (DashboardProfileInfo dashboardProfileInfo in this.oneStreamModel.ApplicationData.DashboardProfileInfos)
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
            foreach (CubeViewProfileInfo cubeViewProfileInfo in this.oneStreamModel.ApplicationData.CubeViewProfileInfos)
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

        private void lvApplications_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == true)
            {
                int selectedItemIndex = e.ItemIndex;
                string appName = lvApplications.Items[selectedItemIndex].Text;
                string id = HttpClientHelper.GetSelectedApplicationStringId(appName);
                Guid applicationUniqueID = new Guid(id);
                XFApplication application = new XFApplication(applicationUniqueID, lvApplications.Items[selectedItemIndex].Text, "", "", "");
                this.oneStreamModel.SelectedApplication = application;

                //TODO: OnApplicationChanged()
                OpenNewApplication(this.oneStreamModel.SelectedApplication.Name, this.oneStreamModel.SI);
            }
        }

        private void lvDashboardProfiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == true)
            {
                int selectedItemIndex = e.ItemIndex;
                this.oneStreamModel.SelectedDashboardProfileInfo = this.oneStreamModel.ApplicationData.DashboardProfileInfos[selectedItemIndex];
                XFGetDashboardsInProfileRequestDto getDashboardsInProfileRequestDto = new XFGetDashboardsInProfileRequestDto(this.oneStreamModel.SI, false, this.oneStreamModel.SelectedDashboardProfileInfo.Profile.UniqueID, DashboardUIPlatformType.WpfOrSilverlight, true);
                GetDashboardsInProfile(getDashboardsInProfileRequestDto);
            }
        }

        private async void GetDashboardsInProfile(XFGetDashboardsInProfileRequestDto getDashboardsInProfileRequestDto)
        {
            DashboardDataAccess dataAccess = DashboardDataAccess.Create(this.httpClient);
            await dataAccess.GetDashboardsInProfile(getDashboardsInProfileRequestDto, this.oneStreamModel);

        }

    }
}