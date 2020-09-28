using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Repositories;
using StudentSatisfactoryBackend.Repositories.CourseRepository;
using StudentSatisfactoryBackend.Repositories.CourseRepository.Interfaces;
using StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces;
using StudentSatisfactoryBackend.Repositories.UserRepsitory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public ProfileController(SurveyContext context, UserManager<User> userManager)
        {
            _userRepository = new UserRepository(context, userManager);
            _courseRepository = new CourseRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<UserProfile>> GetProfile(string tokenId)
        {
            var user = await _userRepository.GetUserByTokenId(tokenId);
            UserProfile userProfile;
            if (user != null)
            {
                var courseName = _courseRepository.GetCourseByIdAsync(user.CourseId).Result.Name;
                userProfile = new UserProfile { CourseName = courseName, FirstName = user.FirstName, LastName = user.LastName, City = user.City, PictureLink = user.PictureLink };
                return Ok(userProfile);
            }

            return NotFound();
        }

        [HttpGet("/courses")]
        public async Task<ActionResult<IEnumerable<string>>> GetCoureses()
        {
            var courses = await _courseRepository.GetAllCourse();
            if(courses.Count() != 0)
            {
                return Ok(courses);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SetCourseToUser([FromBody] CourseToUser courseToUser)
        {
            var result = await _userRepository.SetCourseToUser(courseToUser);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
