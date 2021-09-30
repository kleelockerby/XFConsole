using System.Collections.Generic;
using OneStream.Shared.Common;
using OneStream.Shared.Wcf;

namespace XFConsole.Shared
{
    public class LogonCompleteEventArgs
    {
        public AuthenticationResult AuthenticationResult { get; set; }
        public List<XFApplication> Applications { get; set; }
        public string SelectedApplicationName { get; set; }
        public SessionInfo SI { get; set; }

        public LogonCompleteEventArgs(AuthenticationResult authenticationResult, List<XFApplication> applications, string selectedApplicationName, SessionInfo si)
        {
            this.AuthenticationResult = authenticationResult;
            this.Applications = applications;
            this.SelectedApplicationName = selectedApplicationName;
            this.SI = si;
        }
    }
}
