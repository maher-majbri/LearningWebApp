using System.ComponentModel.DataAnnotations;

namespace LearningWebApp.Models
{
    public class Trainer
    {
        public int Id { get; set; }
    
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(10, ErrorMessage = "Name cannot exceed 10 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Info cannot exceed 500 characters.")]
        public string Info { get; set; }

        //navigation prop
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
