using System;
using System.Web.Mvc;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;
using SimpleCRUD2.Models.ViewModels.ModerViewModels;

namespace SimpleCRUD2.Controllers
{
    [Authorize(Roles = "admin, moder")]
    public class ModerController : Controller
    {
        private ICourseRepository courseRepository;
        private IUserRepository userRepository;

        public ModerController(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult OpenJournal()
        {
            var courses = this.courseRepository.GetReadyCourses();

            return this.View("OpenJournal", courses);
        }

        [HttpGet]
        public ActionResult CourseInfo(string name, int pageNumber = 1)
        {
            var pageSize = 10;

            var courseModel = this.courseRepository.GetCourseByName(name);

            var users = this.userRepository.GetStudentsUsersList();

            var lessons = this.courseRepository.GetLessonListForPage(pageNumber, pageSize, courseModel.Name);

            var pageInfo = new PageInfo()
            {
                ActionName = "CourseInfo",
                ControllerName = "Moder",
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = courseModel.Lessons.Count
            };

            ViewBag.CourseName = courseModel.Name;

            var courseInfoViewModel = new CourseInfoViewModel() { Users = users, CourseModel = courseModel, PageInfo = pageInfo, Lessons = lessons };

            return this.View("CourseInfo", courseInfoViewModel);
        }

        [HttpPost]
        public void MissUserAjax()
        {
            var userId = Convert.ToInt32(Request.Form.GetValues("userId")[0]);
            var lessonId = Convert.ToInt32(Request.Form.GetValues("lessonId")[0]);

            this.courseRepository.AddUserToMissingLesson(userId, lessonId);
        }
    }
}