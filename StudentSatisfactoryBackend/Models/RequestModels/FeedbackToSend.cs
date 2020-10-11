namespace StudentSatisfactoryBackend.Models.RequestModels
{
    public class FeedbackToSend
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public int VoteCount { get; set; }
        public string Date { get; set; }
    }
}
