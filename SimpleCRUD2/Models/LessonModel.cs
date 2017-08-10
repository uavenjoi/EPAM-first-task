using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimpleCRUD2.Models
{
    public class LessonModel
    {
        public LessonModel()
        {
            this.VisitingUsers = new HashSet<UserModel>();
        }

        public int LessonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        public virtual ICollection<UserModel> VisitingUsers { get; set; }
    }
}