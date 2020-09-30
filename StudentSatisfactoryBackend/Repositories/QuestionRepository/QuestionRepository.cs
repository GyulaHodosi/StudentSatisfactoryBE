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
        public void AddQuestion(Question question)
        {
            var newQuestion = new Question(question.Title);
            _context.Questions.Add(newQuestion);
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
        }

        public async void EditQuestion(Question question)
        {
            var _question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == question.Id);
            //TODO
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestion(int questionId)
        {
            var userQuestion = await _context.UserQuestions.Where(uq => uq.QuestionId == questionId).ToListAsync();
            return userQuestion;
        }

        public async Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestionByWeek(DateTime date, int questionId)
        {
            var userQuestion = await _context.UserQuestions.Where(uq => uq.QuestionId == questionId).ToListAsync();
            //TODO
            throw new NotImplementedException();
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
    }
}
