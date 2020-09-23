using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.Interfaces
{
    interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        void AddUser(User user);
        void EditUser(User user);
        void Deleteuser(User user);
        Task<UserQuestion> GetAllAnswersByUser(string userId);
    }
}
