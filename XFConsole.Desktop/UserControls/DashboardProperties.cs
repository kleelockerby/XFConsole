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

namespace XFConsole.Desktop.UserControls
{
    public partial class DashboardProperties : UserControl
    {
        private HttpClient Http;
        private DashboardProfile dashboardProfile;

        public DashboardProperties(HttpClient httpClient)
        {
            InitializeComponent();
            this.Http = httpClient;
        }

        public void ShowDashboardProperties(DashboardProfile dashboardProfile)
        {
            this.dashboardProfile = dashboardProfile;
            this.propertyGridDashboardInfo.SelectedObject = dashboardProfile;
        }
    }
}
