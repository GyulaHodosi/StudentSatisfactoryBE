using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly SurveyContext _context;

        public FeedbackRepository(SurveyContext context)
        {
            _context = context;
        }

        private List<FeedbackToSend> CreateFeedbackToSend(IEnumerable<Feedback> feedbacks)
        {
            var feedsToSend = new List<FeedbackToSend>();
            foreach (var feedback in feedbacks)
            {
                if (feedback != null)
                {
                    var user = feedback.UserId == null ? null : _context.Users.Find(feedback.UserId);
                    feedsToSend.Add(new FeedbackToSend
                    {
                        Id = feedback.Id,
                        Date = $"{feedback.Date.Year}-{feedback.Date.Month}-{feedback.Date.Day}",
                        Title = feedback.Title,
                        UserName = user == null ? "anonymus" : $"{user.FirstName} {user.LastName}",
                        VoteCount = feedback.VoteCount
                    });

                }
            }
            return feedsToSend;
        }

        public async Task<int> AddFeedback(string userId, string title, int courseId, string city)
        {
            var feedback = new Feedback(userId, title, courseId, city);

            try
            {
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();
                return feedback.Id;
            }
            catch (DbUpdateException)
            {

                return -1;
            }
        }

        public async Task<IEnumerable<FeedbackToSend>> GetAllFeedbacks()
        {
            var feedbacks= await _context.Feedbacks.OrderByDescending(f => f.VoteCount).ToArrayAsync();
            var toReturn = CreateFeedbackToSend(feedbacks);
            return toReturn.Count > 0 ? toReturn : null;
        }

        public async Task<IEnumerable<FeedbackToSend>> GetAllFeedbacksOfMonth(DateTime date)
        {
            var feedbacks = await _context.Feedbacks.Where(f => f.Date.Month == date.Month)
                .OrderByDescending(f => f.VoteCount)
                .ToArrayAsync();
            var feedsToSend = CreateFeedbackToSend(feedbacks);
            return feedsToSend.Count > 0 ? feedsToSend : null;
        }

        public async Task<IEnumerable<FeedbackToSend>> GetAllFeedbacksOfMonthByCity(DateTime date, string city)
        {
            var feedbacks = await _context.Feedbacks.Where(f => f.Date.Month == date.Month && f.City == city)
                .OrderByDescending(f => f.VoteCount)
                .ToArrayAsync();
            var feedsToSend = CreateFeedbackToSend(feedbacks);
            return feedsToSend.Count > 0 ? feedsToSend : null;
        }

        public async Task<IEnumerable<FeedbackToSend>> GetAllFeedbacksOfMonthByCourse(DateTime date, int courseId)
        {
            var feedbacks = await _context.Feedbacks.Where(f => f.Date.Month == date.Month && f.CourseId == courseId)
                .OrderByDescending(f => f.VoteCount)
                .ToArrayAsync();
            var feedsToSend = CreateFeedbackToSend(feedbacks);
            return feedsToSend.Count > 0 ? feedsToSend : null;
        }

        public async Task<IEnumerable<FeedbackToSend>> GetAllFeedbacksOfMonthByCityAndCourseId(DateTime date, string city, int courseId)
        {
            var feedbacks = await _context.Feedbacks.Where(f => f.Date.Month == date.Month && f.City == city && f.CourseId == courseId)
                .OrderByDescending(f => f.VoteCount)
                .ToArrayAsync();
            var feedsToSend = CreateFeedbackToSend(feedbacks);
            return feedsToSend.Count > 0 ? feedsToSend : null;
        }

        public async Task<FeedbackToSend> GetFeedbackById(int id)
        {
            var feedback = new Feedback[] { await _context.Feedbacks.FindAsync(id) };
            var feedsToSend = CreateFeedbackToSend(feedback);
            return feedsToSend.Count > 0 ? CreateFeedbackToSend(feedback)[0] : null;
        }

        public async Task<bool> VoteFeedback(int id, string userId)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if(feedback == null) return false;

            var userVote = await _context.UserVotes.FirstOrDefaultAsync(uv => uv.FeedbackId == id && uv.UserId == userId);

            if(userVote == null)
            {               
                try
                {
                    feedback.VoteCount++;
                    _context.UserVotes.Add(new UserVote() { FeedbackId = id, UserId = userId });
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
            return false;

        }

        public async Task<bool> RemoveVoteFromFeedback(int id, string userId)
        {
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(feedback => feedback.Id == id);
            if (feedback == null) return false;

            var userVote = await _context.UserVotes.FirstOrDefaultAsync(uv => uv.FeedbackId == id && uv.UserId == userId);
            
            if(userVote != null)
            {
                try
                {
                    _context.UserVotes.Remove(userVote);
                    feedback.VoteCount--;
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<FeedbackToSend>> GetTop10Feedbacks()
        {
            var feedbacks = await _context.Feedbacks.OrderByDescending(f => f.VoteCount)
                .Take(10)              
                .ToArrayAsync();
            var feedsToSend = CreateFeedbackToSend(feedbacks);
            return feedsToSend.Count > 0 ? feedsToSend : null;
        }

        public async Task<IEnumerable<FeedbackToSend>> GetTop10FeedbacksOfMonth(DateTime date)
        {
            var feedbacks = await _context.Feedbacks.Where(f => f.Date.Month == date.Month)
                .OrderByDescending(f => f.VoteCount)
                .Take(10)            
                .ToArrayAsync();
            var feedsToSend = CreateFeedbackToSend(feedbacks);
            return feedsToSend.Count > 0 ? feedsToSend : null;
        }

        public async Task<IEnumerable<FeedbackToSend>> ListFeedbacksByUser(string userId)
        {
            var feedbacks = await _context.Feedbacks.Where(fb => fb.UserId == userId)
                .ToArrayAsync();
            var feedsToSend = CreateFeedbackToSend(feedbacks);
            return feedsToSend.Count > 0 ? feedsToSend : null;
        }

        public async Task<IEnumerable<int>> GetVotedFeedbackIdsByUserId(string userId)
        {
            return await _context.UserVotes.Where(uv => uv.UserId == userId).Select(uv => uv.FeedbackId).ToArrayAsync();
        }

        public async Task<bool> RemoveFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
                return true;
            _context.Feedbacks.Remove(feedback);
            _context.UserVotes.RemoveRange(_context.UserVotes.Where(uv => uv.FeedbackId == id));
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
