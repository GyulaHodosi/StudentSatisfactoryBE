using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces
{
    interface IUserRepository
    {
        void AddUser(User user);
        void EditUser(User user);
        void Deleteuser(User user);
        Task<UserQuestion> GetAllAnswersByUser(string userId);
        Task<bool> SetCourseToUser(CourseToUser courseToUser);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(string id);

        Task<User> GetUserByTokenId(string tokenId);
    }
}
