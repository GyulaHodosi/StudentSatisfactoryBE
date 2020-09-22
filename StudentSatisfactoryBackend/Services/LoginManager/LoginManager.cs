using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    public class LoginManager : ILoginManager
    {
        private User Register(Object creds)
        {
            throw new NotImplementedException();
        }

        private bool IsAuthenticated(Object creds)
        {
            throw new NotImplementedException();
        }
        public User Login(Object creds)
        {
            bool isAuthenticated = IsAuthenticated(creds);
            User user = null;

            if (isAuthenticated)
            {
                user = new User(); //SurveyContext.GetUser(creds);

                if (user == null)
                {
                    user = Register(creds);
                }

                return user;
            }

            return user;
        }
    }
}
