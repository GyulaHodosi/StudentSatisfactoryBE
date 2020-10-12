using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.AdminRepository
{
    public interface IAdminRepository
    {
        Task<bool> AddAdminRoleByEmail(string email);
    }
}
