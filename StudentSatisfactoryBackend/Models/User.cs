﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSatisfactoryBackend.Models
{
    public class User : IdentityUser
    {
        public string Course { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureLink { get; set; }

        public User()
        {

        }

        public User(string course, string city, string email, string username)
        {
            Course = course;
            City = city;
            Email = email;
            UserName = username;
        }
        
    }
}
