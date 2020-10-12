using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Models.RequestModels;
using StudentSatisfactoryBackend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _repository;
        public QuestionController(IQuestionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var questions = await _repository.GetAllQuestions();
                return Ok(questions);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            try
            {
                var question = await _repository.GetQuestionById(id);
                return Ok(question);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Question>> AddQuestion(string title)
        {
            var result = await _repository.AddQuestion(title);
            if (result)
                return Created("New question added", "");

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveQuestion(int id)
        {
            var result = await _repository.DeleteQuestion(id);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("responses/of/{surveyId}")]
        public async Task<IActionResult> GetResponsesOfSurvey(int surveyId)
        {
            try
            {
                var answers = await _repository.GetAllAnswersOfSurvey(surveyId);
                return Ok(answers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}/responses")]
        public async Task<IActionResult> GetResponsesOfQuestion(int id)
        {
            try
            {
                var answers = await _repository.GetAllAnswersOfQuestion(id);
                return Ok(answers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("by/{userId}/responses")]
        public async Task<IActionResult> GetResponsesOfUser(string userId)
        {
            try
            {
                var answers = await _repository.GetAllAnswersOfUser(userId);
                return Ok(answers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}/responses/{surveyId}")]
        public async Task<IActionResult> GetResponsesOfQuestionBySurvey(int id,int surveyId)
        {
            try
            {
                var answers = await _repository.GetAllAnswersOfQuestionBySurvey(id,surveyId);
                return Ok(answers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("by/{userId}/responses/{surveyId}")]
        public async Task<IActionResult> GetResponsesOfUserBySurvey(string userId, int surveyId)
        {
            try
            {
                var answers = await _repository.GetAllAnswersOfUserBySurvey(surveyId, userId);
                return Ok(answers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost("{questionId}/answer")]
        public async Task<ActionResult<Question>> AddAnswer(string userId, int questionId, int value, int surveyId)
        {
            var answer = new Answer()
            {
                UserId = userId,
                QuestionId = questionId,
                Value = value
            };
            var result = await _repository.AddAnswer(answer, surveyId);
            if (result)
                return Created("New answer posted", "");

            return BadRequest();
        }

        [HttpPost("fill/{surveyId}")]
        public async  Task<ActionResult<SurveyFilled>> FillSurvey(int surveyId, SurveyFilled survey, string userId)
        {
            var canFillOut = await _repository.CheckIfUserCanFillOutSurvey(userId, surveyId); 
            if(!canFillOut)
                return BadRequest("You've already filled out this survey!"); 
            
            foreach(var answer in survey.Answers)
            {
                var result = await _repository.AddAnswer(answer, surveyId);
                if (!result)
                {
                    return BadRequest();
                }
            }
            return Created("New answers posted", "");
        }
    }
}
