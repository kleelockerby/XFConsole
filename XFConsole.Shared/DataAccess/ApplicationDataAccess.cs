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
    public class ApplicationDataAccess
    {
        private HttpClient Http;
        private static ApplicationDataAccess applicationDataAccess;

        private ApplicationDataAccess() { }

        public static ApplicationDataAccess Create(HttpClient httpClient)
        {
            applicationDataAccess = new ApplicationDataAccess();
            applicationDataAccess.Http = httpClient;
            return applicationDataAccess;
        }

        public async Task<XFOpenApplicationResponseDto> OpenApplicationAsync(SessionInfo si, string selectedApplicationName)
        {
            XFOpenApplicationRequestDto openApplicationRequestDto = new XFOpenApplicationRequestDto(si, selectedApplicationName);
            HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFOpenApplicationRequestDto>(XFWebGeneralConstants.OpenApplicationUrl, openApplicationRequestDto);
            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                var jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions();
                jsonSerializerOptions.Converters.Add(new JsonNonStringKeyDictionaryConverter());
                jsonSerializerOptions.Converters.Add(new WorkflowInfoCallbacksConverter());

                XFOpenApplicationResponseDto openApplicationResponseDto = await responseMessage.Content?.ReadFromJsonAsync<XFOpenApplicationResponseDto>(jsonSerializerOptions);
                if (openApplicationResponseDto != null)
                {
                    //ToDo: SessionInfo sessionInfo = openApplicationResponseDto.SessionInfo;
                    //ToDo: string applicationDashboardName = XFWebHomePageHelper.GetApplicationDashboardNameFromSettings(openApplicationResponseDto.UserAppSettings);
                    return openApplicationResponseDto;
                }
            }
            else
            {
                var status = responseMessage.StatusCode;
            }
            return null;
        }

        public XFApplication GetSelectedApplication(string selectedApplicationName, List<XFApplication> applications, out int selectedIndex)
        {
            selectedIndex = -1;
            XFApplication selectedApp = null;
            for (int i = 0; i < applications.Count; i++)
            {
                XFApplication xfApplication = applications[i];
                if (applications[i].Name == selectedApplicationName)
                {
                    selectedIndex = i;
                    selectedApp = applications[i];
                }
            }
            return selectedApp;
        }
    }
}
