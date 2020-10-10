using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Repositories.AdminRepository;
using StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;

        public AdminController(IAdminRepository adminRepository, IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody] string email)
        {
            if (await _adminRepository.AddAdminRoleByEmail(email))
                return Created("Email successfully added", "");
            return StatusCode(500);
        }

        [HttpPost("isadmin")]
        public async Task<IActionResult> IsAdmin(LoginData data)
        {
            var user = await _userRepository.GetUserByTokenId(data.TokenId);
            if (user == null || user.Role == "user")
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
