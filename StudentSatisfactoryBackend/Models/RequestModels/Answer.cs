﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models.RequestModels
{
    public class Answer
    {
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public int Value { get; set; }

        public Answer(string userId, int questionId, int value)
        {
            UserId = userId;
            QuestionId = questionId;
            Value = value;
        }
    }
}
