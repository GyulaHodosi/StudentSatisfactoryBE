using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models.RequestModels
{
    public class UserProfile
    {
        public string CourseName { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureLink { get; set; }
    }
}
