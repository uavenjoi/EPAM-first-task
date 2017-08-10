using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD2.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.Lessons = new HashSet<Lesson>();
        }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDone { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
