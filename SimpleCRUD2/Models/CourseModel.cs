using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Models
{
    public class CourseModel
    {
        public CourseModel()
        {
            this.Lessons = new HashSet<LessonModel>();
        }

        public CourseModel(Course course)
        {
            this.Name = course.Name;
            this.CourseId = course.CourseId;
            this.IsDone = course.IsDone;
            this.Lessons = course.Lessons.Select(_ => new LessonModel(_)).ToList();
        }

        public int CourseId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The name must be at least 10 characters and no longer than 50")]
        public string Name { get; set; }

        [Required]
        public bool IsDone { get; set; }

        public virtual ICollection<LessonModel> Lessons { get; set; }
    }
}