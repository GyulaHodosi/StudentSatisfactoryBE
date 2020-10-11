using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories.NewsRepository.Interfaces;
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
        public NewsController(INewsRepository repository)
        {
            _repository = repository;
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
        public async Task<ActionResult<News>> AddFeedback(string userId, string userName, string description)
        {
            //TODO only admin can post

            var result = await _repository.AddNews(userId, userName, description, DateTime.Now);

            if (result)
                return Created("New post added", result);

            return BadRequest();
        }
    }
}
