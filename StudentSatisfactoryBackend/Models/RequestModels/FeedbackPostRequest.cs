namespace StudentSatisfactoryBackend.Models.RequestModels
{
    public class FeedbackPostRequest
    {
        public string TokenId { get; set; }
        public string Title { get; set; }
        public bool Anonymus { get; set; }
    }
}
