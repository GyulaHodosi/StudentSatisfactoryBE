using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class Report
    {
        public int SurveyId { get; set; }
        public int FillCount { get; set; }
        public Dictionary<int, int> QuestionAverage { get; set; }

        public Report(int surveyId, List<UserQuestion> answers)
        {
            SurveyId = surveyId;
            QuestionAverage = new Dictionary<int, int>();
            FillCount = GetFillCount(answers);
            AddAveragesOfQuestions(answers);
        }

        public void AddAveragesOfQuestions(List<UserQuestion> answers)
        {
            foreach(var answer in answers)
            {
                if (QuestionAverage.ContainsKey(answer.QuestionId))
                {
                    QuestionAverage[answer.QuestionId] += answer.Value;
                } else
                {
                    QuestionAverage[answer.QuestionId] = answer.Value;
                }
            }

            foreach(var key in QuestionAverage.Keys)
            {
                QuestionAverage[key] = QuestionAverage[key] / FillCount;
            }
        }

        private int GetFillCount(List<UserQuestion> answers)
        {
            return answers.Count(a => a.QuestionId == 1 && a.SurveyId == SurveyId);

        }
    }
}
