using StudentSatisfactoryBackend.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackToSend>> GetAllFeedbacks();
        Task<IEnumerable<FeedbackToSend>> GetTop10Feedbacks();
        Task<IEnumerable<FeedbackToSend>> GetAllFeedbacksOfMonth(DateTime date);
        Task<IEnumerable<FeedbackToSend>> GetTop10FeedbacksOfMonth(DateTime date);
        Task<IEnumerable<FeedbackToSend>> ListFeedbacksByUser(string userId);
        Task<IEnumerable<FeedbackToSend>> GetAllFeedbacksOfMonthByCity(DateTime date, string city);
        Task<IEnumerable<FeedbackToSend>> GetAllFeedbacksOfMonthByCourse(DateTime date, int courseId);
        Task<IEnumerable<FeedbackToSend>> GetAllFeedbacksOfMonthByCityAndCourseId(DateTime date, string city, int courseId);
        Task<IEnumerable<int>> GetVotedFeedbackIdsByUserId(string userId);
        Task<FeedbackToSend> GetFeedbackById(int id);
        Task<int> AddFeedback(string userId, string title, int courseId, string city);
        Task<bool> VoteFeedback(int id, string userId);
        Task<bool> RemoveVoteFromFeedback(int id, string userId);
    }
}
