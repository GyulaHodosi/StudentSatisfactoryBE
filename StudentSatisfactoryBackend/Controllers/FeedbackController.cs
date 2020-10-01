using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackController(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            try
            {
                var feedbacks = await _repository.GetAllFeedbacks();
                return Ok(feedbacks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("week")]
        public async Task<IActionResult> GetAllFeedbacksByWeek()
        {
            try
            {
                var feedbacks = await _repository.GetAllFeedbacksOfWeek(DateTime.Now);
                return Ok(feedbacks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedback(int id)
        {
            try
            {
                var feedback = await _repository.GetFeedbackById(id);
                return Ok(feedback);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> AddFeedback(string userId, string title)
        {
            var result = await _repository.AddFeedback(userId, title);
            if (result)
                return Created("New ingredient created", "");

            return BadRequest();
        }

        [HttpPut("{id}/vote")]
        public async Task<IActionResult> VoteFeedback(int id)
        {
            var result = await _repository.VoteFeedback(id);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}/remove")]
        public async Task<IActionResult> RemoveVote(int id)
        {
            var result = await _repository.RemoveVoteFromFeedback(id);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTop10Feedbacks()
        {
            try
            {
                var feedbacks = await _repository.GetTop10Feedbacks();
                return Ok(feedbacks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("by/{userId}")]
        public async Task<IActionResult> GetFeedbacksByUser(string userId)
        {
            try
            {
                var feedbacks = await _repository.ListFeedbacksByUser(userId);
                return Ok(feedbacks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}
