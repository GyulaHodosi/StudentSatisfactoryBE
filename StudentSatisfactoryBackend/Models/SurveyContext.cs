using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserQuestion>()
                .HasKey(uq => new { uq.UserId, uq.QuestionId });
            modelBuilder.Entity<Course>().HasData(CourseList.courses);
        }
    }

}
