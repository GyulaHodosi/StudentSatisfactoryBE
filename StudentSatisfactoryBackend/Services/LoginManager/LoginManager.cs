using StudentSatisfactoryBackend.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StudentSatisfactoryBackend.Services.PayloadManager;
using StudentSatisfactoryBackend.Data;
using System.Linq;

namespace StudentSatisfactoryBackend.Services.LoginManager
{
    public class LoginManager : ILoginManager
    {
        private readonly UserManager<User> _userManager;
        private readonly PayloadCreater _payloadCreater;
        private readonly SurveyContext _context;

        public LoginManager(UserManager<User> userManager, SurveyContext context)
        {
            _userManager = userManager;
            _payloadCreater = new PayloadCreater();
            _context = context;
        }

        public async Task<bool> Login(string tokenId)
        {
            var payload = await _payloadCreater.CreatePayloadAsync(tokenId);

            return payload != null ? await GetOrCreateExternalLoginUser("google", payload.Subject, payload.Email, payload.GivenName, payload.FamilyName, payload.Picture) : false;

        }
        private async Task<bool> GetOrCreateExternalLoginUser(string provider, string key, string email, string firstName, string lastName, string pictureLink)
        {
            // Login already linked to a user
            var user = await _userManager.FindByLoginAsync(provider, key);
            if (user != null)
                return true;

            user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Email = email,
                    UserName = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PictureLink = pictureLink,
                    Role = _context.AdminEmails.Any(ae => ae.Email == email) ? "admin" : "user"
                };

                await _userManager.CreateAsync(user);
            }

            // Link the user to this login
            var info = new UserLoginInfo(provider, key, provider.ToUpperInvariant());
            var result = await _userManager.AddLoginAsync(user, info);
            
            return result.Succeeded;
        }

    }
}
