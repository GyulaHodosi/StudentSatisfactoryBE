using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Repositories.NewsRepository.Interfaces;
using StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.NewsRepository
{
    public class NewsRepository : INewsRepository
    {
        private readonly SurveyContext _context;

        public NewsRepository(SurveyContext context)
        {
            _context = context;
        }

        private NewsToSend GenerateNewsToSend(News news)
        {
            var user = _context.Users.Find(news.UserId);
            return new NewsToSend
            {
                Id = news.Id,
                UserName = $"{user.FirstName} {user.LastName}",
                Date = $"{news.Date.Year}-{news.Date.Month}-{news.Date.Day}",
                Description = news.Description
            };
        }


        public async Task<IEnumerable<NewsToSend>> GetAllNews()
        {
            var news = await _context.News.ToListAsync();
            var newsToSend = new List<NewsToSend>();
            news.ForEach(n => newsToSend.Add(GenerateNewsToSend(n)));
            return newsToSend;
        }

        public async Task<NewsToSend> GetNewsById(int id)
        {
            var news = await _context.News.FindAsync(id);
            return GenerateNewsToSend(news);
        }
        public async Task<bool> AddNews(string userId, string description, DateTime date)
        {
            try
            {
                var newPost = new News(userId, description, date);
                _context.News.Add(newPost);
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
