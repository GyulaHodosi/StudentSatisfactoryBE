using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSatisfactoryBackend.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public int VoteCount { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public string City { get; set; }

        public Feedback(string userId, string title, int courseId, string city)
        {
            UserId = userId;
            Title = title;
            VoteCount = 1;
            Date = DateTime.Now;
            CourseId = courseId;
            City = city;
        }
    }
}
