using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories
{
    public class CourseRepository : ICourseRepository
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
    }
}
