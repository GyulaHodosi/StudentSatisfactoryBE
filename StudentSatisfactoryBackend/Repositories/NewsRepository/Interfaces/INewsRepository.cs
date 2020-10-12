using StudentSatisfactoryBackend.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.NewsRepository.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<NewsToSend>> GetAllNews();
        Task<NewsToSend> GetNewsById(int id);
        Task<bool> AddNews(string userId, string description, DateTime date);
    }
}
