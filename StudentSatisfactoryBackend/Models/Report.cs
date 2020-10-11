using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int FillCount { get; set; }
        public List<AverageOfAnswers> AverageOfAnswers { get; set; }

        public Report()
        {

        }
        public Report(int surveyId, List<UserQuestion> answers)
        {
            SurveyId = surveyId;
            AverageOfAnswers = new List<AverageOfAnswers>();
            FillCount = GetFillCount(answers);
            AddAveragesOfAnswers(answers);
        }

        public void AddAveragesOfAnswers(List<UserQuestion> answers)
        {
            foreach(var answer in answers)
            {
                var question = AverageOfAnswers.FirstOrDefault(a => a.QuestionId == answer.QuestionId);
                if(question != null)
                {
                    question.Average += answer.Value;
                } 
                else
                {
                    AverageOfAnswers.Add(new AverageOfAnswers(Id, answer.QuestionId, answer.Value));
                }
            }

            foreach(var avg in AverageOfAnswers)
            {
                avg.Average /= FillCount;
            }
        }

        private int GetFillCount(List<UserQuestion> answers)
        {
            return answers.Count(a => a.QuestionId == 1 && a.SurveyId == SurveyId);

        }
    }
}
