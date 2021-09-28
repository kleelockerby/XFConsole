using System.Collections.Generic;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;

namespace XFConsole.Shared
{
    public class XFApplicationData
    {
        public List<XFApplication> Applications { get; set; }
        public XFApplication SelectedApplication { get; set; }
        public List<CubeViewProfileInfo> CubeViewProfileInfos { get; set; }
        public List<DashboardProfileInfo> DashboardProfileInfos { get; set; }
        public WorkflowInitInfo WorkflowInitInfo { get; set; }
        public AppPropsSummaryInfo AppProperties { get; set; }
        public UserAppSettings UserAppSettings { get; set; }
        public PovDisplayInfo PovDisplayInfo { get; set; }
        public AjaxFileAndFolderHierarchy AppDocumentsHierarchy { get; set; }
        public TimeDimAppInfo TimeDimAppInfo { get; set; }

        public XFApplicationData()
        {
            this.Applications = new List<XFApplication>();
            this.CubeViewProfileInfos = new List<CubeViewProfileInfo>();
            this.DashboardProfileInfos = new List<DashboardProfileInfo>();
        }

        public XFApplicationData(List<XFApplication> applications)
        {
            this.Applications = applications;
            this.CubeViewProfileInfos = new List<CubeViewProfileInfo>();
            this.DashboardProfileInfos = new List<DashboardProfileInfo>();
        }

        public void ClearData()
        {
            this.Applications.Clear();
            this.CubeViewProfileInfos.Clear();
            this.DashboardProfileInfos.Clear();
            this.SelectedApplication = null;
            this.WorkflowInitInfo = null;
            this.AppProperties = null;
            this.UserAppSettings = null;
            this.PovDisplayInfo = null;
            this.AppDocumentsHierarchy = null;
            this.TimeDimAppInfo = null;
        }
    }
}
