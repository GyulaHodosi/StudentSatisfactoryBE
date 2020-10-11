﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class QuestionList
    {
        public static List<Question> questions = new List<Question>
        {
            new Question("Codecool office staff has good response times when there's a question or problem",DateTime.Now)
            {
                Id = 1
            },
            new Question("There's a valid reaction (something happens) from Codecool office staff when I raise a problem.",DateTime.Now)
            {
                Id = 2,
                Date = DateTime.Now
            },new Question("The process of study/job contracting, signing paperwork is smooth, communication about it is satisfactory.",DateTime.Now)
            {
                Id = 3,
                Date = DateTime.Now
            },new Question("There's a cool atmosphere in Codecool which helps me to improve and stay motivated.",DateTime.Now)
            {
                Id = 4,
                Date = DateTime.Now
            },new Question("I feel belonging to a group in Codecool and it satisfies me.",DateTime.Now)
            {
                Id = 5,
                Date = DateTime.Now
            },new Question("Codecool is located in a great place (easily reachable, travel time from your home is okay).",DateTime.Now)
            {
                Id = 6,
                Date = DateTime.Now
            },new Question("Codecool office offers a clean and calm environment that is needed for me to focus on my studies.",DateTime.Now)
            {
                Id = 7,
                Date = DateTime.Now
            },new Question("The theoretical materials provided by Codecool help my journey becoming a junior developer.",DateTime.Now)
            {
                Id = 8,
                Date = DateTime.Now
            },new Question("The practical materials provided by Codecool help my journey becoming a junior developer.",DateTime.Now)
            {
                Id = 9,
                Date = DateTime.Now
            },new Question("The requirements or competencies in the curriculum provided by Codecool are clear and help my journey becoming a software developer.",DateTime.Now)
            {
                Id = 10,
                Date = DateTime.Now
            },new Question("I get enough professional help (either from my peers or from mentors) in order to improve in hard skills.",DateTime.Now)
            {
                Id = 11,
                Date = DateTime.Now
            },new Question("I get enough professional help(either from my peers or from staff members) in order to improve in soft skills.",DateTime.Now)
            {
                Id = 12,
                Date = DateTime.Now
            },new Question("I get enough emotional support (either from my peers or from staff members) when I need to.",DateTime.Now)
            {
                Id = 13,
                Date = DateTime.Now
            },new Question("I believe that I will find a job suitable for me after graduating from Codecool.",DateTime.Now)
            {
                Id = 14,
                Date = DateTime.Now
            },new Question("I would definitely need Codecool's help in finding my first job after graduating.",DateTime.Now)
            {
                Id = 15,
                Date = DateTime.Now
            },new Question("I believe that there are enough positions to choose from after graduating from Codecool.",DateTime.Now)
            {
                Id = 16,
                Date = DateTime.Now
            },new Question("Codecool's job interview preparation is a huge help for me to get a job I need.",DateTime.Now)
            {
                Id = 17,
                Date = DateTime.Now
            },new Question("What do you think about the number of frontal lessons in Codecool?",DateTime.Now)
            {
                Id = 18,
                Date = DateTime.Now
            },new Question("What do you think about the amount of teamwork in Codecool?",DateTime.Now)
            {
                Id = 19,
                Date = DateTime.Now
            },new Question("What do you think about the amount of self-study time in Codecool?",DateTime.Now)
            {
                Id = 20,
                Date = DateTime.Now
            },new Question("What do you think about the number of interactive workshops in Codecool?",DateTime.Now)
            {
                Id = 21,
                Date = DateTime.Now
            }
        };
    }
}
