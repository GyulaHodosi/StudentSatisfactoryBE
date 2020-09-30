using Microsoft.AspNetCore.Mvc;
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

        //[HttpPost]
        //public async
    }
}
