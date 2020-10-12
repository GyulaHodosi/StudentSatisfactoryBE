using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSatisfactoryBackend.Models
{
    public class News
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public News(string userId, string description, DateTime date)
        {
            UserId = userId;
            Description = description;
            Date = date;
        }
    }
}
