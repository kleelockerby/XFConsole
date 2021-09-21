using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XFConsole.Desktop.UserControls
{
    public partial class Applications : UserControl
    {
        public Applications()
        {
            InitializeComponent();

            lvApplications.Columns.Add(new ColumnHeader() { Name = "ApplicationName", Text = "Application Name", TextAlign = HorizontalAlignment.Center });
        }
    }
}
