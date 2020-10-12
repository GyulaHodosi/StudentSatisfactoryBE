using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Survey(string title, DateTime date)
        {
            Title = title;
            Date = date;
        }

        [NotMapped]
        public bool FilledAlready { get; set; }
    }
}
