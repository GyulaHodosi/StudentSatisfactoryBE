using StudentSatisfactoryBackend.Models;
using System.Threading.Tasks;
using Google.Apis.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;
using StudentSatisfactoryBackend.Models.RequestModels;
using Microsoft.AspNetCore.Identity;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    public class LoginManager : ILoginManager
    {
        private readonly UserManager<User> _userManager;
        public LoginManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDetails> Login(string tokenId)
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
                return null;
            }

            return await GetOrCreateExternalLoginUser("google", payload.Subject, payload.Email, payload.GivenName, payload.FamilyName);

        }
        private async Task<UserDetails> GetOrCreateExternalLoginUser(string provider, string key, string email, string firstName, string lastName)
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
                    LastName = lastName
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
