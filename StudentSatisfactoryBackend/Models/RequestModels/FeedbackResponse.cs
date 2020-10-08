using System.Collections.Generic;

namespace StudentSatisfactoryBackend.Models.RequestModels
{
    public class FeedbackResponse
    {
        public IEnumerable<FeedbackToSend> Feedbacks { get; set; }
        public IEnumerable<int> VotedFeedbackIds { get; set; }
    }
}
