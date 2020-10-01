using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
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
        public async Task<bool> AddFeedback(string userId, string title)
        {
            var feedback = new Feedback(userId, title);

            try
            {
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            var feedbacks = await _context.Feedbacks.ToListAsync();
            return feedbacks;
        }

        public Task<IEnumerable<Feedback>> GetAllFeedbacksOfWeek(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(feedback => feedback.Id == id);
            return feedback;
        }

        public async Task<bool> VoteFeedback(int id, string userId)
        {
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(feedback => feedback.Id == id);

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

        public async Task<IEnumerable<Feedback>> GetTop10Feedbacks()
        {
            var feedbacks = await _context.Feedbacks.OrderByDescending(fb => fb.VoteCount).Take(10).ToListAsync();
            return feedbacks;
        }

        public Task<IEnumerable<Feedback>> GetTop10FeedbacksOfWeek(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Feedback>> ListFeedbacksByUser(string userId)
        {
            var feedbacks = await _context.Feedbacks.Where(fb => fb.UserId == userId).ToListAsync();
            return feedbacks;
        }
    }
}
