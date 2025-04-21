using LearningWebApp.Data;
using LearningWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LearningWebApp.Repositories
{
    public class CourseRepository
    {
        private readonly AppDbContext _context; // استبدل بـ DbContext الفعلي الخاص بك

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(c => c.Trainer).ToList();
        }

        public IEnumerable<Course> GetLatest()
        {
            return _context.Courses
                .OrderByDescending(c => c.Id)
                .Take(3)
                .Include(c => c.Trainer).ToList();
        }

        public int GetCount()
        {
            return _context.Courses.Count();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Include(c => c.Trainer).FirstOrDefault(c => c.Id == id);
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Course> SearchByTitle(string searchString)
        {
            return _context.Courses.Where(c => c.Title.Contains(searchString)).Include(c => c.Trainer).ToList();
        }

        public IEnumerable<Course> GetByTrainerId(int trainerId)
        {
            return _context.Courses.Where(c => c.TrainerId == trainerId).Include(c => c.Trainer).ToList();
        }

        public Course GetWithTrainer(int id)
        {
            return _context.Courses.Include(c => c.Trainer).FirstOrDefault(c => c.Id == id);
        }
    }
}