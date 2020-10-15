using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSatisfactoryBackend.Models
{
    public class User : IdentityUser
    {
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureLink { get; set; }
        public string Role { get; set; }

        public User()
        {

        }

        public User(int courseId, string city, string email, string username, string role)
        {
            CourseId = courseId;
            City = city;
            Email = email;
            UserName = username;
            Role = role;
        }
        
    }
}
