using System.Collections.Generic;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;

namespace XFConsole.Shared
{
    public class XFAuthenticationData
    {
        public SessionInfo SI { get; set; }
        public UserPreferences UserPreferences { get; set; }
        public string ServerErrorMsg { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }
        public XFUser User { get; set; }
        public string SelectedApplicationName { get; set; }

        public XFAuthenticationData() { }
        public XFAuthenticationData(string userName, string password, string selectedApplicationName)
        {
            this.User = new XFUser(userName, password);
            this.SelectedApplicationName = selectedApplicationName;
        }
    }
}
