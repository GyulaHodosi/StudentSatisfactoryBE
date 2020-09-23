using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.DependencyInjection;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    public class LoginManager : ILoginManager
    {
        private readonly SurveyContext _surveyContext;
        public LoginManager(SurveyContext context)
        {
            _surveyContext = context;
        }
        private User Register(Object creds)
        {
            throw new NotImplementedException();
        }

        private bool IsAuthenticated(Object creds)
        {
            throw new NotImplementedException();
        }
        public async Task<User> Login(string creds)
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
