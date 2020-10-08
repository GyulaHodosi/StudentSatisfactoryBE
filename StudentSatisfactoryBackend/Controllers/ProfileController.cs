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

        public ProfileController(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<ActionResult<UserProfile>> GetProfile(LoginData data)
        {
            var user = await _userRepository.GetUserByTokenId(data.TokenId);
            UserProfile userProfile;
            if (user != null)
            {
                var course = await _courseRepository.GetCourseByIdAsync(user.CourseId);
                userProfile = new UserProfile { FirstName = user.FirstName, LastName = user.LastName, City = user.City, PictureLink = user.PictureLink };
                userProfile.CourseName = course == null ? "No course yet" : course.Name;
                return Ok(userProfile);
            }

            return NotFound();
        }

        [HttpGet("courses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoureses()
        {
            var courses = await _courseRepository.GetAllCourse();
            if(courses.Count() != 0)
            {
                return Ok(courses);
            }
            return NotFound();
        }

        [HttpPost("changecourse")]
        public async Task<IActionResult> SetCourseToUser([FromBody] CourseToUser courseToUser)
        {
            var result = await _userRepository.SetCourseToUser(courseToUser);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
