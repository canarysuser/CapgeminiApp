using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapgAppLibrary
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
    public class AppSettings
    {
        public string AppSecret { get; set; }
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public string AppDescription { get; set; }
    }
}
