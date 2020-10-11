using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.NewsRepository.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllNews();
        Task<News> GetNewsById(int id);
        Task<bool> AddNews(string userId, string userName, string description, DateTime date);
    }
}
