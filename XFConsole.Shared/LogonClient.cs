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
    public class LogonClient
    {
        private readonly HttpClient Http;

        private const string urlBase = "https://localhost:44382/api/internal";
        private const string logonUrlBase = "authentication/logon";
        private const string openApplicationUrlBase = "authentication/openapplication";
        private const string getApplicationsUrlBase = "authentication/getapplications";

        private string logonUrl = "";
        private string openApplicationUrl = "";
        private string getApplicationsUrl = "";
        private UserPreferences userPreferences = null;

        private string selectedApplicationName = "GolfStreamDemo_v36";
        public string SelectedApplicationName
        {
            get { return selectedApplicationName; }
            set 
            { 
                selectedApplicationName = value; 
            }

        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public SessionInfo SI { get; set; }

        public List<CubeViewProfileInfo> CubeViewProfiles { get; set; } = new List<CubeViewProfileInfo>();
        public List<DashboardProfileInfo> DashboardProfiles { get; set; } = new List<DashboardProfileInfo>();
        public WorkflowInitInfo WorkflowInitInfo { get; set; }
        public AppPropsSummaryInfo AppProperties { get; set; }
        public UserAppSettings UserAppSettings { get; set; }
        public PovDisplayInfo PovDisplayInfo { get; set; }
        public AjaxFileAndFolderHierarchy AppDocumentsHierarchy { get; set; }
        public TimeDimAppInfo TimeDimAppInfo { get; set; }

        public LogonClient(HttpClient httpClient)
        {
            this.Http = httpClient;
        }

        public LogonClient(HttpClient httpClient, string userName, string password)
        {
            this.Http = httpClient;
            this.UserName = userName;
            this.Password = password;
        }

        public LogonClient(HttpClient httpClient, string userName, string password, string selectedApplicationName)
        {
            this.Http = httpClient;
            this.UserName = userName;
            this.Password = password;
            this.selectedApplicationName = selectedApplicationName;
        }

        public async Task GetLogon()
        {
            this.logonUrl = $"{urlBase}/{logonUrlBase}";
            this.openApplicationUrl = $"{urlBase}/{openApplicationUrlBase}";
            this.getApplicationsUrl = $"{urlBase}/{getApplicationsUrlBase}";

            Guid xfAppGuid = new Guid(GetSelectedApplicationStringId(this.selectedApplicationName));
            XFApplication xfApplication = new XFApplication(xfAppGuid, "", "", "", "");
            XFLogonRequestDto logonModel = new XFLogonRequestDto() { ClientModuleType = ClientModuleType.Web, ClientXFVersion = XFVersionInfo.XFVersion };

            if ((!string.IsNullOrEmpty(this.UserName)) && (!string.IsNullOrEmpty(this.Password)))
            {
                logonModel.UserName = this.UserName;
                logonModel.PasswordOrToken = this.Password;
                logonModel.SelectedApplication = xfApplication;
            }

            HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFLogonRequestDto>(this.logonUrl, logonModel);
            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                XFLogonResponseDto xfLogonResponseDto = await responseMessage?.Content?.ReadFromJsonAsync<XFLogonResponseDto>();
                if (xfLogonResponseDto != null)
                {
                    this.SI = xfLogonResponseDto.SI;
                    this.userPreferences = xfLogonResponseDto.UserPreferences;
                    AuthenticationResult authenticationResult = xfLogonResponseDto.AuthenticationResult;
                }
            }
        }

        public async Task<List<XFApplication>> GetApplications()
        {
            List<XFApplication> applications = null;
            XFBaseSiRequestDto siDto = new XFBaseSiRequestDto(this.SI);
            HttpResponseMessage applicationsResponse = await this.Http?.PostAsJsonAsync<XFBaseSiRequestDto>(this.getApplicationsUrl, siDto);

            if (applicationsResponse != null && applicationsResponse.IsSuccessStatusCode)
            {
                XFApplicationsResponseDto xfApplicationsResponseDto = await applicationsResponse?.Content?.ReadFromJsonAsync<XFApplicationsResponseDto>();
                if (xfApplicationsResponseDto != null)
                {
                    applications = xfApplicationsResponseDto.Applications;
                    if (applications?.Count == 1)
                    {
                        this.selectedApplicationName = applications[0].Name;
                    }
                }
            }
            return applications;
        }

        public async Task OpenApplicationAsync(string selectedApplicationName)
        {
            XFOpenApplicationRequestDto openApplicationRequestDto = new XFOpenApplicationRequestDto(this.SI, selectedApplicationName);
            HttpResponseMessage responseMessage = await this.Http?.PostAsJsonAsync<XFOpenApplicationRequestDto>(this.openApplicationUrl, openApplicationRequestDto);

            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                var jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions();
                jsonSerializerOptions.Converters.Add(new JsonNonStringKeyDictionaryConverter());
                jsonSerializerOptions.Converters.Add(new WorkflowInfoCallbacksConverter());

                XFOpenApplicationResponseDto openApplicationResponseDto = await responseMessage.Content?.ReadFromJsonAsync<XFOpenApplicationResponseDto>(jsonSerializerOptions);

                if (openApplicationResponseDto != null)
                {
                    this.DashboardProfiles = openApplicationResponseDto.DashboardProfiles;
                    this.CubeViewProfiles = openApplicationResponseDto.CubeViewProfiles;
                    this.WorkflowInitInfo = openApplicationResponseDto.WorkflowInitInfo;
                    this.AppProperties = openApplicationResponseDto.AppProperties;
                    this.UserAppSettings = openApplicationResponseDto.UserAppSettings;
                    this.PovDisplayInfo = openApplicationResponseDto.PovDisplayInfo;
                    this.AppDocumentsHierarchy = openApplicationResponseDto.AppDocumentsHierarchy;
                    this.TimeDimAppInfo = openApplicationResponseDto.TimeDimAppInfo;
                }
            }
        }

        private string GetSelectedApplicationStringId(string selectedApplicationName)
        {
            string selectedApplicationId = string.Empty;
            switch (selectedApplicationName)
            {
                case "GolfStreamDemo_v36":
                    selectedApplicationId = "56ae220f-4bc8-4a96-9fa5-e622381b027a";
                    break;
                case "OneStream_GolfStream":
                    selectedApplicationId = "c4174af1-6c5d-456f-b3b1-da1583482774";
                    break;
                case "EZCorp":
                    selectedApplicationId = "ac7a2dc8-aa0c-438a-a3c8-fdba48f350d0";
                    break;
                case "MarketPlace":
                    selectedApplicationId = "290f545a-44fc-4e01-b0aa-ea2d322825a9";
                    break;
                case "OneStream_Planning":
                    selectedApplicationId = "290f545a-44fc-4e01-b0aa-ea2d322825a9";
                    break;
            }
            return selectedApplicationId;
        }
    }
}
