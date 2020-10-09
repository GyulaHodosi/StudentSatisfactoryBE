using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Repositories.Interfaces;
using StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces;
using System;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _repository;
        private readonly IUserRepository _userRepository;

        public FeedbackController(IFeedbackRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
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

        [HttpPost("month")]
        public async Task<IActionResult> GetAllFeedbacksByMonth(LoginData data)
        {
            
            var user = await _userRepository.GetUserByTokenId(data.TokenId);
            if (user == null)
                return Unauthorized();
            
            try
            {
                var feedbacks = await _repository.GetAllFeedbacksOfMonthByCityAndCourseId(DateTime.Now, user.City, user.CourseId);
                var votedFeedbacks = await _repository.GetVotedFeedbackIdsByUserId(user.Id);
                return Ok(new FeedbackResponse { Feedbacks = feedbacks, VotedFeedbackIds = votedFeedbacks });
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
        public async Task<ActionResult<Feedback>> AddFeedback(FeedbackPostRequest data)
        {
            var user = await _userRepository.GetUserByTokenId(data.TokenId);
            if (user == null)
                return Unauthorized();

            var result = await _repository.AddFeedback(data.Anonymus ? null : user.Id, data.Title, user.CourseId, user.City);
            if (result >= 0)
                return Created("New feedback added", result);

            return BadRequest();
        }

        [HttpPut("{id}/vote")]
        public async Task<IActionResult> VoteFeedback(VoteRequest data)
        {
            string userId = null;
            var user = await _userRepository.GetUserByTokenId(data.TokenId);
            if (user == null)
                return Unauthorized();
            userId = user.Id;
            
            var result = await _repository.VoteFeedback(data.FeedbackId, userId);
            if (result)
                return Ok();
            return BadRequest("You can't vote. Check, if you've voted before!");
        }

        [HttpPut("{id}/remove")]
        public async Task<IActionResult> RemoveVote(int id, string userId)
        {
            var result = await _repository.RemoveVoteFromFeedback(id, userId);
            if (result)
                return Ok();
            return BadRequest("You can't remove your vote. Check, if you've voted at all!");
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
