using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models.RequestModels
{
    public class SurveyFilled
    {
        public string UserId { get; set; }
        public int SurveyId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
