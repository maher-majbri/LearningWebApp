using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LearningWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        /// FK
        public int TrainerId { get; set; }

        //Navigation prop
        [ValidateNever]
        public Trainer Trainer { get; set; }


        public int Hours { get; set; }
        public  decimal Price { get; set; }

        [ValidateNever]
        public string Picture { get; set; }



        [ValidateNever]
        [NotMapped] // للإشارة إلى أن هذه الخاصية ليست جزءًا من قاعدة البيانات
        [Display(Name = "Upload Picture")]
        public IFormFile PictureFile { get; set; }

    }
}
