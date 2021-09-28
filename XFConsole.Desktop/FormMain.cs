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
using OneStream.Shared.Wcf;
using XFConsole.Shared;
using OneStreamWebUI.Shared;
using OneStream.Shared.Common;

namespace XFConsole.Desktop
{
    public partial class FormMain : Form
    {
        private LogonStatusType logonStatus = LogonStatusType.Unknown;


        public FormMain()
        {
            InitializeComponent();
            this.logonStatus = LogonStatusType.LoggedOff;
        }

        public void AddLoginPage()
        {

        }
    }
}
