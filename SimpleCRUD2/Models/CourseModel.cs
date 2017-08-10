using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Models
{
    public class CourseModel
    {
        public CourseModel()
        {
            this.Lessons = new HashSet<Lesson>();
        }

        public int CourseId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The name must be at least 10 characters and no longer than 50")]
        public string Name { get; set; }

        [Required]
        public bool IsDone { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}