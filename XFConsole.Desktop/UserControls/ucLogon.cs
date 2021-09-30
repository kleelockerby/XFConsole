using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using XFConsole.Shared;
using OneStream.Shared.Wcf;
using OneStreamWebUI.Shared;
using OneStream.Shared.Common;

namespace XFConsole.Desktop.UserControls
{
    public partial class ucLogon : UserControl
    {
        private HttpClient Http;
        private AuthenticationDataAccess authenticationDataAccess;

        public delegate void LogonCompletedHandler(object sender, LogonCompleteEventArgs e);
        public event LogonCompletedHandler LogonCompleted;

        public ucLogon(HttpClient http)
        {
            InitializeComponent();
            this.Http = http;
            this.authenticationDataAccess = AuthenticationDataAccess.Create(this.Http);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            XFLogonResponseDto logonResponsDto = await this.authenticationDataAccess.LogonUserAsync(this.txtUserName.Text, this.txtPassword.Text, cboApplications.Text);
            if (logonResponsDto != null)
            {
                AuthenticationResult authenticationResult = logonResponsDto.AuthenticationResult;
                if ((logonResponsDto.AuthenticationResult == AuthenticationResult.Success) && (logonResponsDto.SI != null) && (logonResponsDto.SI.IsAuthenticated))
                {
                    XFApplicationsResponseDto applicationsResponseDto = await authenticationDataAccess.GetApplicationsAsync(logonResponsDto.SI);
                    if ((applicationsResponseDto != null) && (applicationsResponseDto.Applications?.Count > 0))
                    {
                        List<XFApplication> applications = applicationsResponseDto.Applications;
                        if (applications?.Count > 0)
                        {
                            OnLogonCompleted(new LogonCompleteEventArgs(authenticationResult, applications, cboApplications.Text, logonResponsDto.SI));
                        }
                    }
                } 
            }
        }

        private void OnLogonCompleted(LogonCompleteEventArgs e)
        {
            if (LogonCompleted != null)
            {
                LogonCompleted(this, e);
            }
        }
    }
}