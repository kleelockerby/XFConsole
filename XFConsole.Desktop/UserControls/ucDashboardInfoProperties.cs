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
    public partial class ucDashboardInfoProperties : UserControl
    {
        public ucDashboardInfoProperties()
        {
            InitializeComponent();
        }

        public void ShowDashboardProperties(object dashboardObject)
        {
            this.propertyGridDashboardInfo.SelectedObject = dashboardObject;
            //this.propertyGridDashboardInfo.SelectedObject = dashboardProfile;
        }
    }
}
