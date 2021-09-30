using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFConsole.Desktop.UserControls;
using System.Net.Http;
using OneStream.Shared.Wcf;
using XFConsole.Shared;
using OneStreamWebUI.Shared;
using OneStream.Shared.Common;

namespace XFConsole.Desktop
{
    public partial class FormMain : Form
    {
        private LogonStatusType logonStatus = LogonStatusType.Unknown;
        private ucLogon ucLogon1 = null;
        private SessionInfo si = null;
        private ucApplications ucApplications1 = null;
        private List<XFApplication> applications = null;
        private XFApplication selectedApplication = null;
        private List<DashboardProfileInfo> dashboardProfileInfos = null;
        private List<CubeViewProfileInfo> cubeViewProfileInfos = null;
        private HttpClient httpClient = new HttpClient();

        public FormMain()
        {
            InitializeComponent();
            this.logonStatus = LogonStatusType.LoggedOff;

            this.ucLogon1 = new ucLogon(this.httpClient);
            this.ucLogon1.LogonCompleted += new ucLogon.LogonCompletedHandler(this.Logon_OnLogonCompleted);
            
            ShowLoginPage();
        }

        public void ShowLoginPage()
        {
            this.ucLogon1.Location = new System.Drawing.Point(430, 230);
            this.ucLogon1.Size = new System.Drawing.Size(480, 300);
            this.ucLogon1.Anchor = AnchorStyles.Top;
            this.pnlMain.Controls.Add(this.ucLogon1);
        }

        public void ShowApplicationsPage()
        {
            this.ucApplications1 = new ucApplications(this.httpClient, this.si, this.applications, this.selectedApplication, this.dashboardProfileInfos);
            this.ucApplications1.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(this.ucApplications1);
            
            this.ucApplications1.ShowApplications();
            this.ucApplications1.ShowDashboardsProfileInfo();
        }

        private void Logon_OnLogonCompleted(object sender, EventArgs e)
        {
            if (ucLogon1.AuthenticationResult == AuthenticationResult.Success)
            {
                this.si = ucLogon1.SI;
                this.applications = ucLogon1.Applications;
                this.selectedApplication = ucLogon1.SelectedApplication;
                this.dashboardProfileInfos = ucLogon1.OpenApplicationResponseDto.DashboardProfiles;
                this.cubeViewProfileInfos = ucLogon1.OpenApplicationResponseDto.CubeViewProfiles;
                this.logonStatus = LogonStatusType.LoggedOn;
                this.lblStatus.Text = "Logged On";
                this.lblStatus.ForeColor = System.Drawing.Color.Blue;

                ShowApplicationsPage();
            }
        }
    }
}
