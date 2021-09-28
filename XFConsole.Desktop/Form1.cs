using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Form1 : Form
    {
        private LogonStatusType logonStatus = LogonStatusType.Unknown;
        private HttpClient httpClient = new HttpClient();
        private Logon ucLogon = null;
        private Applications ucApplications = null;

        private XFAuthenticationData authenticationData = null;
        private XFApplicationData applicationData = null;

        public Form1()
        {
            InitializeComponent();
            ShowLogon();
        }

        private void ShowLogon()
        {
            this.ucLogon = new Logon(httpClient);
            this.ucLogon.LogonCompleted += new Logon.LogonCompletedHandler(this.Logon_OnLogonCompleted);
            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(this.ucLogon);
        }

        private void ShowApplications()
        {
            this.ucApplications = new Applications(httpClient, this.authenticationData.SI);
            this.ucApplications.ShowApplications(applicationData);
            this.ucApplications.Dock = DockStyle.Fill;

            this.pnlMain.Controls.Clear();
            this.pnlMain.Controls.Add(ucApplications);
        }


        private void Logon_OnLogonCompleted(object sender, EventArgs e)
        {
            if (ucLogon.AuthenticationData.AuthenticationResult == AuthenticationResult.Success)
            {
                this.logonStatus = LogonStatusType.LoggedOn;
                this.authenticationData = ucLogon.AuthenticationData;
                this.applicationData = ucLogon.ApplicationData;
                this.lblStatus.Text = "Logged On";
                ShowApplications();
            }
            else
            {
                this.lblStatus.Text = "Logon Error";
            }
        }
    }
}
