using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;
using OneStreamWebUI.Shared;
using OneStream.Client.SharedUI;

namespace XFConsole.Shared
{
    public class AuthenticationDataAccess
    {
        private HttpClient Http;
        private static AuthenticationDataAccess authenticationDataAccess;
        //private List<XFApplication> applications = null;

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
    }
}