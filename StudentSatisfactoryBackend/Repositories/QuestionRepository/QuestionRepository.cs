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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SurveyContext _context;

        public QuestionRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions;
        }

        public Task<Question> GetQuestionById(int id)
        {
            var question = _context.Questions.FirstOrDefaultAsync(q => q.Id == id);
            return question;
        }

        public async Task<bool> AddQuestion(string title)
        {
            try
            {
                var newQuestion = new Question(title);
                _context.Questions.Add(newQuestion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteQuestion(int questionId)
        {
            try
            {
                var question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == questionId);
                _context.Questions.Remove(question);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> EditQuestion(int id, string title)
        {
            try
            {
                var _question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == id);
                _question.Title = title;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestion(int questionId)
        {
            var userQuestions = await _context.UserQuestions.Where(uq => uq.QuestionId == questionId).ToListAsync();
            return userQuestions;
        }

        public async Task<IEnumerable<UserQuestion>> GetAllAnswersOfUser(string userId)
        {
            var userQuestions = await _context.UserQuestions.Where(uq => uq.UserId == userId).ToListAsync();
            return userQuestions;
        }

        public async Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestionByWeek(DateTime date, int questionId)
        {
            var userQuestion = await _context.UserQuestions.Where(uq => uq.QuestionId == questionId).ToListAsync();
            //TODO
            throw new NotImplementedException();
        }

        public async Task<bool> AddAnswer(string description, string userId, int questionId, int value)
        {
            var response = new UserQuestion()
            {
                Description = description,
                QuestionId = questionId,
                UserId = userId,
                Value = value
            };

            try
            {
                _context.UserQuestions.Add(response);
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
