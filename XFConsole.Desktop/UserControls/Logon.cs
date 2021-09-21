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
        private string initialSelectedApplicationName = "GolfStreamDemo_v36";

        public Logon(HttpClient httpClient, XFOneStream oneStreamModel)
        {
            InitializeComponent();
            this.Http = httpClient;
        }

        private async void btnLogon_Click(object sender, EventArgs e)
        {
            AuthenticationDataAccess authenticationDataAccess = AuthenticationDataAccess.Create(this.Http);
            XFLogonRequestDto logonModel = HttpClientHelper.GetLogon(txtUserName.Text, txtPassword.Text, initialSelectedApplicationName);
        }
    }
}
