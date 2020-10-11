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

        public Task<IEnumerable<Report>> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetReportById()
        {
            throw new NotImplementedException();
        }
        public Task<bool> GenerateReport(int surveyId)
        {
            throw new NotImplementedException();
        }
    }
}
