using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Services.LoginManager;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginManager _loginManager;

        public LoginController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        [HttpGet]
        public string GetClientId()
        {
            return Startup.ClientData.ClientId;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginData loginData)
        {
            var result = await _loginManager.Login(loginData.TokenId);
            if (result)
            {
                return Ok();
            }

            return StatusCode(500);
        }

    }
}
