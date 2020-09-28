using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces;
using StudentSatisfactoryBackend.Services.PayloadManager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.UserRepsitory
{
    public class UserRepository : IUserRepository
    {
        private readonly SurveyContext _context;
        private readonly PayloadCreater _creater = new PayloadCreater();
        private readonly UserManager<User> _userManager;

        public UserRepository(SurveyContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<User> GetUserByTokenId(string tokenId)
        {
            var payload = await _creater.CreatePayloadAsync(tokenId);
            if (payload == null)
            {
                return null;
            }
            var user = await _userManager.FindByLoginAsync("google", payload.Subject);
            return user;
        }

        public async Task<bool> SetCourseToUser(CourseToUser courseToUser)
        {
            var user = await GetUserByTokenId(courseToUser.TokenId);
            if (user == null)
                return false;
            user.Course = courseToUser.CourseName;
            try
            {
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
