using Microsoft.AspNetCore.Mvc;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories.ReportRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _repository;

        public ReportController(IReportRepository reportRepository)
        {
            _repository = reportRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            try
            {
                var reports = await _repository.GetAllReports();
                return Ok(reports);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport(int id)
        {
            try
            {
                var report = await _repository.GetReportById(id);
                return Ok(report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Report>> CreateReport(int surveyId)
        {
            //TODO only admins can generate reports

            var result = await _repository.GenerateReport(surveyId);
            if (result)
                return Created("New report created", result);

            return BadRequest();
        }
    }
}
