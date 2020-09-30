using Google.Apis.Auth;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace StudentSatisfactoryBackend.Services.PayloadManager
{
    public class PayloadCreater
    {
        public async Task<Payload> CreatePayloadAsync(string tokenId)
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
               payload = null;
            }
            return payload;
        }
    }
}
