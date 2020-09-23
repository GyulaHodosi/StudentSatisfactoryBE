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
    public class UserRepository : IUserRepository
    {
        private readonly SurveyContext _context;

        public UserRepository(SurveyContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            var newUser = new User(user.Course, user.City, user.Email, user.UserName);
            _context.RegisteredUsers.Add(newUser);
        }

        public void Deleteuser(User user)
        {
            _context.RegisteredUsers.Remove(user);
        }

        public async void EditUser(User editedUser)
        {
            var _user = await _context.RegisteredUsers.SingleOrDefaultAsync(user => user.Id == editedUser.Id);
            //TODO
        }

        public async Task<UserQuestion> GetAllAnswersByUser(string userId)
        {
            var userQuestion = await _context.UserQuestions.FirstOrDefaultAsync(uq => uq.UserId == userId);
            return userQuestion;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _context.RegisteredUsers.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
