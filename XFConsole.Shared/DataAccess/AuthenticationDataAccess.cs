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
    public class AuthenticationDataAccess
    {
        private HttpClient Http;
        private static AuthenticationDataAccess authenticationDataAccess;

        private AuthenticationDataAccess() {}

        public static AuthenticationDataAccess Create(HttpClient httpClient)
        {
            authenticationDataAccess = new AuthenticationDataAccess();
            authenticationDataAccess.Http = httpClient;
            return authenticationDataAccess;
        }

        public async Task<XFOneStream> GetLogonAsync(XFLogonRequestDto logonModel)
        {
            try
            {
                XFOneStream oneStreamModel = new XFOneStream(logonModel.UserName, logonModel.PasswordOrToken, logonModel.SelectedApplication);
                HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFLogonRequestDto>(XFWebGeneralConstants.LogonUrl, logonModel);
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    XFLogonResponseDto logonResponseDto = await responseMessage?.Content?.ReadFromJsonAsync<XFLogonResponseDto>();
                    if (logonResponseDto != null)
                    {
                        if ((logonResponseDto.AuthenticationResult == AuthenticationResult.Success) && (logonResponseDto.SI != null) && (logonResponseDto.SI.IsAuthenticated))
                        {
                            oneStreamModel.AuthenticationResult = logonResponseDto.AuthenticationResult;
                            oneStreamModel.User.UserPreferences = logonResponseDto.UserPreferences;

                            XFBaseSiRequestDto siDto = new XFBaseSiRequestDto(logonResponseDto.SI);
                            HttpResponseMessage applicationsResponse = await this.Http?.PostAsJsonAsync<XFBaseSiRequestDto>(XFWebGeneralConstants.GetApplicationsUrl, siDto);
                            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                            {
                                XFApplicationsResponseDto xfApplicationsResponseDto = await applicationsResponse?.Content?.ReadFromJsonAsync<XFApplicationsResponseDto>();
                                if (xfApplicationsResponseDto != null)
                                {
                                    if (xfApplicationsResponseDto.Applications?.Count == 1)
                                    {
                                        oneStreamModel.SelectedApplication = xfApplicationsResponseDto.Applications[0];
                                    }
                                }
                            }
                        }
                    }
                }
                return oneStreamModel;
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
        }

        public async Task OpenApplicationAsync(XFOpenApplicationRequestDto openApplicationRequestDto, XFOneStream oneStreamModel)
        {
            oneStreamModel.ApplicationData.ClearData();
            HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFOpenApplicationRequestDto>(XFWebGeneralConstants.OpenApplicationUrl, openApplicationRequestDto);
            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                var jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions();
                jsonSerializerOptions.Converters.Add(new JsonNonStringKeyDictionaryConverter());
                jsonSerializerOptions.Converters.Add(new WorkflowInfoCallbacksConverter());

                XFOpenApplicationResponseDto openApplicationResponseDto = await responseMessage.Content?.ReadFromJsonAsync<XFOpenApplicationResponseDto>(jsonSerializerOptions);

                if (openApplicationResponseDto != null)
                {
                    oneStreamModel.ApplicationData.DashboardProfiles = openApplicationResponseDto.DashboardProfiles;
                    oneStreamModel.ApplicationData.CubeViewProfiles = openApplicationResponseDto.CubeViewProfiles;
                    oneStreamModel.ApplicationData.WorkflowInitInfo = openApplicationResponseDto.WorkflowInitInfo;
                    oneStreamModel.ApplicationData.AppProperties = openApplicationResponseDto.AppProperties;
                    oneStreamModel.ApplicationData.UserAppSettings = openApplicationResponseDto.UserAppSettings;
                    oneStreamModel.ApplicationData.PovDisplayInfo = openApplicationResponseDto.PovDisplayInfo;
                    oneStreamModel.ApplicationData.AppDocumentsHierarchy = openApplicationResponseDto.AppDocumentsHierarchy;
                    oneStreamModel.ApplicationData.TimeDimAppInfo = openApplicationResponseDto.TimeDimAppInfo;
                }
            }
        }
    }
}
