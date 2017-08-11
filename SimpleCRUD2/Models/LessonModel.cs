using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SimpleCRUD2.Data.Models;

namespace SimpleCRUD2.Models
{
    public class LessonModel
    {
        public LessonModel()
        {
            this.MissingUsers = new HashSet<UserModel>();
        }

        public LessonModel(Lesson lesson)
        {
            this.LessonId = lesson.LessonId;
            this.Name = lesson.Name;
            this.DateTime = lesson.DateTime;
            this.MissingUsers = lesson.MissingUsers.Select(_ => new UserModel(_)).ToList();
        }

        public int LessonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        public virtual ICollection<UserModel> MissingUsers { get; set; }
    }
}