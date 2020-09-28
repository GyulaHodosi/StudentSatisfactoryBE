namespace StudentSatisfactoryBackend.Models
{
    public class UserQuestion
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
