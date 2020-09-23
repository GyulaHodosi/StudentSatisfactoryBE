using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public int VoteCount { get; set; }
        public DateTime Date { get; set; }

        public Feedback(string userId, string title)
        {
            UserId = userId;
            Title = title;
            VoteCount = 0;
            Date = DateTime.Now;
        }
    }
}
