using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;

namespace XFConsole.Shared
{
    public class XFOneStream
    {
        private XFApplication selectedApplication = null;

        public XFApplication SelectedApplication
        {
            get { return selectedApplication; }
            set
            {
                selectedApplication = value;
            }
        }

        public SessionInfo SI { get; set; }
        public XFUser User { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }
        public XFOneStreamApplicationData ApplicationData { get; set; }

        public DashboardProfileInfo SelectedDashboardProfileInfo { get; set; }
        public List<Dashboard> DashboardsInPofile { get; set; }

        public XFOneStream() { }

        public XFOneStream(string userName, string password, XFApplication selectedApplication)
        {
            this.User = new XFUser(userName, password);
            this.selectedApplication = selectedApplication;
            this.ApplicationData = new XFOneStreamApplicationData();
            this.SelectedDashboardProfileInfo = new DashboardProfileInfo();
            this.DashboardsInPofile = new List<Dashboard>();
        }
    }
}
