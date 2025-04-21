using LearningWebApp.Models;
using LearningWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearningWebApp.Controllers
{
    public class TrainerController : Controller
    {

        private readonly TrainerRepository _trainerRepository;


        public TrainerController(TrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public IActionResult Index()
        {
            var data = _trainerRepository.GetAll();
            return View(data);
        }

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Add(Trainer trainer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _trainerRepository.Add(trainer);
        //        return RedirectToAction("Index");
        //    }
        //    return View(trainer);
        //}


       
        public IActionResult Details(int id)
        {
            var item = _trainerRepository.GetById(id);  
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //public IActionResult Edit(int id)
        //{
        //    var item = _trainerRepository.GetById(id);  
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(item); 
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, Trainer item)  
        //{
        //    if (id != item.Id)
        //    {
        //        return BadRequest();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _trainerRepository.UpdateTrainer(item);  
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(item);  
        //}

        //public IActionResult Delete(int id)
        //{
        //    var item = _trainerRepository.GetById(id); // Renamed for brevity
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(item); // Renamed for brevity
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    _trainerRepository.DeleteTrainer(id); // Renamed for brevity
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
