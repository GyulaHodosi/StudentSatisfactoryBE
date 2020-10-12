using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories.NewsRepository.Interfaces;
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


        public async Task<IEnumerable<News>> GetAllNews()
        {
            var news = await _context.News.ToListAsync();
            return news;
        }

        public async Task<News> GetNewsById(int id)
        {
            var news = await _context.News.FirstOrDefaultAsync(n => n.Id == id);
            return news;
        }
        public async Task<News> AddNews(string userId, string userName, string description, DateTime date)
        {
            try
            {
                var newPost = new News(userId, userName, description, date);
                _context.News.Add(newPost);
                await _context.SaveChangesAsync();
                return newPost;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
    }
}
