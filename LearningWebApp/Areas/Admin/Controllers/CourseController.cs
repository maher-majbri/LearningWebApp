using LearningWebApp.Models;
using LearningWebApp.Repositories;
using LearningWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearningWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly CourseRepository _courseRepository;
        private readonly TrainerRepository _trainerRepository;
        private readonly FileService _fileService;
        public CourseController(CourseRepository courseRepository, TrainerRepository trainerRepository, FileService fileService)
        {
            _courseRepository = courseRepository;
            _trainerRepository = trainerRepository;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            var data = _courseRepository.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // لتعبئة قائمة المدربين في نموذج الإضافة
            ViewBag.TrainerId = new SelectList(_trainerRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {

                if (course.PictureFile != null && course.PictureFile.Length > 0)
                {
                    var result = _fileService.SavePicture(course.PictureFile);
                    if (result.Item1 == 1)
                    {
                        course.Picture = result.Item2;
                    }
                    else
                    {
                        course.Picture = result.Item2;
                    }
                }
                _courseRepository.Add(course);
                return RedirectToAction("Index");
            }
            // إعادة تعبئة قائمة المدربين في حال وجود أخطاء في النموذج
            ViewBag.TrainerId = new SelectList(_trainerRepository.GetAll(), "Id", "Name", course.TrainerId);
            return View(course);
        }

        public IActionResult Details(int id)
        {
            var item = _courseRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _courseRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            // لتعبئة قائمة المدربين في نموذج التعديل
            ViewBag.TrainerId = new SelectList(_trainerRepository.GetAll(), "Id", "Name", item.TrainerId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _courseRepository.UpdateCourse(item);
                return RedirectToAction(nameof(Index));
            }
            // إعادة تعبئة قائمة المدربين في حال وجود أخطاء في النموذج
            ViewBag.TrainerId = new SelectList(_trainerRepository.GetAll(), "Id", "Name", item.TrainerId);
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = _courseRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseRepository.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}