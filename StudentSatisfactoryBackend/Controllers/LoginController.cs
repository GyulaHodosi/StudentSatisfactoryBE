using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.RequestModels;
using StudentSatisfactoryBackend.Services.LoginManager;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginManager _loginManager;
        private readonly UserManager<User> _userManager;

        public LoginController()
        {
            _loginManager = new LoginManager(_userManager);
        }

        [HttpGet]
        public string GetClientId()
        {
            return Startup.ClientData.ClientId;
        }

        [HttpPost]
        public async Task<ActionResult<UserDetails>> Login(string tokenId)
        {
            
            UserDetails user = null;

            if ( !Request.Headers.ContainsKey("X-Requested-With"))
            {
                return BadRequest();
            }

            user = await _loginManager.Login(tokenId);
            return user;
        }

    }
}
