using StudentSatisfactoryBackend.RequestModels;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    interface ILoginManager
    {
        public Task<UserDetails> Login(string tokenId);
    }
}
