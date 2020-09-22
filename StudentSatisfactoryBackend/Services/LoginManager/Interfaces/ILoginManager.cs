using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    interface ILoginManager
    {
        public User Login(Object creds);
    }
}
