using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.common.Security;
using meridian.smolensk.proto;

namespace smolensk.Services.Interfaces
{
    public interface IOAuth
    {
        string ServerCode { get; set; }
        string UserId { get; set; }
        string UserEmail { get; set; }
        string UserFirstName { get; set; }
        string UserLastName { get; set; }
        void GetToken();
        void GetProfile();
    }
}