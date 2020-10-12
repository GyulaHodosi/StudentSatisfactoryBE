using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Repositories.NewsRepository.Interfaces;
using StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _repository;
        private readonly IUserRepository _userRepository;
        public NewsController(INewsRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            try
            {
                var news = await _repository.GetAllNews();
                return Ok(news);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNews(int id)
        {
            try
            {
                var news = await _repository.GetNewsById(id);
                return Ok(news);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<News>> AddNews(NewsPostRequest data)
        {
            var user = await _userRepository.GetUserByTokenId(data.TokenId);
            if (user == null || user.Role == "user")
                return Unauthorized();

            var result = await _repository.AddNews(user.Id, data.Description, DateTime.Now);
            if (result)
                return Created("New feedback added", result);

            return BadRequest();
        }
    }
}
