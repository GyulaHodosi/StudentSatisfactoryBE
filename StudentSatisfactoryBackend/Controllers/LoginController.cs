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
using Microsoft.AspNetCore.Identity;
using Google.Apis.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginManager _loginManager;
        private readonly UserManager<User> _userManager;

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
            Payload payload;
            User user = null;

            if ( !Request.Headers.ContainsKey("X-Requested-With"))
            {
                return BadRequest();
            }

            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(tokenId,
                    new ValidationSettings
                    {
                        Audience = new[] { Startup._clientData.ClientId }
                    });
            } catch (InvalidJwtException e)
            {
                return BadRequest();
            }

            return user;
        }

        public async Task<User> GetOrCreateExternalLoginUser(string provider, string key, string email, string firstName, string lastName)
        {
            // Login already linked to a user
            var user = await _userManager.FindByLoginAsync(provider, key);
            if (user != null)
                return user;

            user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // No user exists with this email address, we create a new one
                user = new User
                {
                    Email = email,
                    UserName = email,
                    FirstName = firstName,
                    LastName = lastName
                };

                await _userManager.CreateAsync(user);
            }

            // Link the user to this login
            var info = new UserLoginInfo(provider, key, provider.ToUpperInvariant());
            var result = await _userManager.AddLoginAsync(user, info);
            if (result.Succeeded)
                return user;

            return null;
        }
    }
}
