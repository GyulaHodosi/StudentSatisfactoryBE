using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestion(int questionId);
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestionByWeek(DateTime date,int questionId);
        Task<Question> GetQuestionById(int id);
        Task<bool> AddQuestion(Question question);
        Task<bool> EditQuestion(Question question);
        void DeleteQuestion(Question question);
    }
}
