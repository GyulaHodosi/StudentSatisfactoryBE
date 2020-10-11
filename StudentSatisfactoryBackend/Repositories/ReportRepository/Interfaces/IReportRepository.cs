using StudentSatisfactoryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Repositories.ReportRepository.Interfaces
{
    public interface IReportRepository
    {
        Task<Report> GetReportById(int id);
        Task<IEnumerable<Report>> GetAllReports();
        Task<bool> GenerateReport(int surveyId);
    }
}
