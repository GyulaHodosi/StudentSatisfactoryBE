using StudentSatisfactoryBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.CourseRepository.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourse();

        Task<Course> GetCourseByIdAsync(int courseId);
    }
}
