﻿using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("questions")]
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
            return BadRequest();
        }
    }
}
