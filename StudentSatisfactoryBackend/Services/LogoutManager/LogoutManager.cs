using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Services.LogoutManager.Interfaces;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace StudentSatisfactoryBackend.Services.LogoutManager
{
    public class LogoutManager : ILogoutManager
    {
        private UserManager<User> _userManager;

        public LogoutManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Logout(string tokenId)
        {
            Payload payload;
            try
            {
                payload = await ValidateAsync(tokenId,
                    new ValidationSettings
                    {
                        Audience = new[] { Startup.ClientData.ClientId }
                    });
            }
            catch (InvalidJwtException)
            {
                return false;
            }

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