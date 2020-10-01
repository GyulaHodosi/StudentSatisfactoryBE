using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class UserVote
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public Feedback Feedback { get; set; }
        public int FeedbackId { get; set; }
    }
}
