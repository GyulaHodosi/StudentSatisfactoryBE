using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Services.LogoutManager.Interfaces
{
    public interface ILogoutManager
    {
        public Task<bool> Logout(string tokenId);

    }
}