using System.Diagnostics;
using LearningWebApp.Models;
using LearningWebApp.Repositories;
using LearningWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LearningWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseRepository _courseRepository;
        private readonly TrainerRepository _trainerRepository;

        public HomeController(ILogger<HomeController> logger, CourseRepository courseRepository, TrainerRepository trainerRepository)
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _trainerRepository = trainerRepository; 
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                CoursesCount = _courseRepository.GetCount(),
                TrainersCount = _trainerRepository.GetCount(),
                LatestCourses = _courseRepository.GetLatest().ToList(),
                LatestTrainers = _trainerRepository.GetLatest().ToList(),
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
