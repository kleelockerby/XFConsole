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
        private HttpClient httpClient = new HttpClient();
        private LogonStatusType logonStatus = LogonStatusType.Unknown;
        private ucLogon ucLogon1 = null;
        private ucApplications ucApplications1 = null;

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

        public void ShowApplicationsPage(SessionInfo si, List<XFApplication> applications, string selectedApplicationName)
        {
            this.ucApplications1 = new ucApplications(this.httpClient, applications);
            this.ucApplications1.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(this.ucApplications1);

            this.ucApplications1.ShowApplications(si, selectedApplicationName);
            this.ucApplications1.ShowDashboardsProfileInfo();
        }

        private void Logon_OnLogonCompleted(object sender, LogonCompleteEventArgs e)
        {
            AuthenticationResult authenticationResult = e.AuthenticationResult;
            ShowApplicationsPage(e.SI, e.Applications, e.SelectedApplicationName);
        }
    }
}
