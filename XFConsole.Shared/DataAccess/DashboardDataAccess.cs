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

        public async Task GetDashboardsInProfile(XFGetDashboardsInProfileRequestDto getDashboardsInProfileRequestDto, XFOneStream oneStreamModel)
        {
            HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFGetDashboardsInProfileRequestDto>(XFWebGeneralConstants.GetDashboardsInProfileUrl, getDashboardsInProfileRequestDto);

            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                List<Dashboard> dashboardsInProfile = await responseMessage?.Content?.ReadFromJsonAsync<List<Dashboard>>();
                if (dashboardsInProfile?.Count > 0)
                {
                    oneStreamModel.DashboardsInPofile = dashboardsInProfile;
                }
            }
            return;
        }
    }
}
