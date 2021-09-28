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
        private LogonStatusType LogonStatus = LogonStatusType.Unknown;
        //private XFOneStream oneStreamModel = null;
        private XFAuthenticationData authenticationData = null;
        private XFApplicationData applicationData = null;
        private HttpClient httpClient = new HttpClient();

        private Logon ucLogon = null;
        private Applications ucApplications = null;
        private UserControls.DashboardProperties ucDashboards = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnLoginMain_Click(object sender, EventArgs e)
        {
            SetLogonForm();
        }

        private void btnApplicationsMain_Click(object sender, EventArgs e)
        {
            SetApplicationsForm();
        }

        private void btnDashboardsMain_Click(object sender, EventArgs e)
        {
            SetDashboardsForm();
        }

        private void SetLogonForm()
        {
            this.pnlRight.Controls.Clear();
            this.pnlRight.Controls.Add(ucLogon);
        }

        private void SetApplicationsForm()
        {
            this.pnlRight.Controls.Clear();
            this.pnlRight.Controls.Add(ucApplications);
        }

        private void SetDashboardsForm()
        {
            this.pnlRight.Controls.Clear();
            this.pnlRight.Controls.Add(ucDashboards);
        }

        private void SetLogonStatus(LogonStatusType logonStatus)
        {
            this.lblLogonStatus.Text = (logonStatus == LogonStatusType.LoggedOn) ? "Logged On" : "Logged Off";
            this.lblLogonStatus.ForeColor = (logonStatus == LogonStatusType.LoggedOn) ? System.Drawing.SystemColors.Highlight : System.Drawing.Color.Red;
        }

        private void Logon_OnLogonCompleted(object sender, EventArgs e)
        {
            AuthenticationResult authResult = ucLogon.AuthenticationData.AuthenticationResult;
            this.lblLogonStatus.Text = authResult.ToString();

            this.authenticationData = ucLogon.AuthenticationData;
            this.applicationData = ucLogon.ApplicationData;
            this.btnApplicationsMain.BackColor = System.Drawing.SystemColors.ActiveCaption;


            SetApplicationsForm();
            ucApplications.ShowApplications(applicationData);
        }
    }
}
