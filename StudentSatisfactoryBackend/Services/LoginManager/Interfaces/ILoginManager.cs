using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    public interface ILoginManager
    {
        Task<bool> Login(string tokenId);
    }
}
