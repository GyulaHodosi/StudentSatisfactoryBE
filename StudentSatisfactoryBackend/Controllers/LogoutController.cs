using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Services.LogoutManager;
using StudentSatisfactoryBackend.Services.LogoutManager.Interfaces;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/logout")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly ILogoutManager _logoutManager;

        public LogoutController(UserManager<User> userManager)
        {
            _logoutManager = new LogoutManager(userManager);
        }

        [HttpPost]
        public async Task<IActionResult> Logout([FromBody] LoginData loginData)
        {
            var result = await _logoutManager.Logout(loginData.TokenId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
