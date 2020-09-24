using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories.CourseRepository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.CourseRepository
{
    public class CourseRepository : ICourseGetter
    {
        private readonly SurveyContext _context;

        public CourseRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(string courseName)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Name == courseName);
        }
    }
}
