using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using OneStream.Shared.Wcf;
using XFConsole.Shared;

namespace XFConsole.ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            LogonClient logonClient = new LogonClient(new HttpClient(), "admin", "123");
            await logonClient.GetLogon();
            List<XFApplication> xfApplications = await logonClient.GetApplications();
            await logonClient.OpenApplicationAsync(xfApplications[1].Name);

            foreach (DashboardProfileInfo dashboardProfile in logonClient.DashboardProfiles)
            {
                string nameOrDescription = dashboardProfile.Profile.NameOrDescription;
                Console.WriteLine(nameOrDescription);
            }
        }
    }
}
