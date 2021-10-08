using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using OneStreamWebUI.Shared;
using OneStreamWebUI.Client.Dashboards;

namespace XFConsole.Shared
{
    public class DashboardDataAccess
    {
        private HttpClient Http;
        private static DashboardDataAccess dashboardDataAccess;

        private DashboardDataAccess() { }

        public static DashboardDataAccess Create(HttpClient httpClient)
        {
            dashboardDataAccess = new DashboardDataAccess();
            dashboardDataAccess.Http = httpClient;
            return dashboardDataAccess;
        }

        public async Task<List<Dashboard>> GetDashboardsInProfile(SessionInfo si, Guid dashboardProfileId)
        {
            List<Dashboard> dashboardsInProfile = null;
            XFGetDashboardsInProfileRequestDto getDashboardsInProfileRequestDto = new XFGetDashboardsInProfileRequestDto(si, false, dashboardProfileId, DashboardUIPlatformType.WpfOrSilverlight, true);
            HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFGetDashboardsInProfileRequestDto>(XFWebGeneralConstants.GetDashboardsInProfileUrl, getDashboardsInProfileRequestDto);

            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                dashboardsInProfile = await responseMessage?.Content?.ReadFromJsonAsync<List<Dashboard>>();
            }
            return dashboardsInProfile;
        }

        public async Task<DashboardParamDisplayInfos> GetLoadDashboardInfo(SessionInfo si, string dashboardName)
        {
            try
            {
                DashboardParamDisplayInfos paramDisplayInfos = null;
                XFWebDashboardPageOrDlgHelper webDashboardPageOrDlgHelper = new XFWebDashboardPageOrDlgHelper(si, null, false, dashboardName, null, null);
                LoadDashboardInfo loadDashboardInfo = webDashboardPageOrDlgHelper.CreateLoadDashboardInfo(LoadDashboardReasonType.Initialize, LoadDashboardActionType.BeforeFirstGetParameters, null, null);

                XFGetParameterDisplayInfosRequestDto getParameterDisplayInfosRequestDto = new XFGetParameterDisplayInfosRequestDto(si, loadDashboardInfo, true, null);
                HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFGetParameterDisplayInfosRequestDto>(XFWebGeneralConstants.GetParameterDisplayInfosUsingDashboardNameUrl, getParameterDisplayInfosRequestDto);
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    paramDisplayInfos = await responseMessage?.Content?.ReadFromJsonAsync<DashboardParamDisplayInfos>();
                }
                return paramDisplayInfos;
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
        }
    }
}
