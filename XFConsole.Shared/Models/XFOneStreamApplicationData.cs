using System;
using System.Collections.Generic;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;

namespace XFConsole.Shared
{
    public class XFOneStreamApplicationData
    {
        public List<XFApplication> Applications { get; set; }
        public List<CubeViewProfileInfo> CubeViewProfiles { get; set; }
        public List<DashboardProfileInfo> DashboardProfiles { get; set; }
        public WorkflowInitInfo WorkflowInitInfo { get; set; }
        public AppPropsSummaryInfo AppProperties { get; set; }
        public UserAppSettings UserAppSettings { get; set; }
        public PovDisplayInfo PovDisplayInfo { get; set; }
        public AjaxFileAndFolderHierarchy AppDocumentsHierarchy { get; set; }
        public TimeDimAppInfo TimeDimAppInfo { get; set; }

        public XFOneStreamApplicationData()
        {
            this.Applications = new List<XFApplication>();
            this.CubeViewProfiles = new List<CubeViewProfileInfo>();
            this.DashboardProfiles = new List<DashboardProfileInfo>();
        }

        public void ClearData()
        {
            this.Applications.Clear();
            this.CubeViewProfiles.Clear();
            this.DashboardProfiles.Clear();
            this.WorkflowInitInfo = null;
            this.AppProperties = null;
            this.UserAppSettings = null;
            this.PovDisplayInfo = null;
            this.AppDocumentsHierarchy = null;
            this.TimeDimAppInfo = null;
        }
    }
}
