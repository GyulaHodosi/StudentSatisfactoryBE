using StudentSatisfactoryBackend.Models;
using System.Threading.Tasks;
using StudentSatisfactoryBackend.Models.RequestModels;
using Microsoft.AspNetCore.Identity;
using StudentSatisfactoryBackend.Services.PayloadManager;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    public class LoginManager : ILoginManager
    {
        private readonly UserManager<User> _userManager;
        private readonly PayloadCreater _payloadCreater;
        public LoginManager(UserManager<User> userManager)
        {
            _userManager = userManager;
            _payloadCreater = new PayloadCreater();
        }

        public async Task<UserDetails> Login(string tokenId)
        {
            var payload = await _payloadCreater.CreatePayloadAsync(tokenId);

            return payload != null ? await GetOrCreateExternalLoginUser("google", payload.Subject, payload.Email, payload.GivenName, payload.FamilyName, payload.Picture) : null;

        }
        private async Task<UserDetails> GetOrCreateExternalLoginUser(string provider, string key, string email, string firstName, string lastName, string pictureLink)
        {
            // Login already linked to a user
            var user = await _userManager.FindByLoginAsync(provider, key);
            if (user != null)
                return new UserDetails { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Course = "", UserRole = "student" };

            user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // No user exists with this email address, we create a new one
                user = new User
                {
                    Email = email,
                    UserName = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PictureLink = pictureLink
                };

                await _userManager.CreateAsync(user);
            }

            // Link the user to this login
            var info = new UserLoginInfo(provider, key, provider.ToUpperInvariant());
            var result = await _userManager.AddLoginAsync(user, info);
            if (result.Succeeded)
                return new UserDetails { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Course = "", UserRole = "student" };

            return null;
        }

    }
}
