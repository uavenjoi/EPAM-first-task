using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels.CourseViewModels;

namespace SimpleCRUD2.Controllers
{
    [Authorize(Roles = "admin")]
    public class CourseController : Controller
    {
        private ICourseRepository repository;

        public CourseController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            return this.View("CreateCourse");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCourse(CourseModel courseModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View("CreateCourse");
            }

            if (this.repository.CreateCourse(courseModel.Name))
            {
                var addLessonsViewModel = new AddLessonsViewModel() { CourseModel = courseModel };

                return this.View("AddLessonsToCourse", addLessonsViewModel);
            }

            ModelState.AddModelError(string.Empty, "Name's been used");

            return this.View("CreateCourse");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLessonsToCourse(AddLessonsViewModel addLessonsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View("AddLessonsToCourse", addLessonsViewModel);
            }

            var lessonModel = new LessonModel()
            {
                Name = addLessonsViewModel.LessonModel.Name,
                DateTime = addLessonsViewModel.LessonModel.DateTime
            };

            this.repository.AddLesson(addLessonsViewModel.CourseModel, lessonModel);

            if (addLessonsViewModel.CourseModel.IsDone)
            {
                return this.RedirectToAction("Index", "Home");
            }

            addLessonsViewModel.CourseModel = this.repository.GetCourseByName(addLessonsViewModel.CourseModel.Name);

            return this.View("AddLessonsToCourse", addLessonsViewModel);
        }
    }
}