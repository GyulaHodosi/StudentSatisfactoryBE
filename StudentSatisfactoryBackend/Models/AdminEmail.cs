namespace StudentSatisfactoryBackend.Models
{
    public class AdminEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public AdminEmail(string email)
        {
            Email = email;
        }
    }
}
