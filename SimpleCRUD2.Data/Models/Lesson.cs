using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD2.Data.Models
{
    public class Lesson
    {
        public Lesson()
        {
            this.VisitingUsers = new HashSet<User>();
        }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateTime { get; set; }

        public Course Course { get; set; }

        public virtual ICollection<User> VisitingUsers { get; set; }
    }
}
