using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSatisfactoryBackend.Models
{
    public class CourseList
    {
        public static List<Course> courses = new List<Course>
        {
            new Course
                    {
                        Id = 1,
                        Name = "Fullstack - Programming Basics",
                        Email = "progbasics@code.cool"
                    },
                    new Course
                    {
                        Id = 2,
                        Name = "Fullstack - Web",
                        Email = "web@code.cool"
                    },
                    new Course
                    {
                        Id = 3,
                        Name = "Fullstack - OOP",
                        Email = "oop@code.cool"
                    },
                    new Course
                    {
                        Id = 4,
                        Name = "Fullstack - Advanced",
                        Email = "advanced@code.cool"
                    }
        };
    }
}
