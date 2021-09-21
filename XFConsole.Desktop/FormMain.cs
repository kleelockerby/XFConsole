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
using System.Windows.Forms;
using OneStream.Shared.Wcf;
using XFConsole.Shared;
using OneStreamWebUI.Shared;
using OneStream.Shared.Common;

namespace XFConsole.Desktop
{
    public partial class FormMain : Form
    {
        private XFOneStream oneStreamModel = null;
        private AuthenticationDataAccess authenticationDataAccess = null;
        private HttpClient httpClient = new HttpClient();

        private Logon ucLogon = null;
        private Applications ucApplications = null;
        private Dashboards ucDashboards = null;

        public FormMain()
        {
            InitializeComponent();
            ucLogon = new Logon(httpClient, oneStreamModel);
            ucApplications = new Applications();
            ucDashboards = new Dashboards();
            
        }

        private void btnLoginMain_Click(object sender, EventArgs e)
        {
            this.pnlRight.Controls.Clear();
            this.pnlRight.Controls.Add(ucLogon);
        }

        private void btnApplicationsMain_Click(object sender, EventArgs e)
        {
            this.pnlRight.Controls.Clear();
            this.pnlRight.Controls.Add(ucApplications);
        }

        private void btnDashboardsMain_Click(object sender, EventArgs e)
        {
            this.pnlRight.Controls.Clear();
            this.pnlRight.Controls.Add(ucDashboards);
        }
    }
}
