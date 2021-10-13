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
            int column1Width = (lvParamDisplayInfos.Width / 2) + 74;
            int colum2Width = lvParamDisplayInfos.Width - column1Width;
            lvParamDisplayInfos.Columns.Add(new ColumnHeader() { Name = "columnHeader1", Text = "DashboardParamDisplayInfos", Width = column1Width });
            lvParamDisplayInfos.Columns.Add(new ColumnHeader() { Name = "columnHeader2", Text = " ", Width = colum2Width });
        }

        public void ShowProperties(object dashboardObject, DashboardInfoPropertyType dashboardInfoPropertyType)
        {
            if (dashboardInfoPropertyType == DashboardInfoPropertyType.DashboardProfile)
            {
                DashboardProfile dashboardProfile = dashboardObject as DashboardProfile;

                this.txtProp.SelectionColor = Color.Black;
                this.txtProp.AppendText("Dashboard Profile:   ");
                this.txtProp.SelectionColor = Color.Blue;
                this.txtProp.AppendText(dashboardProfile.NameOrDescription);
                this.propertyGridDashboardInfo.SelectedObject = dashboardProfile;
            }
            else if (dashboardInfoPropertyType == DashboardInfoPropertyType.Dashboard)
            {
                Dashboard dashboard = dashboardObject as Dashboard;

                this.txtProp.SelectionColor = Color.Black;
                this.txtProp.AppendText("Dashboard:   ");
                this.txtProp.SelectionColor = Color.Blue;
                this.txtProp.AppendText(dashboard.NameOrDescription);
                this.propertyGridDashboardInfo.SelectedObject = dashboard;
            }
        }

        public void ShowParamDisplayInfos(DashboardParamDisplayInfos paramDisplayInfos)
        {
            var param = paramDisplayInfos;
            ListViewItem lv1 = new ListViewItem(new string[] { "ItemName", paramDisplayInfos.ItemName });
            ListViewItem lv2 = new ListViewItem(new string[] { "ItemDescription", paramDisplayInfos.ItemDescription });
            ListViewItem lv3 = new ListViewItem(new string[] { "UsesLoadDashboardExtenderBR", paramDisplayInfos.UsesLoadDashboardExtenderBR.ToString() });
            ListViewItem lv4 = new ListViewItem(new string[] { "DisplayInfos", "{List}" });
            ListViewItem lv5 = new ListViewItem(new string[] { "CustSubstVarsAlreadyResolved", "{Dictionary}" });
            ListViewItem lv6 = new ListViewItem(new string[] { "UnresolvedCustSubstVars", "{Dictionary}" });
            ListViewItem lv7 = new ListViewItem(new string[] { "CustSubstVarsRepresentedByComponents", "{Dictionary}" });

            
            this.lvParamDisplayInfos.Items.AddRange(new ListViewItem [] { lv1, lv2, lv3, lv4, lv5, lv6, lv7 });
        }
    }
}
