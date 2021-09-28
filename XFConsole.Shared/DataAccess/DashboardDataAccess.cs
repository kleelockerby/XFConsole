using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using OneStreamWebUI.Shared;

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
    }
}
