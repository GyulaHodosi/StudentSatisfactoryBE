using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Services.LoginManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginManager _loginManager;

        public LoginController(SurveyContext context)
        {
            _loginManager = new LoginManager(context);
        }

        [HttpGet]
        public string GetClientId()
        {
            return Startup._clientData.ClientId;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(string tokenId)
        { 
            if ( !Request.Headers.ContainsKey("X-Requested-With"))
            {
                return BadRequest();
            }

            try
            {
                payload = await VaidateAsync(tokenId)
            }
            User user = await _loginManager.Login(code);
            return user;
        }
    }
}
