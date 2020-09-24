using StudentSatisfactoryBackend.Models.RequestModels;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces
{
    public interface IUserCorseSetter
    {
        Task<bool> SetCourseToUser(CourseToUser courseToUser);
    }
}
