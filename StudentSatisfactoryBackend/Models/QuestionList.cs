using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class QuestionList
    {
        public static List<Question> questions = new List<Question>
        {
            new Question("Codecool office staff has good response times when there's a question or problem")
            {
                Id = 1
            },
            new Question("There's a valid reaction (something happens) from Codecool office staff when I raise a problem.")
            {
                Id = 2
            },new Question("The process of study/job contracting, signing paperwork is smooth, communication about it is satisfactory.")
            {
                Id = 3
            },new Question("There's a cool atmosphere in Codecool which helps me to improve and stay motivated.")
            {
                Id = 4
            },new Question("I feel belonging to a group in Codecool and it satisfies me.")
            {
                Id = 5
            },new Question("Codecool is located in a great place (easily reachable, travel time from your home is okay).")
            {
                Id = 6
            },new Question("Codecool office offers a clean and calm environment that is needed for me to focus on my studies.")
            {
                Id = 7
            },new Question("The theoretical materials provided by Codecool help my journey becoming a junior developer.")
            {
                Id = 8
            },new Question("The practical materials provided by Codecool help my journey becoming a junior developer.")
            {
                Id = 9
            },new Question("The requirements or competencies in the curriculum provided by Codecool are clear and help my journey becoming a software developer.")
            {
                Id = 10
            },new Question("I get enough professional help (either from my peers or from mentors) in order to improve in hard skills.")
            {
                Id = 11
            },new Question("I get enough professional help(either from my peers or from staff members) in order to improve in soft skills.")
            {
                Id = 12
            },new Question("I get enough emotional support (either from my peers or from staff members) when I need to.")
            {
                Id = 13
            },new Question("I believe that I will find a job suitable for me after graduating from Codecool.")
            {
                Id = 14
            },new Question("I would definitely need Codecool's help in finding my first job after graduating.")
            {
                Id = 15
            },new Question("I believe that there are enough positions to choose from after graduating from Codecool.")
            {
                Id = 16
            },new Question("Codecool's job interview preparation is a huge help for me to get a job I need.")
            {
                Id = 17
            },new Question("What do you think about the number of frontal lessons in Codecool?")
            {
                Id = 18
            },new Question("What do you think about the amount of teamwork in Codecool?")
            {
                Id = 19
            },new Question("What do you think about the amount of self-study time in Codecool?")
            {
                Id = 20
            },new Question("What do you think about the number of interactive workshops in Codecool?")
            {
                Id = 21

            }
        };
    }
}
