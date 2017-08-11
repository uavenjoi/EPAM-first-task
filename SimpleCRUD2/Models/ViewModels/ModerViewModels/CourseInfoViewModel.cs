using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD2.Models.ViewModels.ModerViewModels
{
    public class CourseInfoViewModel
    {
        public IEnumerable<UserModel> Users { get; set; }

        public IEnumerable<LessonModel> Lessons { get; set; }

        public CourseModel CourseModel { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}