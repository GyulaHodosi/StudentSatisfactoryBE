using StudentSatisfactoryBackend.Models.RequestModels;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    interface ILoginManager
    {
        public Task<bool> Login(string tokenId);
    }
}
