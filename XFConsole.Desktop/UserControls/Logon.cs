using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using OneStream.Shared.Wcf;
using XFConsole.Shared;
using OneStreamWebUI.Shared;
using OneStream.Shared.Common;

namespace XFConsole.Desktop.UserControls
{
    public partial class Logon : UserControl
    {
        private HttpClient Http;
        //private string selectedAppName = "GolfStreamDemo_v36";

        public XFAuthenticationData AuthenticationData { get; set; }
        public XFApplicationData ApplicationData { get; set; }

        public delegate void LogonCompletedHandler(object sender, EventArgs e);
        public event LogonCompletedHandler LogonCompleted;

        public Logon(HttpClient httpClient)
        {
            InitializeComponent();
            this.Http = httpClient;
        }

        private async void btnLogon_Click(object sender, EventArgs e)
        {
            AuthenticationDataAccess authenticationDataAccess = AuthenticationDataAccess.Create(this.Http);
            this.AuthenticationData = await authenticationDataAccess.GetLogonAsync(txtUserName.Text, txtPassword.Text, txtSelectedAppName.Text);
            this.ApplicationData = await authenticationDataAccess.GetApplicationsAsync(this.AuthenticationData, txtSelectedAppName.Text);
            await authenticationDataAccess.OpenApplicationAsync(this.AuthenticationData.SI, this.ApplicationData);

            OnLogonCompleted(new EventArgs());
        }

        private void OnLogonCompleted(EventArgs e)
        {
            if (LogonCompleted != null)
            {
                LogonCompleted(this, e);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

    }
}
