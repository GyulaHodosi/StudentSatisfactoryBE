using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class News
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public News(string userId, string userName, string description, DateTime date)
        {
            UserId = userId;
            UserName = userName;
            Description = description;
            Date = date;
        }
    }
}
