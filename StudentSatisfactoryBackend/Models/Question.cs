using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Question(string title)
        {
            Title = title;
        }
    }
}
