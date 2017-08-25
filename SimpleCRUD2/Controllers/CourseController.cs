using System;
using System.Web;
using System.Web.Mvc;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels.CourseViewModels;
using SimpleCRUD2.XmlWork;

namespace SimpleCRUD2.Controllers
{
    [Authorize(Roles = "admin")]
    public class CourseController : Controller
    {
        private ICourseRepository repository;
        private IXmlProcessor xmlProcessor;

        public CourseController(ICourseRepository repository, IXmlProcessor xmlProcessor)
        {
            this.repository = repository;
            this.xmlProcessor = xmlProcessor;
        }
        
        [HttpGet]
        public ActionResult CreateCourse()
        {
            return this.View("CreateCourse");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetCourseFromXmlFile(HttpPostedFileBase xmlFile)
        {
            if (XmlValidator.IsXmlFile(xmlFile))
            {
                var courseModel = this.xmlProcessor.GetCourseModelFromXml(xmlFile.FileName);

                this.repository.CreateCourseFromCourseModel(courseModel);

                if (courseModel.IsDone.Equals(false))
                {
                    var addLessonsViewModel = new AddLessonsViewModel() { CourseModel = courseModel };

                    return this.View("AddLessonsToCourse", addLessonsViewModel);
                }

                return this.RedirectToAction("Index", "Home");
            }

            return this.View("Error");
        }

        [HttpGet]
        public ActionResult SaveCourseToXml(string name)
        {
            var courseModel = this.repository.GetCourseByName(name);

            this.xmlProcessor.CreateXmlFromCourseModel(courseModel);

            return this.RedirectToAction("Index", "Home");
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

            var lessons = this.repository.GetAllLessons();

            foreach (var lesson in lessons)
            {
                if (lesson.DateTime == addLessonsViewModel.LessonModel.DateTime)
                {
                    ModelState.AddModelError(string.Empty, "Date and time has been used");
                    addLessonsViewModel.CourseModel = this.repository.GetCourseByName(addLessonsViewModel.CourseModel.Name);
                    return this.View("AddLessonsToCourse", addLessonsViewModel);
                }
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

        [HttpPost]
        public void RemoveLessonAjax()
        {
            var lessonId = Convert.ToInt32(Request.Form.GetValues("lessonId")[0]);

            this.repository.RemoveLessonById(lessonId);
        }

        [HttpPost]
        public void DeleteCourseAjax()
        {
            var courseId = Convert.ToInt32(Request.Form.GetValues("courseId")[0]);

            this.repository.DeleteCourseById(courseId);
        }
    }
}