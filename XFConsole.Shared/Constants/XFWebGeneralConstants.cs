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
        internal const string LogonUrl = "authentication/logon";
        internal const string GetApplicationsUrl = "authentication/getapplications";
        internal const string OpenApplicationUrl = "authentication/openapplication";

        // CubeViews
        internal const string GetDataCellsCompressedForCubeViewsUrl = BaseUrl + "cubeviews/GetDataCellsCompressed";
        internal const string GetCubeViewItemsInProfileUrl = BaseUrl + "cubeViews/GetCubeViewItemsInProfile";
    }
}
