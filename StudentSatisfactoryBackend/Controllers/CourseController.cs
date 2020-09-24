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
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseGetter _courseRepository;
        private readonly IUserCorseSetter _userCorseSetter;

        public CourseController(SurveyContext context, UserManager<User> userManager)
        {
            _userCorseSetter = new UserRepository(context, userManager);
            _courseRepository = new CourseRepository(context);
        }

        [HttpGet]
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
            var result = await _userCorseSetter.SetCourseToUser(courseToUser);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
