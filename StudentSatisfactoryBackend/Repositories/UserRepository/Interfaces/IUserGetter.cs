using StudentSatisfactoryBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces
{
    interface IUserGetter
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(string id);

        Task<User> GetUserByTokenId(string tokenId);

    }
}
