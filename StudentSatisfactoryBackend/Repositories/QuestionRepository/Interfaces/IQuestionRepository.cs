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
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfUser(string userId);
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestionByWeek(DateTime date,int questionId);
        Task<Question> GetQuestionById(int id);
        Task<bool> AddQuestion(string title);
        Task<bool> EditQuestion(int id, string title);
        Task<bool> DeleteQuestion(int questionId);
        Task<bool> AddAnswer(string title, string userId, int questionId, int value);
    }
}
