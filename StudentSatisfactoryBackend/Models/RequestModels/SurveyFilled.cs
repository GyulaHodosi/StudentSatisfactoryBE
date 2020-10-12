using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models.RequestModels
{
    public class SurveyFilled
    {
        public string TokenId { get; set; }
        public int SurveyId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
