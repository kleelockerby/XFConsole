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

        /*public List<XFApplication> Applications { get; set; }
        public List<CubeViewProfileInfo> CubeViewProfiles { get; set; }
        public List<DashboardProfileInfo> DashboardProfiles { get; set; }
        public WorkflowInitInfo WorkflowInitInfo { get; set; }
        public AppPropsSummaryInfo AppProperties { get; set; }
        public UserAppSettings UserAppSettings { get; set; }
        public PovDisplayInfo PovDisplayInfo { get; set; }
        public AjaxFileAndFolderHierarchy AppDocumentsHierarchy { get; set; }
        public TimeDimAppInfo TimeDimAppInfo { get; set; }*/

        public XFOneStream() { }

        public XFOneStream(string userName, string password, XFApplication selectedApplication)
        {
            this.User = new XFUser(userName, password);
            this.selectedApplication = selectedApplication;
            
        }
    }
}
