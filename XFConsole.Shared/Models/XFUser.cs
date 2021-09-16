using OneStream.Shared.Wcf;
using OneStreamWebUI.Shared;

namespace XFConsole.Shared
{
    public class XFUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserPreferences UserPreferences { get; set; }

        public XFUser() { }
        public XFUser(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            this.UserPreferences = new UserPreferences();
        }
    }
}
