using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using OneStream.Shared.Wcf;
using XFConsole.Shared;
using OneStreamWebUI.Shared;
using OneStream.Shared.Common;

namespace XFConsole.Desktop.UserControls
{
    public partial class ucLogon : UserControl
    {
        private HttpClient Http;
        public SessionInfo SI { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }
        public List<XFApplication> Applications { get; set; }
        public XFApplication SelectedApplication { get; set; }
        public XFOpenApplicationResponseDto OpenApplicationResponseDto { get; set; }

        public delegate void LogonCompletedHandler(object sender, EventArgs e);
        public event LogonCompletedHandler LogonCompleted;

        public ucLogon(HttpClient http)
        {
            InitializeComponent();
            this.Http = http;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticationDataAccess authenticationDataAccess = AuthenticationDataAccess.Create(this.Http);
            XFLogonResponseDto logonResponsDto = await authenticationDataAccess.LogonUserAsync(this.txtUserName.Text, this.txtPassword.Text, cboApplications.Text);
            if (logonResponsDto != null)
            {
                this.AuthenticationResult = logonResponsDto.AuthenticationResult;
                if ((logonResponsDto.AuthenticationResult == AuthenticationResult.Success) && (logonResponsDto.SI != null) && (logonResponsDto.SI.IsAuthenticated))
                {
                    XFApplicationsResponseDto applicationsResponseDto = await authenticationDataAccess.GetApplicationsAsync(logonResponsDto.SI);
                    if ((applicationsResponseDto != null) && (applicationsResponseDto.Applications?.Count > 0))
                    {
                        this.Applications = applicationsResponseDto.Applications;

                        this.OpenApplicationResponseDto = await authenticationDataAccess.OpenApplicationAsync(logonResponsDto.SI, cboApplications.Text);
                        if (this.OpenApplicationResponseDto != null)
                        {
                            this.SI = this.OpenApplicationResponseDto.SessionInfo;
                            this.SelectedApplication = authenticationDataAccess.GetSelectedApplication(cboApplications.Text, out int index);
                            OnLogonCompleted(new EventArgs());
                        }
                    }
                } 
            }
        }

        private void OnLogonCompleted(EventArgs e)
        {
            if (LogonCompleted != null)
            {
                LogonCompleted(this, e);
            }
        }
    }
}
