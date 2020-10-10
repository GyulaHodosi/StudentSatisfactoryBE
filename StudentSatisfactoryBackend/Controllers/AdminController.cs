using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Repositories.AdminRepository;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody] string email)
        {
            if (await _adminRepository.AddAdminRoleByEmail(email))
                return Ok();
            return StatusCode(500);
        }
    }
}
