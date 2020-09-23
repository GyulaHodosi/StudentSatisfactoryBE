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
        public void AddFeedback(Feedback newfeedback)
        {
            var feedback = new Feedback(newfeedback.UserId, newfeedback.Title);

            _context.Feedbacks.Add(feedback);
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
