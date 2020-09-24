using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserQuestion>()
                .HasKey(uq => new { uq.UserId, uq.QuestionId });

        }
    }

}
