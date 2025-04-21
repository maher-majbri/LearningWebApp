using LearningWebApp.Data;
using LearningWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningWebApp.Repositories
{
    public class TrainerRepository
    {
        private readonly AppDbContext _context; // Replace with your actual DbContext

        public TrainerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Trainer> GetAll()
        {
            return _context.Trainers.Include(t=>t.Courses).ToList();
        }

        public IEnumerable<Trainer> GetLatest()
        {
            return _context.Trainers
                .OrderByDescending(t => t.Id)
                .Take(3)
                .Include(c => c.Courses).ToList();
        }

        public int GetCount()
        {
            return _context.Courses.Count();
        }

        public Trainer GetById(int id)
        {
            return _context.Trainers.Include(t => t.Courses).FirstOrDefault(t=>t.Id==id);
        }

        public void Add(Trainer trainer)
        {
            _context.Trainers.Add(trainer);
            _context.SaveChanges();
        }
        public void UpdateTrainer(Trainer trainer)
        {
            _context.Entry(trainer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTrainer(int id)
        {
            var trainer = _context.Trainers.Find(id);
            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Trainer> SearchByName(string searchString)
        {
            return _context.Trainers.Where(t => t.Name.Contains(searchString)).ToList();
        }

        public Trainer GetWithCourses(int id)
        {
            return _context.Trainers.Include(t => t.Courses).FirstOrDefault(t => t.Id == id);
        }

    }
}
