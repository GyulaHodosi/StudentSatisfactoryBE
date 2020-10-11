using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class AverageOfAnswers
    {
        public Report Report { get; set; }
        public int ReportId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public int Average { get; set; }

        public AverageOfAnswers(int reportId, int questionId, int average)
        {
            ReportId = reportId;
            QuestionId = questionId;
            Average = average;
        }
    }
}
