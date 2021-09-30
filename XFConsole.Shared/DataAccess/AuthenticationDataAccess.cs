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
        private List<XFApplication> applications = null;

        private AuthenticationDataAccess() { }

        public static AuthenticationDataAccess Create(HttpClient httpClient)
        {
            authenticationDataAccess = new AuthenticationDataAccess();
            authenticationDataAccess.Http = httpClient;
            return authenticationDataAccess;
        }

        public async Task<XFLogonResponseDto> LogonUserAsync(string userName, string password, string selectedApplicationName)
        {
            try
            {
                Guid xfAppGuid = new Guid(HttpClientHelper.GetSelectedApplicationStringId(selectedApplicationName));
                XFApplication selectedApplication = new XFApplication(xfAppGuid, selectedApplicationName, "", "", "");
                XFLogonRequestDto logonModel = new XFLogonRequestDto() { ClientModuleType = ClientModuleType.Web, ClientXFVersion = XFVersionInfo.XFVersion };
                logonModel.UserName = userName;
                logonModel.PasswordOrToken = password;
                logonModel.SelectedApplication = selectedApplication;

                HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFLogonRequestDto>(XFWebGeneralConstants.LogonUrl, logonModel);
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    XFLogonResponseDto logonResponseDto = await responseMessage?.Content?.ReadFromJsonAsync<XFLogonResponseDto>();
                    if (logonResponseDto != null)
                    {
                        return logonResponseDto;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
        }

        public async Task<XFApplicationsResponseDto> GetApplicationsAsync(SessionInfo si)
        {
            try
            {
                XFBaseSiRequestDto siDto = new XFBaseSiRequestDto(si);
                HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFBaseSiRequestDto>(XFWebGeneralConstants.GetApplicationsUrl, siDto);
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    XFApplicationsResponseDto applicationsResponseDto = await responseMessage?.Content?.ReadFromJsonAsync<XFApplicationsResponseDto>();
                    if ((applicationsResponseDto != null) && (applicationsResponseDto?.Applications?.Count > 0))
                    {
                        this.applications = applicationsResponseDto.Applications;
                        return applicationsResponseDto;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
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
            return null;
        }

        public XFApplication GetSelectedApplication(string selectedApplicationName, out int selectedIndex)
        {
            selectedIndex = -1;
            XFApplication selectedApp = null;
            for (int i = 0; i < this.applications.Count; i++)
            {
                XFApplication xfApplication = this.applications[i];
                if (this.applications[i].Name == selectedApplicationName)
                {
                    selectedIndex = i;
                    selectedApp = this.applications[i];
                }
            }
            return selectedApp;
        }



        public async Task<XFAuthenticationData> GetLogonAsync(string userName, string password, string selectedApplicationName)
        {
            try
            {
                XFAuthenticationData authenticationData = new XFAuthenticationData(userName, password, selectedApplicationName);
                Guid xfAppGuid = new Guid(HttpClientHelper.GetSelectedApplicationStringId(authenticationData.SelectedApplicationName));
                XFApplication selectedApplication = new XFApplication(xfAppGuid, selectedApplicationName, "", "", "");

                XFLogonRequestDto logonModel = new XFLogonRequestDto() { ClientModuleType = ClientModuleType.Web, ClientXFVersion = XFVersionInfo.XFVersion };
                logonModel.UserName = userName;
                logonModel.PasswordOrToken = password;
                logonModel.SelectedApplication = selectedApplication;

                HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFLogonRequestDto>(XFWebGeneralConstants.LogonUrl, logonModel);
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    XFLogonResponseDto logonResponseDto = await responseMessage?.Content?.ReadFromJsonAsync<XFLogonResponseDto>();
                    if (logonResponseDto != null)
                    {
                        if ((logonResponseDto.AuthenticationResult == AuthenticationResult.Success) && (logonResponseDto.SI != null) && (logonResponseDto.SI.IsAuthenticated))
                        {
                            authenticationData.AuthenticationResult = logonResponseDto.AuthenticationResult;
                            authenticationData.User.UserPreferences = logonResponseDto.UserPreferences;
                            authenticationData.SI = logonResponseDto.SI;
                        }
                    }
                }
                return authenticationData;
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
        }
        public async Task<XFApplicationData> GetApplicationsAsync(XFAuthenticationData authenticationData, string selectedApplicationName)
        {
            try
            {
                XFApplicationData applicationData = null;
                XFBaseSiRequestDto siDto = new XFBaseSiRequestDto(authenticationData.SI);
                HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFBaseSiRequestDto>(XFWebGeneralConstants.GetApplicationsUrl, siDto);
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    XFApplicationsResponseDto xfApplicationsResponseDto = await responseMessage?.Content?.ReadFromJsonAsync<XFApplicationsResponseDto>();
                    if (xfApplicationsResponseDto != null)
                    {
                        if (xfApplicationsResponseDto.Applications?.Count > 0)
                        {
                            this.applications = xfApplicationsResponseDto.Applications;
                            applicationData = new XFApplicationData(this.applications);
                            applicationData.SelectedApplication = GetSelectedApplication(selectedApplicationName, out int index);

                            if (xfApplicationsResponseDto.Applications?.Count == 1)
                            {
                                applicationData.SelectedApplication = xfApplicationsResponseDto.Applications[0];
                            }
                        }
                    }
                }
                return applicationData;
            }
            catch (Exception ex)
            {
                throw new XFException(ex);
            }
        }
        public async Task OpenApplicationAsync(SessionInfo si, XFApplicationData applicationData)
        {
            Guid xfAppGuid = new Guid(HttpClientHelper.GetSelectedApplicationStringId(applicationData.SelectedApplication.Name));
            //applicationData.SelectedApplication = new XFApplication(xfAppGuid, selectedApplicationName, "", "", "");

            XFOpenApplicationRequestDto openApplicationRequestDto = new XFOpenApplicationRequestDto(si, applicationData.SelectedApplication.Name);
            HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFOpenApplicationRequestDto>(XFWebGeneralConstants.OpenApplicationUrl, openApplicationRequestDto);
            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                var jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions();
                jsonSerializerOptions.Converters.Add(new JsonNonStringKeyDictionaryConverter());
                jsonSerializerOptions.Converters.Add(new WorkflowInfoCallbacksConverter());

                XFOpenApplicationResponseDto openApplicationResponseDto = await responseMessage.Content?.ReadFromJsonAsync<XFOpenApplicationResponseDto>(jsonSerializerOptions);

                if (openApplicationResponseDto != null)
                {
                    applicationData.DashboardProfileInfos = openApplicationResponseDto.DashboardProfiles;
                    applicationData.CubeViewProfileInfos = openApplicationResponseDto.CubeViewProfiles;
                    applicationData.WorkflowInitInfo = openApplicationResponseDto.WorkflowInitInfo;
                    applicationData.AppProperties = openApplicationResponseDto.AppProperties;
                    applicationData.UserAppSettings = openApplicationResponseDto.UserAppSettings;
                    applicationData.PovDisplayInfo = openApplicationResponseDto.PovDisplayInfo;
                    applicationData.AppDocumentsHierarchy = openApplicationResponseDto.AppDocumentsHierarchy;
                    applicationData.TimeDimAppInfo = openApplicationResponseDto.TimeDimAppInfo;
                }
            }
        }
        
    }
}