using StudentSatisfactoryBackend.Models;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces
{
    interface IUserRepository
    {
        void AddUser(User user);
        void EditUser(User user);
        void Deleteuser(User user);
        Task<UserQuestion> GetAllAnswersByUser(string userId);
    }
}
