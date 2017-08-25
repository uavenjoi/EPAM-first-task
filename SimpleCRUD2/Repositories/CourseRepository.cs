using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleCRUD2.Data.Interfaces;
using SimpleCRUD2.Data.Models;
using SimpleCRUD2.Interfaces;
using SimpleCRUD2.Models;

namespace SimpleCRUD2.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private IContext context;

        public CourseRepository(IContext context)
        {
            this.context = context;
        }

        public bool CreateCourse(string name)
        {
            var searchCourse = this.context.Courses.FirstOrDefault(_ => _.Name == name);

            if (searchCourse == null)
            {
                var course = new Course() { Name = name };

                this.context.Courses.Add(course);
                this.context.SaveChanges();

                return true;
            }

            return false;
        }

        public void CreateCourseFromCourseModel(CourseModel courseModel)
        {
            this.CreateCourse(courseModel.Name);

            foreach (var lessonModel in courseModel.Lessons)
            {
                this.AddLesson(courseModel, lessonModel);
            }
        }

        public void DeleteCourseById(int id)
        {
            var course = this.context.Courses.Single(_ => _.CourseId == id);

            this.context.Courses.Remove(course);
            this.context.SaveChanges();
        }

        public IEnumerable<CourseModel> GetReadyCourses()
        {
            var courses = this.context.Courses.Where(_ => _.IsDone).ToList();

            var coursesModels = new List<CourseModel>();

            foreach (var course in courses)
            {
                coursesModels.Add(this.FromCourseToCourseModel(course));
            }

            return coursesModels;
        }

        public IEnumerable<LessonModel> GetAllLessons()
        {
            var lessons = this.context.Lessons.ToList();

            var lessonsModels = new List<LessonModel>();

            foreach (var lesson in lessons)
            {
                lessonsModels.Add(this.FromLessonToLessonModel(lesson));
            }

            return lessonsModels;
        }

        public IEnumerable<LessonModel> GetLessonListForPage(int pageNumber, int pageSize, string courseName)
        {
            var course = this.context.Courses.Single(_ => _.Name == courseName);

            var lessonsModels = new List<LessonModel>();

            foreach (var lesson in course.Lessons)
            {
                lessonsModels.Add(this.FromLessonToLessonModel(lesson));
            }

            var lessons = lessonsModels.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return lessons;
        }

        public CourseModel GetCourseByName(string name)
        {
            var course = this.context.Courses.Single(_ => _.Name == name);

            var courseModel = this.FromCourseToCourseModel(course);

            return courseModel;
        }

        public LessonModel GetLessonById(int id)
        {
            var lesson = this.context.Lessons.Single(_ => _.LessonId == id);

            var lessonModel = this.FromLessonToLessonModel(lesson);

            return lessonModel;
        }

        public void AddLesson(CourseModel courseModel, LessonModel lessonModel)
        {
            var course = this.context.Courses.Single(_ => _.Name == courseModel.Name);

            var lesson = new Lesson() { Name = lessonModel.Name, DateTime = lessonModel.DateTime };

            course.IsDone = courseModel.IsDone;
            course.Lessons.Add(lesson);

            this.context.Lessons.Add(lesson);
            this.context.SaveChanges();
        }

        public void RemoveLessonById(int lessonId)
        {
            var lesson = this.context.Lessons.Single(_ => _.LessonId == lessonId);

            this.context.Lessons.Remove(lesson);
            this.context.SaveChanges();
        }

        public void AddUserToMissingLesson(int userId, int lessonId)
        {
            var user = this.context.Users.Single(_ => _.UserId == userId);

            var lesson = this.context.Lessons.Single(_ => _.LessonId == lessonId);

            if (lesson.MissingUsers.Contains(user))
            {
                lesson.MissingUsers.Remove(user);
            }
            else
            {
                lesson.MissingUsers.Add(user);
            }

            this.context.SaveChanges();
        }

        private UserModel FromUserToUserModel(User user)
        {
            var userModel = new UserModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Birthday = user.Birthday,
                Email = user.Email,
                Location = user.Location
            };

            return userModel;
        }

        private LessonModel FromLessonToLessonModel(Lesson lesson)
        {
            var usersList = new List<UserModel>();

            foreach (var user in lesson.MissingUsers)
            {
                usersList.Add(this.FromUserToUserModel(user));
            }

            var lessonModel = new LessonModel()
            {
                LessonId = lesson.LessonId,
                Name = lesson.Name,
                DateTime = lesson.DateTime,
                MissingUsers = usersList
            };

            return lessonModel;
        }

        private CourseModel FromCourseToCourseModel(Course course)
        {
            var lessonsList = new List<LessonModel>();

            foreach (var lesson in course.Lessons)
            {
                lessonsList.Add(this.FromLessonToLessonModel(lesson));
            }

            var courseModel = new CourseModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                IsDone = course.IsDone,
                Lessons = lessonsList
            };

            return courseModel;
        }
    }
}