using Microsoft.AspNetCore.Identity;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Services.LogoutManager.Interfaces;
using StudentSatisfactoryBackend.Services.PayloadManager;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Services.LogoutManager
{
    public class LogoutManager : ILogoutManager
    {
        private UserManager<User> _userManager;
        private readonly PayloadCreater _payloadCreater;

        public LogoutManager(UserManager<User> userManager)
        {
            _userManager = userManager;
            _payloadCreater = new PayloadCreater();
        }

        public async Task<bool> Logout(string tokenId)
        {
            var payload = await _payloadCreater.CreatePayloadAsync(tokenId);

            var user = await _userManager.FindByLoginAsync("google", payload.Subject);

            if (user == null)
            {
                return false;
            }

            var result = await _userManager.RemoveLoginAsync(user, "google", payload.Subject);

            return result.Succeeded;

        }
    }
}