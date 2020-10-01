using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<IEnumerable<Feedback>> GetTop10Feedbacks();
        Task<IEnumerable<Feedback>> GetAllFeedbacksOfWeek(DateTime date);
        Task<IEnumerable<Feedback>> GetTop10FeedbacksOfWeek(DateTime date);
        Task<IEnumerable<Feedback>> ListFeedbacksByUser(string userId);
        Task<Feedback> GetFeedbackById(int id);
        Task<bool> AddFeedback(string userId, string title);
        Task<bool> VoteFeedback(int id, string userId);
        Task<bool> RemoveVoteFromFeedback(int id, string userId);
    }
}
