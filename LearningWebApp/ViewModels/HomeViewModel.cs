using LearningWebApp.Models;

namespace LearningWebApp.ViewModels
{
    public class HomeViewModel
    {
        public int CoursesCount { get; set; }
        public int TrainersCount { get; set; }

        public List<Course> LatestCourses { get; set; }
          
        public List<Trainer> LatestTrainers { get; set; }
    }
}
