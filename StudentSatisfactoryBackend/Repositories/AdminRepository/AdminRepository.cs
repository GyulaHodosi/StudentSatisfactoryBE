using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using System.Data;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly SurveyContext _context;

        public AdminRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAdminRoleByEmail(string email)
        {
            try
            {
                if (await _context.AdminEmails.AnyAsync(ae => ae.Email == email))
                    return true;

                _context.AdminEmails.Add(new AdminEmail(email));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }
        }

    }
}
