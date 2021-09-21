using System;
using System.Collections.Generic;

namespace XFConsole.Shared
{
    public static class XFWebGeneralConstants
    {
        // EndpointUrl constants.
        private const string BaseUrl = "https://localhost:44382/api/internal/";

        // AdminGrid
        internal const string GetActiveCubeDimensionsUrl = BaseUrl + "admingrid/GetActiveCubeDimensions";
        internal const string GetSheetLayoutUrl = BaseUrl + "admingrid/GetSheetLayout";

        // Authentication
        internal const string LogonUrl = BaseUrl + "authentication/logon";
        internal const string GetApplicationsUrl = BaseUrl + "authentication/getapplications";
        internal const string OpenApplicationUrl = BaseUrl + "authentication/openapplication";

        // Dashboards
        internal const string ExecuteSelectionChangedServerTaskUrl = BaseUrl + "dashboards/ExecuteSelectionChangedServerTask";
        internal const string GetDashboardDisplayInfoUrl = BaseUrl + "dashboards/GetDashboardDisplayInfo";
        internal const string GetDashboardsInProfileUrl = BaseUrl + "dashboards/GetDashboardsInProfile";
        internal const string GetParameterDisplayInfosUsingDashboardNameUrl = BaseUrl + "dashboards/GetParameterDisplayInfosUsingDashboardName";

        // CubeViews
        internal const string GetDataCellsCompressedForCubeViewsUrl = BaseUrl + "cubeviews/GetDataCellsCompressed";
        internal const string GetCubeViewItemsInProfileUrl = BaseUrl + "cubeViews/GetCubeViewItemsInProfile";
    }
}
