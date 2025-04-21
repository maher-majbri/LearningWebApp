using LearningWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LearningWebApp.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Course> Courses { get; set; }


     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Course and Trainer
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Trainer)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TrainerId);

            // Seed data (in Arabic)
            modelBuilder.Entity<Trainer>().HasData(
                new Trainer { Id = 1, Name = "أحمد محمد", Info = "مدرب متخصص في تطوير الويب." },
                new Trainer { Id = 2, Name = "فاطمة علي", Info = "مدربة معتمدة في تصميم الجرافيك." }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "تطوير تطبيقات الويب باستخدام ASP.NET Core",
                    Description = "دورة شاملة لتعلم تطوير تطبيقات الويب الحديثة.",
                    TrainerId = 1,
                    Hours = 40,
                    Price = 1500,
                    Picture = "2.jpg",
                },
                new Course
                {
                    Id = 2,
                    Title = "تصميم الجرافيك باستخدام Adobe Photoshop",
                    Description = "دورة عملية لتعلم أساسيات ومتقدمة تصميم الجرافيك.",
                    TrainerId = 2,
                    Hours = 30,
                    Price = 1200,
                    Picture = "1.jpg"
                },
                new Course
                {
                    Id = 3,
                    Title = "مقدمة في البرمجة باستخدام لغة C#",
                    Description = "دورة للمبتدئين لتعلم أساسيات البرمجة.",
                    TrainerId = 1,
                    Hours = 20,
                    Price = 800,
                    Picture = "3.jpg"
                }
            );
        }

    }
}
