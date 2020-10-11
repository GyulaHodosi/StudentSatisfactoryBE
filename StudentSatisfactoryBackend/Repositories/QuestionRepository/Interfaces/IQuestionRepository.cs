using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
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
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfSurvey(int surveyId);
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestionBySurvey(int surveyId, int questionId);
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfUserBySurvey(int surveyId, string userId);
        Task<Question> GetQuestionById(int id);
        Task<bool> AddQuestion(string title);
        Task<bool> EditQuestion(int id, string title);
        Task<bool> DeleteQuestion(int questionId);
        Task<bool> AddAnswer(Answer answer, int surveyId);
    }
}
