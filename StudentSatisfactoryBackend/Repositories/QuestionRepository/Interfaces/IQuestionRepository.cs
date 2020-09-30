using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.Interfaces
{
    interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestion(int questionId);
        Task<IEnumerable<UserQuestion>> GetAllAnswersOfQuestionByWeek(DateTime date,int questionId);
        Task<Question> GetQuestionById(int id);
        void AddQuestion(Question question);
        void EditQuestion(Question question);
        void DeleteQuestion(Question question);
    }
}
