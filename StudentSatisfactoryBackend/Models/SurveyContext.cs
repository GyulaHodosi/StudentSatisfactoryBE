﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentSatisfactoryBackend.Models;


namespace StudentSatisfactoryBackend.Data
{
    public class SurveyContext : IdentityDbContext<User>
    {
        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options) { }

        public DbSet<User> RegisteredUsers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
        public DbSet<UserVote> UserVotes { get; set; }
        public DbSet<AdminEmail> AdminEmails { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<AverageOfAnswers> AverageOfAnswers { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserQuestion>()
                .HasKey(uq => new { uq.UserId, uq.QuestionId });
            modelBuilder.Entity<UserVote>()
                .HasKey(uv => new { uv.UserId, uv.FeedbackId });
            modelBuilder.Entity<AverageOfAnswers>()
                .HasKey(aoa => new { aoa.ReportId, aoa.QuestionId });
            modelBuilder.Entity<Course>().HasData(CourseList.courses);
            modelBuilder.Entity<Question>().HasData(QuestionList.questions);
            modelBuilder.Entity<AdminEmail>().HasData(new AdminEmail("codecool.satisfactionapp@gmail.com") {Id = 1 });
        }
    }

}
