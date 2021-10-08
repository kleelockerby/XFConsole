using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFConsole.Shared
{
    public class ApplicationSelectedEventArgs
    {
        public string ApplicationName { get; set; }

        public ApplicationSelectedEventArgs(string applicationName)
        {
            this.ApplicationName = applicationName;
        }
    }
}
