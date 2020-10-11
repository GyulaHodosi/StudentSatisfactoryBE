using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories.ReportRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.ReportRepository
{
    public class ReportRepository : IReportRepository
    {
        private readonly SurveyContext _context;

        public ReportRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Report>> GetAllReports()
        {
            var reports = await _context.Reports.ToListAsync();
            foreach(var report in reports)
            {
                var averages = await _context.AverageOfAnswers.Where(avg => avg.ReportId == report.Id).ToListAsync();
                report.AverageOfAnswers = averages;
            }
            return reports;
        }

        public async Task<Report> GetReportById(int id)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(rep => rep.Id == id);
            var averages = await _context.AverageOfAnswers.Where(avg => avg.ReportId == report.Id).ToListAsync();
            report.AverageOfAnswers = averages;
            return report;
        }
        public async Task<bool> GenerateReport(int surveyId)
        {
            try
            {
                var allAnswers = await _context.UserQuestions.Where(a => a.SurveyId == surveyId).ToListAsync();
                var report = new Report(surveyId, allAnswers);
                _context.Reports.Add(report);
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
