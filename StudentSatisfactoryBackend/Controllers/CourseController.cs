using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Repositories;
using StudentSatisfactoryBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(SurveyContext context)
        {
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
    }
}
